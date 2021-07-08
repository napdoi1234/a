using NUnit.Framework;
using _26062021.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace _26062021Tests
{
    public class RookieControllerTest
    {
        static List<PersonModel> _members = new List<PersonModel>{
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
        };

        private ILogger<RookieController> _logger;
        private Mock<IPersonService> _service;

        [SetUp]
        public void Setup()
        {
            _logger = Mock.Of<ILogger<RookieController>>();

            _service = new Mock<IPersonService>();
            _service.Setup(service => service.GetAll()).Returns(_members);
        }

        [Test]
        public void ViewList_ReturnViewListPerson_WhenRequestAList()
        {
            // Arrange
            var controller = new RookieController(_service.Object, _logger);
            const int count = 6;

            // Act
            var result = controller.ViewList();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsAssignableFrom<List<PersonModel>>(((ViewResult)result).ViewData.Model);
            Assert.AreEqual(count, ((List<PersonModel>)((ViewResult)result).ViewData.Model).Count);
        }

        [Test]
        public void CreatePerson_ReturnViewFail_WhenModelIsInValid()
        {
            // Arrange
            const string message = "some error";
            var controller = new RookieController(_service.Object, _logger);
            controller.ModelState.AddModelError("error", message);


            // Act
            var result = controller.Create(null);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsNull(((ViewResult)result).ViewData.Model);
            Assert.AreEqual("Fail", ((ViewResult)result).ViewName);
        }

        [Test]
        public void CreatePerson_ReturnViewList_WhenModelIsValid()
        {
            // Arrange
            var controller = new RookieController(_service.Object, _logger);
            var person = new PersonModel
            {
                FirstName = "G",
                LastName = "Nguyen Van",
                BirthPlace = "Hai Phong",
                Gender = "Female",
                DateOfBirth = new DateTime(2000, 01, 02),
                PhoneNumber = "1234567893",
            };

            // Act
            var result = controller.Create(person) as RedirectToActionResult;

            // Assert
            Assert.IsNull(result.ControllerName);
            Assert.AreEqual("ViewList", result.ActionName);
        }

        //Same as Detail action
        [Test]
        public void EditPerson_ReturnAPerson_WhenSendIdPerson()
        {
            // Arrange
            var controller = new RookieController(_service.Object, _logger);
            Guid id = new Guid("b43021a7-8a20-445f-9948-90522286e9a0");
            _service.Setup(service => service.FindOne(id)).Returns(_members.First());
            const string firstName = "A";

            // Act
            var result = controller.Edit(id);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsAssignableFrom<PersonModel>(((ViewResult)result).ViewData.Model);
            Assert.AreEqual(firstName, ((PersonModel)((ViewResult)result).ViewData.Model).FirstName);
        }

        [Test]
        public void EditPerson_ReturnViewFail_WhenSendIncorrectIdPerson()
        {
            // Arrange
            var controller = new RookieController(_service.Object, _logger);
            Guid id = new Guid("b43021a7-8a20-445f-9948-90522286e9a1");
            _service.Setup(service => service.FindOne(id)).Returns((PersonModel)null);

            // Act
            var result = controller.Edit(id);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsNull(((ViewResult)result).ViewData.Model);
            Assert.AreEqual("Fail", ((ViewResult)result).ViewName);
        }

        [Test]
        public void UpdatePerson_ReturnViewList_WhenModelIsValid()
        {
            // Arrange
            var controller = new RookieController(_service.Object, _logger);
            var person = new PersonModel
            {
                Id = new Guid("b43021a7-8a20-445f-9948-90522286e9a1"),
                FirstName = "G",
                LastName = "Nguyen Van",
                BirthPlace = "Hai Phong",
                Gender = "Female",
                DateOfBirth = new DateTime(2000, 01, 02),
                PhoneNumber = "1234567893",
            };

            // Act
            var result = controller.Edit(person) as RedirectToActionResult;

            // Assert
            Assert.IsNull(result.ControllerName);
            Assert.AreEqual("ViewList", result.ActionName);
        }

        [Test]
        public void UpdatePerson_ReturnViewFail_WhenModelIsInvalid()
        {
            // Arrange
            const string message = "some error";
            var controller = new RookieController(_service.Object, _logger);
            controller.ModelState.AddModelError("error", message);


            // Act
            var result = controller.Edit(null);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsNull(((ViewResult)result).ViewData.Model);
            Assert.AreEqual("Fail", ((ViewResult)result).ViewName);
        }

        [Test]
        public void DeletePerson_ReturnViewConfirm_WhenModelPersonExist()
        {
            // Arrange
            var controller = new RookieController(_service.Object, _logger);
            Guid id = new Guid("b43021a7-8a20-445f-9948-90522286e9a0");
            _service.Setup(service => service.Delete(id)).Returns(_members.First().FullName);
            const string fullName = "A Nguyen Van";
            
            Mock<HttpContext> mockHttpContext = new Mock<HttpContext>();
            MockSession mockSession = new MockSession();           
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            controller.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var result = controller.Delete(id);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual("ConfirmDelete", ((ViewResult)result).ViewName);
            string name = controller.ControllerContext.HttpContext.Session.GetString("FullName");
            Assert.AreEqual(fullName, name);
        }

        [Test]
        public void DeletePerson_ReturnViewFail_WhenModelPersonNotExist()
        {
            // Arrange
            var controller = new RookieController(_service.Object, _logger);
            Guid id = new Guid("b43021a7-8a20-445f-9948-90522286e9a0");
            _service.Setup(service => service.Delete(id)).Returns(string.Empty);
            Mock<HttpContext> mockHttpContext = new Mock<HttpContext>();
            MockSession mockSession = new MockSession();           
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            controller.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var result = controller.Delete(id);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsNull(((ViewResult)result).ViewData.Model);
            Assert.AreEqual("Fail", ((ViewResult)result).ViewName);
        }
    }
}