using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace _26062021.Controllers
{
    public class RookieController : Controller
    {
        private readonly IPersonService _personService;

        public RookieController(IPersonService personService)
        {
            _personService = personService;
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
            var person = _personService.findOne(id);
            return View(person);
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
            var person = _personService.findOne(id);
            return View(person);
        }
    }
}