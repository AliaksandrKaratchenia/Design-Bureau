using Design_Bureau.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Design_Bureau.DAL.Configurations
{
    public class ChiefDesignerConfiguration : IEntityTypeConfiguration<ChiefDesigner>
    {
        public void Configure(EntityTypeBuilder<ChiefDesigner> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).IsRequired();
        }
    }
}