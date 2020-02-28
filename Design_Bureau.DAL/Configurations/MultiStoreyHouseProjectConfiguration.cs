﻿using Design_Bureau.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Design_Bureau.DAL.Configurations
{
    public class MultiStoreyHouseProjectConfiguration : IEntityTypeConfiguration<MultiStoreyHouseProject>
    {
        public void Configure(EntityTypeBuilder<MultiStoreyHouseProject> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).IsRequired();

            builder.HasOne(p => p.TermsOfReference)
                .WithOne(t => t.MultiStoreyHouseProject)
                .HasForeignKey<MultiStoreyHouseProject>(t => t.TermsOfReferenceId);

            builder.HasOne(p => p.PriceDetails)
                .WithOne(t => t.MultiStoreyHouseProject)
                .HasForeignKey<MultiStoreyHouseProject>(d => d.PriceDetailsId);

            builder.HasOne(p => p.ChiefDesigner)
                .WithMany(t => t.MultiStoreyHouseProjects)
                .HasForeignKey(c => c.ChiefDesignerId);

            builder.HasMany(p => p.Designers)
                .WithOne(t => t.MultiStoreyHouseProject);

            builder.HasOne(p => p.Customer)
                .WithMany(t => t.MultiStoreyHouseProjects)
                .HasForeignKey(c => c.CustomerId);
        }
    }
}
