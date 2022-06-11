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
    public class PaymentCategoryConfiguration : BaseConfiguration<PaymentCategory>
    {
        public override void SpecificConfiguration(EntityTypeBuilder<PaymentCategory> builder)
        {
            builder.HasIndex(x => x.Name).IsUnique();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);

            builder.HasMany(x => x.PaymentTypes).WithOne(x => x.PaymentCategory).HasForeignKey(x => x.PaymentCategoryId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
