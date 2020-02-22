using Design_Bureau.BLL.Authentication__Authorization.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Design_Bureau.DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Password).IsRequired();
            builder.Property(a => a.Username).IsRequired();
            builder.Property(a => a.Role).IsRequired();
        }
    }
}
