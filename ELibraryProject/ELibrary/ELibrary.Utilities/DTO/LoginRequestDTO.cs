using System;
using System.ComponentModel.DataAnnotations;

namespace ELibrary.Utilities.DTO
{
  public class LoginRequestDTO
  {
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
  }
}