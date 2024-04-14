using DotNetTemplate.Data;
using DotNetTemplate.Presentation.Extensions;
using DotNetTemplate.Application.Extensions;
using DotNetTemplate.Infrastructure.Middleware;
using DotNetTemplate.Data.Extensions;
using DotNetTemplate.Infrastructure.Logger;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<DotNetTemplateDbContext>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();

builder.Services.AddRepositories();
builder.Services.AddServices();

builder.UseSerilogLogging();

builder.AddJWTAuth();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();



app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<HttpLoggingMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
