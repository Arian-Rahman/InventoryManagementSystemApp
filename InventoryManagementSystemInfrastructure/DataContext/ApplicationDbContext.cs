using InventoryManagementSystemDomain.Entity;
using Microsoft.EntityFrameworkCore;
using Purchase = InventoryManagementSystemDomain.Entity.Purchase;

namespace InventoryManagementSystemInfrastructure.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<AppUser> AppUsers { get; set; }

        public virtual DbSet<Purchase> Purchases { get; set; }

        public virtual DbSet<PurchaseDetails> PurchasDetails { get; set; }

        //  public DbSet<Login> Logins { get; set; }
    }
}
