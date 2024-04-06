using DotNetTemplate.Core.Interfaces;
using DotNetTemplate.Data.Repository;
using DotNetTemplate.Application.Interfaces;
using DotNetTemplate.Application.Services;
using DotNetTemplate.Data;
using DotNetTemplate.Presentation.Extensions;
using DotNetTemplate.Application.Extensions;
using DotNetTemplate.Infrastructure.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

builder.Services.AddDbContext<DotNetTemplateDbContext>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();

builder.Services.AddTransient<ITodoReadRepository, TodoReadRepository>();
builder.Services.AddTransient<ITodoWriteRepository, TodoWriteRepository>();
builder.Services.AddTransient<IUserReadRepository, UserReadRepository>();
builder.Services.AddTransient<IUserWriteRepository, UserWriteRepository>();
builder.Services.AddTransient<IHashService, HashService>();
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddTransient<IUserService, UserService>();


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
