using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ELibrary.Service.AdminService;
using ELibrary.Utilities.Constants.User;
using ELibrary.Utilities.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.WebAPI.Controllers
{
  [ApiController]
  [Route("api/admin/borrow_book")]
  [Authorize(Roles = UserConstant.AdminRole)]
  public class BorrowingBooksAdminController : ControllerBase
  {
    private readonly IConfirmBookService _confirmService;
    public BorrowingBooksAdminController(IConfirmBookService confirmService)
    {
      _confirmService = confirmService;
    }

    protected string GetUserId()
    {
      var claimsIdentity = User.Identity as ClaimsIdentity;
      return claimsIdentity.FindFirst(ClaimTypes.UserData).Value;
    }

    [HttpGet]
    public async Task<ActionResult<PagingResult<BookBorrowingRequestDTO>>> View(
      [FromQuery(Name = "pageSize")] int pageSize, [FromQuery(Name = "pageIndex")] int pageIndex = 1)
    {
      var request = new PagingRequest
      {
        PageIndex = pageIndex,
        PageSize = pageSize,
      };
      return Ok(await _confirmService.ViewBorrowedBooks(request));
    }

    [HttpPost]
    public async Task<ActionResult> ConfirmBorrowedBook(BookConfirmRequestDTO requestDTO)
    {
      requestDTO.UserId = GetUserId();
      var result = await _confirmService.ConfirmBorrowedBooks(requestDTO);
      if (result)
      {
        return Ok();
      }
      return BadRequest("Error Confirmation");
    }
  }
}