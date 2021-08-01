using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ELibrary.Service.CommonService;
using ELibrary.Service.NormalService;
using ELibrary.Utilities.DTO;
using ELibrary.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace ELibrary.Test.Controller.Normal
{
  public class BorrowBookTest
  {
    private Mock<IBorrowingBookService> _service;
    private Mock<IBookCommonService> _commonService;
    private Mock<ClaimsIdentity> _identity;
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

    static PagingResult<BookBorrowingRequestDTO> _borrowBook = new PagingResult<BookBorrowingRequestDTO>
    {
      PageIndex = 1,
      PageSize = 4,
      Items = new List<BookBorrowingRequestDTO>{
        new BookBorrowingRequestDTO{
          Id = new Guid(),
          UserId = "1",
          UserName = "van",
          DateRequest = DateTime.Now,
          Status = "Waitting",
          IdBooks = new List<Guid>{new Guid()},
          NameBook = "nav"
        },
        new BookBorrowingRequestDTO{
          Id = new Guid(),
          UserId = "2",
          UserName = "van2",
          DateRequest = DateTime.Now,
          Status = "Waitting",
          IdBooks = new List<Guid>{new Guid()},
          NameBook = "nav2"
        },
        new BookBorrowingRequestDTO{
          Id = new Guid(),
          UserId = "3",
          UserName = "van3",
          DateRequest = DateTime.Now,
          Status = "Waitting",
          IdBooks = new List<Guid>{new Guid()},
          NameBook = "nav3"
        },
        new BookBorrowingRequestDTO{
          Id = new Guid(),
          UserId = "1",
          UserName = "van",
          DateRequest = DateTime.Now,
          Status = "Waitting",
          IdBooks = new List<Guid>{new Guid()},
          NameBook = "nav2"
        }
      }
    };
    private static T GetObjectResultContent<T>(ActionResult<T> result)
    {
      return (T)((ObjectResult)result.Result).Value;
    }
    [SetUp]
    public void Setup()
    {
      _commonService = new Mock<IBookCommonService>();
      _service = new Mock<IBorrowingBookService>();

      _commonService.Setup(service => service.View(It.IsAny<PagingRequest>())).Returns(Task.FromResult(_books));
    }

    [Test]
    public async Task BookList_ReturnListBook_WhenRequestAList()
    {
      // Arrange
      var controller = new BorrowingBooksController(_service.Object, _commonService.Object);
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
    public async Task ViewBorrowedBooks_ReturnListBook_WhenRequestAList()
    {
      // Arrange
      var controller = new BorrowingBooksController(_service.Object, _commonService.Object);
      const int pageSize = 4;
      const int pageIndex = 1;
      _identity = new Mock<ClaimsIdentity>();
      // _identity.Setup(service => service.FindFirst(ClaimTypes.UserData)).Returns(new Claim{Type:ClaimTypes.UserData ,Value:"1"});
      _service.Setup(service => service.ViewBorrowedBooks(It.IsAny<BookBorrowingRequestDTO>())).Returns(Task.FromResult(_borrowBook));

      // Act
      var result = await controller.ViewBorrowedBooks(pageSize, pageIndex);
      var resultObject = GetObjectResultContent<PagingResult<BookBorrowingRequestDTO>>(result);
      var resultType = result.Result as OkObjectResult;

      // Assert
      Assert.IsInstanceOf<OkObjectResult>(resultType);
      Assert.AreEqual(pageSize, resultObject.Items.Count);
      Assert.AreEqual(pageIndex, resultObject.PageIndex);
      Assert.AreEqual(_borrowBook.Items[0].NameBook, resultObject.Items[0].NameBook);
    }
  }
}