using ELibrary.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELibrary.Data.Configurations
{
  public class UserConfig : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.Property(x => x.FullName).IsRequired().HasMaxLength(200);

      builder.HasMany(x => x.RequestList);
    }
  }
}