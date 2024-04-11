using DotNetTemplate.Core.Interfaces;
using DotNetTemplate.Data.Repository;
using DotNetTemplate.Application.Interfaces;
using DotNetTemplate.Application.Services;
using DotNetTemplate.Data;
using DotNetTemplate.Presentation.Extensions;
using DotNetTemplate.Application.Extensions;
using DotNetTemplate.Infrastructure.Middleware;
using DotNetTemplate.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

builder.Services.AddDbContext<DotNetTemplateDbContext>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();

builder.Services.AddRepositories();
builder.Services.AddServices();


builder.AddJWTAuth();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
