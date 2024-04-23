using DotNetTemplate.Application.Interfaces;
using DotNetTemplate.Core.Entities;
using DotNetTemplate.Data.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace DotNetTemplate.Data;

public class DotNetTemplateDbContext : DbContext
{
    private IConfiguration _configuration;
    private IUserService _userService;

    private string _host;

    private string _port;

    private string _username;

    private string _database;

    private string _password;
    private bool _IncludeErrorDetail;

    public DotNetTemplateDbContext(DbContextOptions<DotNetTemplateDbContext> options, IConfiguration configuration, IUserService userService) : base(options)
    {
        _configuration = configuration;
        _host = _configuration.GetValue<string>("DB:Host");
        _port = _configuration.GetValue<string>("DB:Port");
        _username = _configuration.GetValue<string>("DB:Username");
        _database = _configuration.GetValue<string>("DB:Database");
        _password = _configuration.GetValue<string>("DB:Password");
        _IncludeErrorDetail = _configuration.GetValue<bool>("DB:IncludeErrorDetail");

        _userService = userService;
    }


    public DbSet<Todo> Todos { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<AuditedEntity<Guid>> Auditions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql($"Host={_host};Port={_port};Database={_database};Username={_username};Password={_password};");

        optionsBuilder.AddInterceptors(new SoftDeleteInterceptor<Guid>());
        optionsBuilder.AddInterceptors(new AuditionInterceptor(_userService));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TodoDBConfiguration());
        modelBuilder.ApplyConfiguration(new UserDBConfiguration());


        base.OnModelCreating(modelBuilder);
    }

    // public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    // {
    //     foreach (var entry in ChangeTracker.Entries<BaseEntity<Guid>>())
    //     {
    //         switch (entry.State)
    //         {
    //             case EntityState.Deleted:
    //                 entry.State = EntityState.Unchanged;
    //                 entry.Entity.IsDeleted = true;
    //                 break;

    //                 // case EntityState.Modified:
    //                 //     entry.Entity. = DateTime.UtcNow;
    //                 //     break;
    //         }
    //     }

    //     return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    // }
}