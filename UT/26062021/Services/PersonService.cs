using System;
using System.Collections.Generic;
using System.Linq;

namespace _26062021.Services
{
    public class PersonService : IPersonService
    {
        static List<PersonModel> members = new List<PersonModel>{
            new PersonModel{
                Id = new Guid("b43021a7-8a20-445f-9948-90522286e9a0"),
                FirstName = "A",
                LastName = "Nguyen Van",
                BirthPlace = "Hai Phong",
                Gender = "male",
                DateOfBirth = new DateTime(1992,01,02),
            },
            new PersonModel{
                Id = new Guid("de7ee905-b823-4c8f-8977-0b80e110cfbd"),
                FirstName = "B",
                LastName = "Nguyen Van",
                BirthPlace = "Quang Ninh",
                Gender = "Male",
                DateOfBirth = new DateTime(1992,01,01),
            },
            new PersonModel{
                Id = new Guid("8e61248e-9c86-44f4-9165-86efd0f18d67"),
                FirstName = "C",
                LastName = "Nguyen Van",
                BirthPlace = "Hai Phong",
                Gender = "male",
                DateOfBirth = new DateTime(1992,01,01),
            },
            new PersonModel{
                Id = new Guid("e9fd825a-58ca-4f26-9d0d-8e184d6bf6f2"),
                FirstName = "D",
                LastName = "Nguyen Van",
                BirthPlace = "Ha Noi",
                Gender = "Female",
                DateOfBirth = new DateTime(2001,12,02),
            },
            new PersonModel{
                Id = new Guid("e0ae2d15-7d3a-4cd9-9546-7ab7a474700b"),
                FirstName = "E",
                LastName = "Nguyen Van",
                BirthPlace = "ha noi",
                Gender = "Male",
                DateOfBirth = new DateTime(1993,07,02),
            },
            new PersonModel{
                Id = new Guid("e9cc5b59-14d0-48f2-8b99-c06a38d4954d"),
                FirstName = "F",
                LastName = "Nguyen Van",
                BirthPlace = "Ha Noi",
                Gender = "Male",
                DateOfBirth = new DateTime(2000,01,02),
            },
            new PersonModel{
                Id = new Guid("05faa4ba-9b12-43a5-bdf3-d2a4d4d2e05e"),
                FirstName = "G",
                LastName = "Nguyen Van",
                BirthPlace = "Hai Phong",
                Gender = "Female",
                DateOfBirth = new DateTime(2000,01,02),
            },
        };
        public void Create(PersonModel person)
        {
            person.Id = new Guid();
            members.Add(person);
        }

        public string Delete(Guid id)
        {
            var findPerson = members.FindIndex(x => x.Id == id); 
            string result = string.Empty;
            if (findPerson != -1)
            {
                result = members[findPerson].FullName;
                members.RemoveAt(findPerson);
            }
            return result;
        }

        public PersonModel FindOne(Guid id)
        {
            var person = members.FirstOrDefault(x => x.Id == id);
            return person;
        }

        public List<PersonModel> GetAll()
        {
            return members;
        }

        public void Update(PersonModel person)
        {
            var findPerson = members.FindIndex(x => x.Id == person.Id);
            if (findPerson != -1)
            {
                members[findPerson] = person;
            }
        }
    }
}