using System;
public class Member
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string BirthPlace { get; set; }
    public int Age { 
        get{
            return int.Parse(DateTime.Now.ToString("yyyyMMdd")) - int.Parse(DateOfBirth.ToString("yyyyMMdd")) ;
        }
    }
    public bool IsGraduated { get; set; }

    public string FullName {
        get{
            return FirstName +" "+ LastName;
        }
    }
}