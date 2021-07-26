using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ELibrary.WebAPI.Validation;

namespace ELibrary.Utilities.DTO
{
  public class BookBorrowingRequestDTO : PagingRequest<BookBorrowingRequestDTO>
  {
    public int Id { get; set; }
    [Required]
    public string UserId { get; set; }
    public string UserName { get; set; }
    public DateTime DateRequest { get; set; }
    public string Status { get; set; }
    [BorrowingBooksValidation(5)]
    public List<int> IdBooks { get; set; }
    public string NameBook { get; set; }
    public string Message { get; set; }
  }
}