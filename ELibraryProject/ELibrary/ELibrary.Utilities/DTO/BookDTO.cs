using System.Collections.Generic;

namespace ELibrary.Utilities.DTO
{
  public class BookDTO : PagingRequest<BookDTO>
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public List<int> CategoryID { get; set; }
  }
}