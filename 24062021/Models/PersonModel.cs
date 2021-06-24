using System;

public class PersonModel : IComparable<PersonModel>{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string BirthPlace { get; set; }
    public int Age { 
        get{
            return CaculateAge()/10000;
        }
    }
    public bool IsGraduated { get; set; }

    public string FullName {
        get{
            return $"{FirstName} {LastName}";
        }
    }

    public int CaculateAge()
    {
        return int.Parse(DateTime.Now.ToString("yyyyMMdd")) - int.Parse(DateOfBirth.ToString("yyyyMMdd")) ;
    }

    public int CompareTo(PersonModel other)
    {
        return this.CaculateAge().CompareTo(other.CaculateAge());
    }
}