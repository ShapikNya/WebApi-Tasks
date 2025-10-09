using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Domain;


namespace Tasks.Persistense.EntityTypeConfigurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Tasks.Domain.Task>
    {
         public void Configure(EntityTypeBuilder<Domain.Task> builder)
         {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Title).HasMaxLength(32).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(150);
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.IsCompleted).IsRequired().HasDefaultValue(false);
        }
    }
}
