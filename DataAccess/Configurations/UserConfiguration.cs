using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class UserConfiguration : BaseConfiguration<User>
    {
        public override void SpecificConfiguration(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.Username).IsUnique();

            builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Username).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(255);
            builder.Property(x => x.IsActive).HasDefaultValue(false);

            builder.HasMany(x => x.UseCases).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.TraceObjects).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
           
        }
    }
}
