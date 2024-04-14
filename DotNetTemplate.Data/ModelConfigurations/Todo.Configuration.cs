using DotNetTemplate.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetTemplate.Data;

public class TodoDBConfiguration : BaseDBConfiguration<Todo>
{
    public override void Configure(EntityTypeBuilder<Todo> builder)
    {
        builder.HasQueryFilter(t => t.DeletedAt == null);
        builder.ToTable("Todos");
    }
}