using Microsoft.AspNetCore.Mvc;

namespace Api2.Models
{
    [BindProperties]
    public class PersonFilterModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string BirthPlace { get; set; }
    }
}