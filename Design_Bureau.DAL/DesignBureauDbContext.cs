using Design_Bureau.DAL.Configurations;
using Design_Bureau.Entities;
using Microsoft.EntityFrameworkCore;

namespace Design_Bureau.DAL
{
    public class DesignBureauDbContext : DbContext
    {
        public DesignBureauDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<MultiStoreyHouseProject> MultiStoreyHouseProjects { get; set; }

        public DbSet<TermsOfReference> TermsOfReferences { get; set; }

        public DbSet<PriceDetails> PriceDetails { get; set; }

        public DbSet<Designer> Designers { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<ChiefDesigner> ChiefDesigners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MultiStoreyHouseProjectConfiguration());
            modelBuilder.ApplyConfiguration(new TermsOfReferenceConfiguration());
            modelBuilder.ApplyConfiguration(new PriceDetailsConfiguration());
            modelBuilder.ApplyConfiguration(new DesignerConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new ChiefDesignerConfiguration());
        }
    }
}
