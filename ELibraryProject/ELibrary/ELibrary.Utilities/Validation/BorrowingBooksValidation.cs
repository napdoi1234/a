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
      var strings = value as List<string>;
      if (strings.Count > _length)
        return new ValidationResult("You can not borrow over than five books");
      return ValidationResult.Success;
    }
  }
}