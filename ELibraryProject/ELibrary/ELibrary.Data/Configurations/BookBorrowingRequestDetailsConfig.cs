using ELibrary.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELibrary.Data.Configurations
{
  public class BookBorrowingRequestDetailsConfig : IEntityTypeConfiguration<BookBorrowingRequestDetails>
  {
    public void Configure(EntityTypeBuilder<BookBorrowingRequestDetails> builder)
    {
      builder.HasKey(x => new { x.BookId, x.RequestId });
    }
  }
}