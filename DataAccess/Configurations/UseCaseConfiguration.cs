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
    public class UseCaseConfiguration : BaseConfiguration<Use_Cases>
    {
        public override void SpecificConfiguration(EntityTypeBuilder<Use_Cases> builder)
        {

            builder.HasIndex(x => x.Name).IsUnique();
            builder.HasIndex(x => x.IdUseCase).IsUnique();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.IdUseCase).IsRequired();

            builder.HasMany(x=>x.UserUseCases).WithOne(x=>x.UseCase).HasForeignKey(x=>x.UseCaseID).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x=>x.TraceObjects).WithOne(x=>x.UseCase).HasForeignKey(x=>x.UseCaseId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
