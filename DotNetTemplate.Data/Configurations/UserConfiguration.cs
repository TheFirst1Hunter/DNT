using DotNetTemplate.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetTemplate.Data;

public class UserDBConfiguration : BaseDBConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Userss");
        builder.Property<string>("Username").HasColumnName("Username");
        builder.Property<string>("Password").HasColumnName("Password");
    }
}