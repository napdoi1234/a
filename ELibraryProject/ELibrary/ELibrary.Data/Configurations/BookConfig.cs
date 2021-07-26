using ELibrary.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELibrary.Data.Configurations
{
  public class BookConfig : IEntityTypeConfiguration<Book>
  {
    public void Configure(EntityTypeBuilder<Book> builder)
    {
      builder.HasKey(x => x.Id);

      builder.Property(x => x.Id).UseIdentityColumn();

      builder.Property(x => x.Name).IsRequired();

      builder.HasMany(x => x.CategoryList);

      builder.HasMany(x => x.RequestDetailList);
    }
  }
}