using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ELibrary.Data.EF
{
  public class ELibraryDbContextFactory : IDesignTimeDbContextFactory<ELibraryDbContext>
  {
    public ELibraryDbContext CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json")
                .Build();

      var connectionString = configuration.GetConnectionString("ELibrary");

      var optionsBuilder = new DbContextOptionsBuilder<ELibraryDbContext>();
      optionsBuilder.UseSqlServer(connectionString);

      return new ELibraryDbContext(optionsBuilder.Options);
    }
  }
}