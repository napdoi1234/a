using System;

namespace ELibrary.Data.Entities
{
  public class BookBorrowingRequestDetails
  {
    public Guid RequestId { get; set; }
    public BookBorrowingRequest Request { get; set; }
    public Guid BookId { get; set; }
    public Book Book { get; set; }
  }
}