using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ELibrary.WebAPI.Validation
{
  public class BorrowingBooksValidation : ValidationAttribute
  {
    private readonly int _length;

    public BorrowingBooksValidation(int length)
    {
      _length = length;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      List<Guid> strings = value as List<Guid>;
      if (strings.Count > _length)
        return new ValidationResult("You can not borrow over than five books in a request");
      return ValidationResult.Success;
    }
  }
}