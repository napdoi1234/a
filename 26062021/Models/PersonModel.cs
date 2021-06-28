using System;
using System.ComponentModel.DataAnnotations;

public class PersonModel
{

    public Guid Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Gender { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime DateOfBirth { get; set; }

    // At least 9 digits
    [RegularExpression(@"^\s*\+?\s*([0-9][\s-]*){9,}$", ErrorMessage = "Phone Number is not valid")]
    public string PhoneNumber { get; set; }

    public string BirthPlace { get; set; }

    public int Age
    {
        get
        {
            return CaculateAge() / 10000;
        }
    }

    public bool IsGraduated { get; set; }

    // correct form of email
    [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
    public string Email { get; set; }

    public string FullName
    {
        get
        {
            return $"{FirstName} {LastName}";
        }
    }

    public int CaculateAge()
    {
        return int.Parse(DateTime.Now.ToString("yyyyMMdd")) - int.Parse(DateOfBirth.ToString("yyyyMMdd"));
    }
}