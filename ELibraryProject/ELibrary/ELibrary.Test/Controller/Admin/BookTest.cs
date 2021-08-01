using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ELibrary.Service.AdminService;
using ELibrary.Service.CommonService;
using ELibrary.Utilities.DTO;
using ELibrary.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace ELibrary.Test
{
  public class BookTest
  {
    private Mock<IBookService> _service;
    private Mock<IBookCommonService> _commonService;
    static PagingResult<BookDTO> _books = new PagingResult<BookDTO>
    {
      PageIndex = 1,
      PageSize = 7,
      Items = new List<BookDTO>{
          new BookDTO{
            Name = "Những người khốn khổ",
            Author = "Victor Hugo",
            CategoryName = new List<string>(){"novel"}
          },
          new BookDTO{
            Name = "Bắt trẻ đồng xanh ",
            Author = "J.D Salinger",
            CategoryName = null
          },
          new BookDTO{
            Name = "Ông già và biển cả",
            Author = "Emest Hemingway",
            CategoryName = null
          },
          new BookDTO{
            Name = "Cuốn theo chiều gió",
            Author = " Margaret Mitchell",
            CategoryName = new List<string>(){"novel"}
          },
          new BookDTO{
            Name = "Đồi gió hú",
            Author = "Emily Bronte",
            CategoryName = new List<string>(){"novel"}
          },
          new BookDTO{
            Name = "Chiến tranh và hòa bình",
            Author = "Nikolayevich",
            CategoryName = null
          },
          new BookDTO{
            Name = "Tiếng chim hót trong bụi mận gai",
            Author = "Colleen McCulough",
            CategoryName = new List<string>(){"novel"}
          }
        },
    };
    private static T GetObjectResultContent<T>(ActionResult<T> result)
    {
      return (T)((ObjectResult)result.Result).Value;
    }
    [SetUp]
    public void Setup()
    {
      _commonService = new Mock<IBookCommonService>();
      _service = new Mock<IBookService>();

      _commonService.Setup(service => service.View(It.IsAny<PagingRequest>())).Returns(Task.FromResult(_books));
    }

    [Test]
    public async Task BookList_ReturnListBook_WhenRequestAList()
    {
      // Arrange
      var controller = new BookController(_service.Object, _commonService.Object);
      const int pageSize = 7;
      const int pageIndex = 1;

      // Act
      var result = await controller.ViewBooks(pageSize, pageIndex);
      var resultObject = GetObjectResultContent<PagingResult<BookDTO>>(result);
      var resultType = result.Result as OkObjectResult;

      // Assert
      Assert.IsInstanceOf<OkObjectResult>(resultType);
      Assert.AreEqual(pageSize, resultObject.Items.Count);
      Assert.AreEqual(pageIndex, resultObject.PageIndex);
      Assert.AreEqual(_books.Items[0].Name, resultObject.Items[0].Name);
    }

    [Test]
    public async Task OneBookSuccess_ReturnABook_WhenRequestAnExistsBook()
    {
      // Arrange
      var controller = new BookController(_service.Object, _commonService.Object);
      Guid id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
      const string category = "novel";
      _service.Setup(service => service.FindById(id)).Returns(Task.FromResult(_books.Items[0]));

      // Act
      var result = await controller.ViewBook(id);
      var resultObject = GetObjectResultContent<BookDTO>(result);
      var resultType = result.Result as OkObjectResult;

      // Assert
      Assert.IsInstanceOf<OkObjectResult>(resultType);
      Assert.AreEqual(_books.Items[0].Name, resultObject.Name);
      Assert.AreEqual(category, resultObject.CategoryName[0]);
    }

    [Test]
    public async Task OneBookFail_ReturnABadRequest_WhenRequestAWrongBook()
    {
      // Arrange
      var controller = new BookController(_service.Object, _commonService.Object);
      Guid id = new Guid();
      _service.Setup(service => service.FindById(id)).Returns(Task.FromResult((BookDTO)null));

      // Act
      var result = await controller.ViewBook(id);
      var resultObject = GetObjectResultContent<BookDTO>(result);
      var resultType = result.Result as BadRequestObjectResult;

      // Assert
      Assert.IsInstanceOf<BadRequestObjectResult>(resultType);
      Assert.IsNull(resultObject);
    }

    [Test]
    public async Task CreateOneBookSucess_ReturnABookCreated_WhenRequestCreate()
    {
      // Arrange
      var controller = new BookController(_service.Object, _commonService.Object);
      var request = new BookDTO
      {
        Name = "book"
      };
      var response = new BookDTO
      {
        Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
        Name = "book"
      };
      _service.Setup(service => service.Add(request)).Returns(Task.FromResult((BookDTO)response));

      // Act
      var result = await controller.Create(request);
      var resultObject = GetObjectResultContent<BookDTO>(result);
      var resultType = result.Result as OkObjectResult;

      // Assert
      Assert.IsInstanceOf<OkObjectResult>(resultType);
      Assert.AreEqual(response.Id, resultObject.Id);
    }

    [Test]
    public async Task UpdateOneBookSucess_ReturnABookUpdated_WhenRequestUpdate()
    {
      // Arrange
      var controller = new BookController(_service.Object, _commonService.Object);
      var request = new BookDTO
      {
        Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
        Name = "newBook",
        CategoryID = new List<Guid> { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa8") },
        CategoryName = new List<string> { "new category" }
      };

      _service.Setup(service => service.Update(request)).Returns(Task.FromResult((BookDTO)request));

      // Act
      var result = await controller.Update(request);
      var resultObject = GetObjectResultContent<BookDTO>(result);
      var resultType = result.Result as OkObjectResult;

      // Assert
      Assert.IsInstanceOf<OkObjectResult>(resultType);
      Assert.AreEqual(request.Name, resultObject.Name);
      Assert.AreEqual(request.CategoryName, resultObject.CategoryName);
    }

    [Test]
    public async Task UpdateOneBookFail_ReturnABadRequest_WhenRequestUpdate()
    {
      // Arrange
      var controller = new BookController(_service.Object, _commonService.Object);
      var request = new BookDTO
      {
        Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
        Name = "newBook",
        CategoryID = new List<Guid> { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa8") }
      };

      _service.Setup(service => service.Update(request)).Returns(Task.FromResult((BookDTO)null));

      // Act
      var result = await controller.Update(request);
      var resultObject = GetObjectResultContent<BookDTO>(result);
      var resultType = result.Result as BadRequestObjectResult;

      // Assert
      Assert.IsInstanceOf<BadRequestObjectResult>(resultType);
      Assert.IsNull(resultObject);
    }

    [Test]
    public async Task DeleteOneBookSucess_ReturnASuccessStatus_WhenRequestDelete()
    {
      // Arrange
      var controller = new BookController(_service.Object, _commonService.Object);
      var id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
      _service.Setup(service => service.Delete(id)).Returns(Task.FromResult(true));

      // Act
      var result = await controller.Delete(id);

      // Assert
      Assert.IsInstanceOf<ActionResult>(result);
    }

    [Test]
    public async Task DeleteOneBookFail_ReturnABadRequest_WhenRequestDelete()
    {
      // Arrange
      var controller = new BookController(_service.Object, _commonService.Object);
      var id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
      _service.Setup(service => service.Delete(id)).Returns(Task.FromResult(false));

      // Act
      var result = await controller.Delete(id);

      // Assert
      Assert.IsInstanceOf<ActionResult>(result);
    }
  }
}
