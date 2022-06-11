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
    public abstract class BaseConfiguration<Entity> : IEntityTypeConfiguration<Entity>
        where Entity : EntityBase
    {
        public void Configure(EntityTypeBuilder<Entity> builder)
        {
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        }

        public abstract void SpecificConfiguration(EntityTypeBuilder<Entity> builder);
    }
}
