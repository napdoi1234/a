using Microsoft.EntityFrameworkCore;

namespace _29062021.Models
{
    public class SampleWebApiContext : DbContext
    {
        public SampleWebApiContext(DbContextOptions<SampleWebApiContext> options)
            : base(options)
        {
        }
  
        public DbSet<TaskModel> Tasks { get; set; }
    }
}
