namespace ELibrary.Data.Entities
{
  public class BookBorrowingRequestDetails
  {
    public int RequestId { get; set; }
    public BookBorrowingRequest Request { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; }
  }
}