using System;
using System.Collections.Generic;

namespace task1
{
    class Program
    {
        static Member[] members = {
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
        static void Main(string[] args)
        {
            #region BR1

            // List<Member> maleList = new List<Member>();

            // for (int i = 0; i < members.Length; i++)
            // {
            //     if(members[i].Gender.Equals("Male",StringComparison.CurrentCultureIgnoreCase)){
            //         maleList.Add(members[i]);
            //     }
            // }

            // maleList.ForEach(x=>Console.WriteLine(x.FullName));

            #endregion

            #region BR2

            // var oldest = members[0];

            // for (int i = 1; i < members.Length; i++)
            // {
            //     if(oldest.Age < members[i].Age){
            //         oldest = members[i];
            //     }
            // }

            // Console.WriteLine("Nguoi co so tuoi lon nhat dau tien la "+oldest.FirstName+" "+oldest.LastName+"( "+oldest.Age.ToString().Substring(0,2)+" )");
            #endregion

            #region BR3

            // var fullNameList = new List<string>();

            // for (int i = 0; i < members.Length; i++)
            // {
            //     fullNameList.Add(members[i].FullName);
            // }

            // fullNameList.ForEach(x=>Console.WriteLine(x));

            #endregion

            #region BR4

            // var equalList = new List<Member>();
            // var greaterList = new List<Member>();
            // var lessList = new List<Member>();

            // for (int i = 0; i < members.Length; i++)
            // {
            //     switch(members[i].DateOfBirth.Year){
            //         case 2000 : 
            //             equalList.Add(members[i]);
            //             break;
            //         case var birth when birth < 2000 :
            //             lessList.Add(members[i]);
            //             break;
            //         case var birth when birth > 2000 :
            //             greaterList.Add(members[i]);
            //             break;
            //     };

            // }

            // Console.WriteLine("Nhung nguoi sinh truoc 2000 :");
            // lessList.ForEach(x=>Console.WriteLine(x.FullName));

            // Console.WriteLine("Nhung nguoi sinh nam 2000 :");
            // equalList.ForEach(x=> Console.WriteLine(x.FullName));

            // Console.WriteLine("Nhung nguoi sinh sau nam 2000 : ");
            // greaterList.ForEach(x=> Console.WriteLine(x.FullName));

            #endregion

            #region BR5

            // var hanoiList = new List<Member>();
            // int index = 0;

            // while (true)
            // {
            //     if (index < members.Length)
            //     {
            //         if (members[index].BirthPlace.Equals("Ha Noi", StringComparison.CurrentCultureIgnoreCase))
            //         {
            //             Console.WriteLine(members[index].FullName + " la nguoi sinh o Ha Noi");
            //             break;
            //         }
            //         else
            //         {
            //             index++;
            //         }
            //     }
            //     else
            //     {
            //         Console.WriteLine("Khong co ai song o Ha Noi");
            //         break;
            //     }
            // }
            #endregion
        }
    }
}
