using Design_Bureau.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Bureau.DAL.Configurations
{
    public class PriceDetailsConfiguration : IEntityTypeConfiguration<PriceDetails>
    {
        public void Configure(EntityTypeBuilder<PriceDetails> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.ConstructionCost).IsRequired();
            builder.Property(a => a.DesignCost).IsRequired();
        }
    }
}
