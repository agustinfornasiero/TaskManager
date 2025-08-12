using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Entities;

namespace TaskManager.Infrastructure.Persistence.Configurations
{
    public class TaskEventEntityTypeConfiguration : IEntityTypeConfiguration<TaskEvent>
    {
        public void Configure(EntityTypeBuilder<TaskEvent> builder)
        {
            builder.ToTable("TaskEvents");
            builder.HasKey(te => te.Id);

            builder.Property(te => te.TaskId).IsRequired();
            builder.Property(te => te.OcurredAt).IsRequired();
            builder.Property(te => te.Description).HasMaxLength(1000);
            builder.Property(te => te.FromUserId);
            builder.Property(te => te.ToUserId);

            // Convertir los enums a int nulleables
            builder.Property(te => te.FromStatus).HasConversion<int?>();
            builder.Property(te => te.ToStatus).HasConversion<int?>();
        }
    }
}
