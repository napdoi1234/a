using System.Collections.Generic;

namespace ELibrary.Data.Entities
{
  public class Category
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Book> BookList { get; set; }
  }
}