using ELibrary.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELibrary.Data.Configurations
{
  public class CategoryConfig : IEntityTypeConfiguration<Category>
  {
    public void Configure(EntityTypeBuilder<Category> builder)
    {
      builder.HasKey(x => x.Id);

      builder.Property(x => x.Id).UseIdentityColumn();

      builder.HasMany(x => x.BookList);
    }
  }
}