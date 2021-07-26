using System.Collections.Generic;

namespace ELibrary.Utilities.DTO
{
  public class PagingResult<T> : PagingRequest<T>
  {
    public List<T> Items { get; set; }
  }
}