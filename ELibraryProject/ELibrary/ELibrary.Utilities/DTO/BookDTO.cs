using System;
using System.Collections.Generic;

namespace ELibrary.Utilities.DTO
{
  public class BookDTO : PagingRequest
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public List<Guid> CategoryID { get; set; }
    public List<string> CategoryName { get; set; }
  }
}