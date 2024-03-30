using DotNetTemplate.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNetTemplate.Data;

public class DotNetTemplateDbContext : DbContext
{
    private IConfiguration _configuration;

    private string _host;

    private string _port;

    private string _username;

    private string _database;

    private string _password;
    private bool _IncludeErrorDetail;

    public DotNetTemplateDbContext(DbContextOptions<DotNetTemplateDbContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
        _host = _configuration.GetValue<string>("DB:Host");
        _port = _configuration.GetValue<string>("DB:Port");
        _username = _configuration.GetValue<string>("DB:Username");
        _database = _configuration.GetValue<string>("DB:Database");
        _password = _configuration.GetValue<string>("DB:Password");
        _IncludeErrorDetail = _configuration.GetValue<bool>("DB:IncludeErrorDetail");
    }


    public DbSet<Todo> Todos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql($"Host={_host};Port={_port};Database={_database};Username={_username};Password={_password};");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TodoConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}