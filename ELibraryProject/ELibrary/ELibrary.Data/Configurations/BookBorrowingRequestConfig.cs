using ELibrary.Data.Entities;
using Microsoft.EntityFrameworkCore;
using ELibrary.Utilities.Constants.BookBorrowing;

namespace ELibrary.Data.Configurations
{
  public class BookBorrowingRequestConfig : IEntityTypeConfiguration<BookBorrowingRequest>
  {
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<BookBorrowingRequest> builder)
    {
      builder.HasKey(x => x.Id);

      builder.Property(x => x.Status).HasDefaultValue(BorrowConstant.WaittingStatus);

      builder.HasMany(x => x.DetailList);

      builder.HasMany(x => x.Users);
    }
  }
}