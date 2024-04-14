using Microsoft.Extensions.Hosting;
using Serilog;

namespace DotNetTemplate.Infrastructure.Logger
{
    public static class SerilogConfig
    {
        public static WebApplicationBuilder UseSerilogLogging(this WebApplicationBuilder builder)
        {
            // Configure Serilog
            var logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("DotNetTemplate.Infrastructure/Logging/Logs/Logs.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            // Use Serilog as the logging provider
            builder.Host.UseSerilog(logger);

            return builder;
        }
    }
}