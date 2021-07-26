using System;
using System.Collections.Generic;

namespace ELibrary.Data.Entities
{
  public class BookBorrowingRequest
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    public DateTime DateRequest { get; set; }
    public string Status { get; set; }
    public string ManagerId { get; set; }
    public List<User> Users { get; set; }
    public List<BookBorrowingRequestDetails> DetailList { get; set; }
  }
}