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
    public class MoneyOnAccountConfiguration : BaseConfiguration<MoneyOnAccounts>
    {
        public override void SpecificConfiguration(EntityTypeBuilder<MoneyOnAccounts> builder)
        {
            builder.Property(x => x.Amount).IsRequired();


            builder.HasOne(x => x.Currency).WithMany(x => x.Money).HasForeignKey(x => x.CurrencyId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Account).WithMany(x => x.Money).HasForeignKey(x => x.AccountId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
