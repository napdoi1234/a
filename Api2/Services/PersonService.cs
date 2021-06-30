using System;
using System.Collections.Generic;
using System.Linq;
using Api2.Models;

namespace Api2.Services
{
    public class PersonService : IPersonService
    {
        static List<PersonModel> members = new List<PersonModel>{
            new PersonModel{
                Id = 0,
                FirstName = "A",
                LastName = "Nguyen Van",
                BirthPlace = "Hai Phong",
                Gender = "male",
                DateOfBirth = new DateTime(1992,01,02),
            },
            new PersonModel{
                Id = 1,
                FirstName = "B",
                LastName = "Nguyen Van",
                BirthPlace = "Quang Ninh",
                Gender = "Male",
                DateOfBirth = new DateTime(1992,01,01),
            },
            new PersonModel{
                Id = 2,
                FirstName = "C",
                LastName = "Nguyen Van",
                BirthPlace = "Hai Phong",
                Gender = "male",
                DateOfBirth = new DateTime(1992,01,01),
            },
            new PersonModel{
                Id = 3,
                FirstName = "D",
                LastName = "Nguyen Van",
                BirthPlace = "Ha Noi",
                Gender = "Female",
                DateOfBirth = new DateTime(2001,12,02),
            },
            new PersonModel{
                Id = 4,
                FirstName = "E",
                LastName = "Nguyen Van",
                BirthPlace = "ha noi",
                Gender = "Male",
                DateOfBirth = new DateTime(1993,07,02),
            },
            new PersonModel{
                Id = 5,
                FirstName = "F",
                LastName = "Nguyen Van",
                BirthPlace = "Ha Noi",
                Gender = "Male",
                DateOfBirth = new DateTime(2000,01,02),
            },
            new PersonModel{
                Id = 6,
                FirstName = "G",
                LastName = "Nguyen Van",
                BirthPlace = "Hai Phong",
                Gender = "Female",
                DateOfBirth = new DateTime(2000,01,02),
            },
        };

        public PersonModel Create(PersonModel person)
        {
            person.Id = members.Count;
            members.Add(person);
            return person;
        }

        public bool Delete(int id)
        {
            var person = FindOne(id);
            if (person != null)
            {
                members.Remove(person);
                return true;
            }
            return false;
        }

        public List<PersonModel> FindByBirthPlace(string birthPlace)
        {
            var personList = members.Where(x => x.BirthPlace.Equals(birthPlace, StringComparison.CurrentCultureIgnoreCase)).ToList();
            return personList;
        }

        public List<PersonModel> FindByGender(string gender)
        {
            var personList = members.Where(x => x.Gender.Equals(gender, StringComparison.CurrentCultureIgnoreCase)).ToList();
            return personList;
        }

        public List<PersonModel> FindByName(string name)
        {
            var personList = members.Where(x => x.FirstName.Equals(name) || x.LastName.Equals(name)
            || ($"{x.FirstName } {x.LastName}").Equals(name)).ToList();
            return personList;
        }

        public List<PersonModel> SearchPerson(PersonFilterModel personFilter)
        {
            string lastName = personFilter.LastName;
            string firstName = personFilter.FirstName;
            string birthPlace = personFilter.BirthPlace;
            string gender = personFilter.Gender;
            return members.Where(x => (!string.IsNullOrEmpty(lastName) && x.LastName.Equals(lastName)) ||
                                      (!string.IsNullOrEmpty(firstName) && x.FirstName.Equals(firstName)) ||
                                      (!string.IsNullOrEmpty(birthPlace) && x.BirthPlace.Equals(birthPlace, StringComparison.CurrentCultureIgnoreCase)) ||
                                      (!string.IsNullOrEmpty(gender) && x.Gender.Equals(gender, StringComparison.CurrentCultureIgnoreCase))).ToList();
        }

        public PersonModel Update(PersonModel model)
        {
            var person = FindOne(model.Id);
            if (person != null)
            {
                var index = members.IndexOf(person);
                members[index] = model;
            }
            return person;
        }
        private PersonModel FindOne(int id)
        {
            var person = members.FirstOrDefault(x => x.Id == id);
            return person;
        }
    }
}