using System.Threading.Tasks;
using ELibrary.Service.CommonService;
using ELibrary.Service.NormalService;
using ELibrary.Utilities.Constants.User;
using ELibrary.Utilities.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.WebAPI.Controllers
{
  [ApiController]
  [Route("api/books")]
  [Authorize(Roles = UserConstant.NormalRole)]
  public class BorrowingBooksController : ControllerBase
  {
    private readonly IBorrowingBookService _bBookService;
    private readonly IBookService _bookService;
    public BorrowingBooksController(IBorrowingBookService bBookService, IBookService bookService)
    {
      _bBookService = bBookService;
      _bookService = bookService;
    }

    [HttpPost("borrowed_books")]
    public async Task<ActionResult<PagingResult<BookBorrowingRequestDTO>>> ViewBorrowedBooks(BookBorrowingRequestDTO requestDTO)
    {
      return Ok(await _bBookService.ViewBorrowedBooks(requestDTO));
    }

    [HttpPost]
    public async Task<ActionResult<PagingResult<BookDTO>>> ViewBooks(BookDTO requestDTO)
    {
      return Ok(await _bookService.View(requestDTO));
    }

    [HttpPost("borrowed")]
    public async Task<ActionResult<BookBorrowingRequestDTO>> BorrowedBooks(BookBorrowingRequestDTO requestDTO)
    {
      var result = await _bBookService.BorrowBooks(requestDTO);
      if (result.Message != null)
      {
        return BadRequest(result.Message);
      };
      return Ok(result);
    }

  }
}