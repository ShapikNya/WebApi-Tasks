using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Persistense.EntityTypeConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Tasks.Domain.User>
    {
        public void Configure(EntityTypeBuilder<Domain.User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
            builder.Property(x => x.PasswordHash).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Role).HasMaxLength(64).IsRequired();
        }
    }
}
