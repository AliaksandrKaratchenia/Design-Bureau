using Design_Bureau.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Design_Bureau.DAL.Configurations
{
    public class TermsOfReferenceConfiguration : IEntityTypeConfiguration<TermsOfReference>
    {
        public void Configure(EntityTypeBuilder<TermsOfReference> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).IsRequired();
        }
    }
}
