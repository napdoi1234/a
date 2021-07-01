using Microsoft.EntityFrameworkCore;
namespace EF1.Models
{
    public class EFCoreContext : DbContext
    {
        public EFCoreContext(DbContextOptions<EFCoreContext> options) : base(options)
        {
        }
        public DbSet<StudentModel> Students { get; set; }
    }
}