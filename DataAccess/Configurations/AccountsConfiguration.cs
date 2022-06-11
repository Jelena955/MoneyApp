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
    public class AccountsConfiguration : BaseConfiguration<Accounts>
    {
        public override void SpecificConfiguration(EntityTypeBuilder<Accounts> builder)
        {
            builder.Property(x => x.CurrencyId).IsRequired();
            builder.Property(x => x.Id_User).IsRequired();

            builder.HasOne(x => x.Currency).WithMany(x => x.Accounts).HasForeignKey(x => x.CurrencyId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Money).WithOne(x => x.Account).HasForeignKey(x => x.AccountId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Payments).WithOne(x => x.Account).HasForeignKey(x => x.AccountId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
