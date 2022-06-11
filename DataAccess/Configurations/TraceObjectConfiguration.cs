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
    public class TraceObjectConfiguration : BaseConfiguration<TraceObjects>
    {
        public override void SpecificConfiguration(EntityTypeBuilder<TraceObjects> builder)
        {
            
            builder.Property(x => x.Response).IsRequired();

            builder.HasOne(x => x.UseCase).WithMany(x => x.TraceObjects).HasForeignKey(x => x.UseCaseId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.User).WithMany(x => x.TraceObjects).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
