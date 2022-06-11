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
    public class UserUseCaseConfiguration : BaseConfiguration<User_UseCase>
    {
        public override void SpecificConfiguration(EntityTypeBuilder<User_UseCase> builder)
        {
            builder.HasOne(x=>x.User).WithMany(x=>x.UseCases).HasForeignKey(x=>x.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x=>x.UseCase).WithMany(x=>x.UserUseCases).HasForeignKey(x=>x.UseCaseID).OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
