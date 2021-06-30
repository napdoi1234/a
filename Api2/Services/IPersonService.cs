using System.Collections.Generic;
using Api2.Models;
namespace Api2.Services
{
    public interface IPersonService
    {
        PersonModel Create(PersonModel person);
        bool Delete(int id);
        PersonModel Update(PersonModel person);
        List<PersonModel> SearchPerson(PersonFilterModel personFilter);
    }
}
