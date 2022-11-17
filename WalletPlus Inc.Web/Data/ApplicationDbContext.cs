using Microsoft.EntityFrameworkCore;
using WalletPlus_Inc.Web.Data.Configuration;
using WalletPlus_Inc.Web.Data.Entities;

namespace WalletPlus_Inc.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)

        {

        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CustomerConfiguration.Build(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
