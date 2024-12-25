using CourseWork.Data.Configuration;
using CourseWork.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.Data
{
    public class EFContext : DbContext
    {
        public DbSet<KitchenProduct> KitchenProducts { get; set; }
        public DbSet<StorageProduct> StorageProducts { get; set; }
        public DbSet<Drink> Drinks { get; set; }

        public EFContext(DbContextOptions opts) : base(opts)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new KitchenConfiguration());
            modelBuilder.ApplyConfiguration(new StorageConfiguration());
            modelBuilder.ApplyConfiguration(new DrinkConfiguration());
        }
    }
}
