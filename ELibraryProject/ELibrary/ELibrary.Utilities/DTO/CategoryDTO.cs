using System;

namespace ELibrary.Utilities.DTO
{
  public class CategoryDTO : PagingRequest
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
  }
}