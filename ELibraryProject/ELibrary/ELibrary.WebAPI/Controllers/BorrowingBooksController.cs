using System.Security.Claims;
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
  [Route("api/book")]
  [Authorize(Roles = UserConstant.NormalRole)]
  public class BorrowingBooksController : ControllerBase
  {
    private readonly IBorrowingBookService _borrowBookService;
    private readonly IBookCommonService _bookService;
    public BorrowingBooksController(IBorrowingBookService borrowBookService, IBookCommonService bookService)
    {
      _borrowBookService = borrowBookService;
      _bookService = bookService;
    }
    protected string GetUserId()
    {
      var claimsIdentity = User.Identity as ClaimsIdentity;
      return claimsIdentity.FindFirst(ClaimTypes.UserData).Value;
    }

    [HttpGet("borrowed")]
    public async Task<ActionResult<PagingResult<BookBorrowingRequestDTO>>> ViewBorrowedBooks
    ([FromQuery(Name = "pageSize")] int pageSize, [FromQuery(Name = "pageIndex")] int pageIndex = 1)
    {
      var requestDTO = new BookBorrowingRequestDTO
      {
        UserId = GetUserId(),
        PageIndex = pageIndex,
        PageSize = pageSize,
      };
      return Ok(await _borrowBookService.ViewBorrowedBooks(requestDTO));
    }

    [HttpGet]
    public async Task<ActionResult<PagingResult<BookDTO>>> ViewBooks(
    [FromQuery(Name = "pageSize")] int pageSize, [FromQuery(Name = "pageIndex")] int pageIndex = 1)
    {
      var request = new PagingRequest
      {
        PageSize = pageSize,
        PageIndex = pageIndex,
      };
      return Ok(await _bookService.View(request));
    }

    [HttpPost("borrowed")]
    public async Task<ActionResult<BookBorrowingRequestDTO>> BorrowedBooks(BookBorrowingRequestDTO requestDTO)
    {
      requestDTO.UserId = GetUserId();
      var result = await _borrowBookService.BorrowBooks(requestDTO);
      if (result.Message != null)
      {
        return BadRequest(result.Message);
      };
      return Ok(result);
    }

  }
}