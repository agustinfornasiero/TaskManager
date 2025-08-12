using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

using TaskManager.Core.Entities;

namespace TaskManager.Infrastructure.Persistence.Configurations
{
    public class TaskItemEntityTypeConfiguration : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            builder.ToTable("Tasks");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Title).IsRequired().HasMaxLength(250);
            builder.Property(t => t.Description);
            builder.Property(t => t.Status).IsRequired().HasConversion<int>();
            builder.Property(t => t.AssignedUserId).IsRequired();
            builder.Property(t => t.CreatedByUserId).IsRequired();
            builder.Property(t => t.CreatedAt).IsRequired();
            builder.Property(t => t.UpdatedAt).IsRequired();

            // Mapear la colección de eventos (backing field) y permitir que EF acceda por campo
            builder.HasMany(t => t.Events)
                .WithOne()
                .HasForeignKey(e => e.TaskId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indicamos a EF que use el campo privado (bacing field) para la navegación
            builder.Navigation(t => t.Events)
                .UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
