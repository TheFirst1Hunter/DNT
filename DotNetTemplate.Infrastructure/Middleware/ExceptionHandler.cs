using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;
using DotNetTemplate.Application.DTOs;
using DotNetTemplate.Presentation.DTOs;
using DotNetTemplate.Infrastructure.DTOs;
using DotNetTemplate.Core.Exceptions;

namespace DotNetTemplate.Infrastructure.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        var response = context.Response;

        var errorResponse = new ErrorResponse("", 400, "");

        switch (exception)
        {
            case ApplicationException ex:
                if (ex.Message.Contains("Invalid Token"))
                {
                    response.StatusCode = (int)HttpStatusCode.Forbidden;
                    errorResponse.Message = ex.Message;
                    break;
                }

                if (ex.Message.Contains("no entity with this id"))
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    errorResponse.Message = ex.Message;
                    break;
                }

                response.StatusCode = (int)HttpStatusCode.BadRequest;
                errorResponse.Message = ex.Message;
                break;

            case BaseException baseException:
                errorResponse.StatusCode = baseException.StatusCode;
                errorResponse.Message = baseException.Message;
                errorResponse.ErrorCode = baseException.ErrorCode;
                break;


            case System.InvalidOperationException ex:
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                if (ex.Message.Contains("Either the query source is not an entity type"))
                {
                    errorResponse.Message = "Invalid query parameters (orderBy)!";
                    break;
                }

                errorResponse.Message = ex.Message;
                break;
            case Microsoft.EntityFrameworkCore.DbUpdateException ex:
                response.StatusCode = (int)HttpStatusCode.BadRequest;

                if (ex.InnerException?.Message.Contains("duplicate key value violates unique constraint") == true)
                {
                    string pattern = @"constraint ""(\w+)_(\w+)""";

                    // Match the pattern in the input string.
                    Match match = Regex.Match(ex.InnerException.Message, pattern);
                    if (match.Success)
                    {
                        string table = match.Groups[1] != null ? match.Groups[1].Value : "unknown table";
                        string column = match.Groups[2] != null ? match.Groups[2].Value : "unknown column";
                        errorResponse.Message = $"Duplicate key value violates unique constraint on entity:{table.Split("_")[1]}, property: {column}";
                        break;
                    }

                }
                errorResponse.Message = ex.InnerException?.Message;
                break;
            default:
                _logger.LogError(exception.Message);
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                errorResponse.Message = "Internal server error!";
                break;
        }
        _logger.LogError(exception.Message);
        var result = JsonSerializer.Serialize(errorResponse);
        await context.Response.WriteAsync(result);
    }
}