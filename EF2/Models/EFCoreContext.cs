using Microsoft.EntityFrameworkCore;

namespace EF2.Models
{
    public class EFCoreContext : DbContext
    {
        public EFCoreContext(DbContextOptions<EFCoreContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryModel>().HasMany(c => c.Products).WithOne(p => p.Category);
            modelBuilder.Entity<CategoryModel>().HasData(new CategoryModel
            {
                CategoryId = 1,
                CategoryName = "Category1",
            });
            modelBuilder.Entity<ProductModel>().HasData(new ProductModel
            {
                CategoryId = 1,
                ProductId = 1,
                ProductName = "product1"
            });
            
        }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ProductModel> Products { get; set; }
    }
}