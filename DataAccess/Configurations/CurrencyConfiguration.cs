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
    public class CurrencyConfiguration : BaseConfiguration<Currencys>
    {
        public override void SpecificConfiguration(EntityTypeBuilder<Currencys> builder)
        {
            builder.HasIndex(x => x.Name).IsUnique();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);

            builder.HasMany(x => x.Accounts).WithOne(x => x.Currency).HasForeignKey(x => x.CurrencyId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Payment).WithOne(x => x.Currency).HasForeignKey(x => x.CurrencyID).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Accounts).WithOne(x => x.Currency).HasForeignKey(x => x.CurrencyId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
