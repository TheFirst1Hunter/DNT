using DotNetTemplate.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetTemplate.Data;

public class BaseDBConfiguration : IEntityTypeConfiguration<BaseEntity<Guid>>
{
    public void Configure(EntityTypeBuilder<BaseEntity<Guid>> builder)
    {
        builder.HasQueryFilter(t => t.DeletedAt == null);
    }
}