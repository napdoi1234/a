using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ELibrary.Data.Entities
{
  public class User : IdentityUser
  {
    public string FullName { get; set; }
    public DateTime Dob { get; set; }
    public List<BookBorrowingRequest> RequestList { get; set; }
  }
}