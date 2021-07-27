using System;

namespace ELibrary.Utilities.DTO
{
  public class BookConfirmRequestDTO
  {
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public string Status { get; set; }
  }
}