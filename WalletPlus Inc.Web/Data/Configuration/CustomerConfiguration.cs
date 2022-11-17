using Microsoft.EntityFrameworkCore;
using WalletPlus_Inc.Web.Data.Entities;

namespace WalletPlus_Inc.Web.Data.Configuration
{
    public class CustomerConfiguration
    {
        public static ModelBuilder Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Property(c => c.FirstName).IsRequired(true).HasMaxLength(100);
            modelBuilder.Entity<Customer>().Property(c => c.MiddleName).HasMaxLength(100);
            modelBuilder.Entity<Customer>().Property(c => c.LastName).IsRequired(true).HasMaxLength(100);

            return modelBuilder;
        }
    }
}
