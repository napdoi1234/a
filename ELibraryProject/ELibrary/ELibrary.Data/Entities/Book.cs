using System;
using System.Collections.Generic;

namespace ELibrary.Data.Entities
{
  public class Book
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public List<Category> CategoryList { get; set; }
    public List<BookBorrowingRequestDetails> RequestDetailList { get; set; }
  }
}