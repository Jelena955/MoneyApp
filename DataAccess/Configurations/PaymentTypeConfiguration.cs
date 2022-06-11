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
    public class PaymentTypeConfiguration : BaseConfiguration<PaymentType>
    {
        public override void SpecificConfiguration(EntityTypeBuilder<PaymentType> builder)
        {
            builder.HasIndex(x => x.Name).IsUnique();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);

            builder.HasMany(x => x.Payments).WithOne(x => x.PaymentType).HasForeignKey(x => x.PaymentTypeId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.PaymentCategory).WithMany(x => x.PaymentTypes).HasForeignKey(x => x.PaymentCategoryId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
