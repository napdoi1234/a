using System;
public class Member : Person, ICommon, IComparable<Member>
{
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

    public int CompareTo(Member other)
    {
        return this.CaculateAge().CompareTo(other.CaculateAge());
    }

    public void Print()
    {
        Console.WriteLine($"Member is {FullName} ({Age})");
    }
}