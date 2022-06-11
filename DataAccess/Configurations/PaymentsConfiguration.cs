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
    public class PaymentsConfiguration : BaseConfiguration<Payments>
    {
        public override void SpecificConfiguration(EntityTypeBuilder<Payments> builder)
        {
            builder.Property(x => x.Amount).IsRequired();

            builder.HasOne(x => x.PaymentType).WithMany(x => x.Payments).HasForeignKey(x => x.PaymentTypeId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Account).WithMany(x => x.Payments).HasForeignKey(x => x.AccountId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Currency).WithMany(x => x.Payment).HasForeignKey(x => x.CurrencyID).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
