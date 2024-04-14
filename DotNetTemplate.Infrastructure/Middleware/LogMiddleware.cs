using DotNetTemplate.Infrastructure.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTemplate.Infrastructure.Middleware
{
    public class HttpLoggingMiddleware
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;


        public HttpLoggingMiddleware(RequestDelegate next, ILogger<HttpLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }


        public async Task Invoke(HttpContext context)
        {
            // Copy pointer to the original response body stream
            var originalBodyStream = context.Response.Body;

            // Get incoming request
            var logModel = await GetLogModelAsync(context.Request);

            // Create a new memory stream and use it for the temporary response body
            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                // Continue down the Middleware pipeline
                await _next(context);

                // Format the response from the server
                logModel.Response = await GetResponseModelAsync(context.Response);

                // Log the log model
                _logger.LogInformation("{@LogModel}", logModel);

                // Copy the contents of the new memory stream, which contains the response, to the original stream
                responseBody.Seek(0, SeekOrigin.Begin);
                await responseBody.CopyToAsync(originalBodyStream);
            }
        }

        private async Task<LogModel> GetLogModelAsync(HttpRequest request)
        {
            var logModel = new LogModel
            {
                Timestamp = DateTime.UtcNow,
                // Level = "Information",
                UserId = request.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "Anonymous",
                UserName = request.HttpContext?.User?.Identity?.Name ?? "Anonymous",
                // Source = "HttpLoggingMiddleware",
                Request = new RequestModel
                {
                    Url = $"{request.Scheme}://{request.Host}{request.Path}",
                    Method = request.Method,
                    Headers = request.Headers.ToDictionary(kv => kv.Key, kv => kv.Value.ToString()),
                    QueryParameters = request.Query.ToDictionary(kv => kv.Key, kv => kv.Value.ToString()),
                    Body = await GetRequestBodyAsStringAsync(request),
                    IpAddress = request.HttpContext.Connection.RemoteIpAddress?.ToString(),
                    Protocol = request.Protocol,
                },

            };

            return logModel;
        }

        private async Task<Dictionary<string, string>> GetRequestBodyAsStringAsync(HttpRequest request)
        {
            var body = request.Body;
            request.EnableBuffering();

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            request.Body.Seek(0, SeekOrigin.Begin);

            var bodyAsText = Encoding.UTF8.GetString(buffer);
            return new Dictionary<string, string> { { "Body", bodyAsText } };
        }

        private async Task<ResponseModel> GetResponseModelAsync(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var body = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            return new ResponseModel
            {
                StatusCode = response.StatusCode,
                Headers = response.Headers.ToDictionary(kv => kv.Key, kv => kv.Value.ToString()),
                Body = body
            };
        }
    }
}
