using System;
using System.Threading.Tasks;
using ELibrary.Service.AdminService;
using ELibrary.Service.CommonService;
using ELibrary.Utilities.Constants.User;
using ELibrary.Utilities.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.WebAPI.Controllers
{
  [ApiController]
  [Route("api/admin/book")]
  [Authorize(Roles = UserConstant.AdminRole)]
  public class BookController : ControllerBase
  {
    private readonly IBookService _bookService;
    private readonly IBookCommonService _commonService;
    public BookController(IBookService bookService, IBookCommonService commonService)
    {
      _bookService = bookService;
      _commonService = commonService;
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
      return Ok(await _commonService.View(request));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookDTO>> ViewBook(Guid id)
    {
      var result = await _bookService.FindById(id);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }

    [HttpPost]
    public async Task<ActionResult<BookDTO>> Create(BookDTO requestDTO)
    {
      return Ok(await _bookService.Add(requestDTO));
    }

    [HttpPut]
    public async Task<ActionResult<BookDTO>> Update(BookDTO requestDTO)
    {
      var result = await _bookService.Update(requestDTO);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
      var result = await _bookService.Delete(id);
      if (result)
      {
        return Ok();
      }
      return BadRequest();
    }
  }
}