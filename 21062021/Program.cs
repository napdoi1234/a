using System;
using System.Collections.Generic;
using System.Linq;

namespace task1
{
    class Program
    {
        const int YEAR = 2000;
        const string LOCATION = "ha noi";
        static List<Member> members = new List<Member>{
            new Member{
                FirstName = "A",
                LastName = "Nguyen Van",
                BirthPlace = "Hai Phong",
                Gender = "male",
                DateOfBirth = new DateTime(1992,01,02),
            },
            new Member{
                FirstName = "B",
                LastName = "Nguyen Van",
                BirthPlace = "Quang Ninh",
                Gender = "Male",
                DateOfBirth = new DateTime(1992,01,01),
            },
            new Member{
                FirstName = "C",
                LastName = "Nguyen Van",
                BirthPlace = "Hai Phong",
                Gender = "male",
                DateOfBirth = new DateTime(1992,01,01),
            },
            new Member{
                FirstName = "D",
                LastName = "Nguyen Van",
                BirthPlace = "Ha Noi",
                Gender = "Female",
                DateOfBirth = new DateTime(2001,12,02),
            },
            new Member{
                FirstName = "E",
                LastName = "Nguyen Van",
                BirthPlace = "ha noi",
                Gender = "Male",
                DateOfBirth = new DateTime(1993,07,02),
            },
            new Member{
                FirstName = "F",
                LastName = "Nguyen Van",
                BirthPlace = "Ha Noi",
                Gender = "Male",
                DateOfBirth = new DateTime(2000,01,02),
            },
            new Member{
                FirstName = "G",
                LastName = "Nguyen Van",
                BirthPlace = "Hai Phong",
                Gender = "Female",
                DateOfBirth = new DateTime(2000,01,02),
            },
        };

        public static void PrintList(List<Member> members)
        {
            members.ForEach(x => x.Print());
        }

        //BR1
        public static void PrintMaleList(List<Member> members)
        {
            var maleList = members.Where(x => x.Gender.Equals("Male", StringComparison.CurrentCultureIgnoreCase)).ToList();
            PrintList(maleList);
        }

        //BR2
        public static void FindOldestMember(List<Member> members)
        {
            if (members.Count() != 0)
            {
                Console.WriteLine("The first oldest : ");
                members.Max().Print();
            }

        }

        //BR3
        public static void PrintFullName(List<Member> members)
        {
            var fullName = members.Select(x => x.FullName);
            Console.WriteLine(string.Join("\n", fullName));
        }

        //BR4
        public static void PrintSplitMemberByAge(List<Member> members, int year)
        {
            var greaterList = members.Where(x => x.DateOfBirth.Year > 2000).ToList();
            var lessList = members.Where(x => x.DateOfBirth.Year < 2000).ToList();
            var equalList = members.Where(x => x.DateOfBirth.Year == 2000).ToList();

            Console.WriteLine($"People who was born before {year} : ");
            PrintList(lessList);
            Console.WriteLine($"People who was born in {year} : ");
            PrintList(equalList);
            Console.WriteLine($"People who was born after {year} : ");
            PrintList(greaterList);
        }

        //BR5
        public static void PrintMemberByLocation(List<Member> members, string location)
        {
            var locationMember = members.Where(x => x.BirthPlace.Equals(location, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            if (locationMember != null){
                Console.WriteLine($"People live in {location} :");
                locationMember.Print();
            }
                
            else Console.WriteLine($"Nobody was born in {location}");
        }

        static void Main(string[] args)
        {
            //BR1
            //PrintMaleList(members);

            //BR2
            // FindOldestMember(members);

            //BR3
            // PrintFullName(members);

            //BR4
            //PrintSplitMemberByAge(members,YEAR);

            //BR5
            //PrintMemberByLocation(members, LOCATION);
        }
    }
}
