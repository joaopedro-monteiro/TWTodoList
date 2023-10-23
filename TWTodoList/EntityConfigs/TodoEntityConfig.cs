using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TWTodoList.Models;

namespace TWTodoList.EntityConfigs
{
    public class TodoEntityConfig : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.ToTable("todo");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id)
                .HasColumnName("id");

            builder.Property(t => t.Title)
                .HasColumnName("title")
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.Property(t => t.Date)
                .HasColumnName("date")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(t => t.IsCompleted)
                .HasColumnName("is_completed")
                .HasColumnType("bit")
                .IsRequired();
        }
    }
}
