using Api2.Models;
using Api2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api2.Controllers
{
    [ApiController]
    [Route("api/rookies")]
    public class RookiesController : ControllerBase
    {
        private readonly IPersonService _personService;

        public RookiesController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost("person")]
        public ActionResult<PersonModel> NewPerson([Bind("FirstName", "LastName", "DateOfBirth", "Gender", "BirthPlace")] PersonModel model)
        {
            var person = _personService.Create(model);
            return Ok(person);
        }

        [HttpPut("person")]
        public PersonModel FixedPerson(PersonModel model)
        {
            var person = _personService.Update(model);
            if (person != null)
            {
                return person;
            }
            return null;
        }

        [HttpDelete("person/{id}")]
        public ActionResult<bool> RemovedPerson(int id)
        {
            var result = _personService.Delete(id);
            return result;
        }

        [HttpGet("person-list")]
        public ActionResult PersonList([FromQuery] PersonFilterModel personFilter)
        {
            var personList = _personService.SearchPerson(personFilter);
            return Ok(personList);
        }
    }
}