using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace _26062021.Controllers
{
    public class RookieController : Controller
    {
        private readonly IPersonService _personService;

        private ILogger<RookieController> _logger;

        public RookieController(IPersonService personService, ILogger<RookieController> logger)
        {
            _personService = personService;
            _logger = logger;
        }

        public IActionResult ViewList()
        {
            var list = _personService.GetAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("FirstName", "LastName", "Gender", "DateOfBirth", "PhoneNumber", "BirthPlace", "IsGraduated", "Email")] PersonModel person)
        {
            if (ModelState.IsValid)
            {
                _personService.Create(person);
                return RedirectToAction(nameof(ViewList));
            }
            return View("Fail");
        }

        public IActionResult Edit(Guid id)
        {
            var person = _personService.FindOne(id);
            if(person != null)
                return View(person);
            return View("Fail");
        }

        [HttpPost]
        public IActionResult Edit([Bind("Id", "FirstName", "LastName", "Gender", "DateOfBirth", "PhoneNumber", "BirthPlace", "IsGraduated", "Email")] PersonModel person)
        {
            if (ModelState.IsValid)
            {
                _personService.Update(person);
                return RedirectToAction(nameof(ViewList));
            }
            return View("Fail");
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var fullName = _personService.Delete(id);
            var session = HttpContext.Session;
            if (fullName != string.Empty)
            {
                session.SetString("FullName", fullName);
                return View("ConfirmDelete");
            }
            return View("Fail");
        }

        public IActionResult ComfirmDelete()
        {
            return View();
        }

        public IActionResult Detail(Guid id)
        {
            var person = _personService.FindOne(id);
            if(person != null)
                return View(person);
            return View("Fail");
        }
    }
}