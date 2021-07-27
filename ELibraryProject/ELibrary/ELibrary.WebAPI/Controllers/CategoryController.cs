using System;
using System.Threading.Tasks;
using ELibrary.Service.AdminService;
using ELibrary.Utilities.Constants.User;
using ELibrary.Utilities.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.WebAPI.Controllers
{
  [ApiController]
  [Route("api/admin/category")]
  [Authorize(Roles = UserConstant.AdminRole)]
  public class CategoryController : ControllerBase
  {
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)
    {
      _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<PagingResult<CategoryDTO>>> ViewCategories(
    [FromQuery(Name = "pageSize")] int pageSize, [FromQuery(Name = "pageIndex")] int pageIndex = 1)
    {
      var request = new PagingRequest
      {
        PageSize = pageSize,
        PageIndex = pageIndex,
      };
      return Ok(await _categoryService.View(request));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDTO>> ViewBook(Guid id)
    {
      var result = await _categoryService.FindById(id);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest("Not found category");
    }

    [HttpPost]
    public async Task<ActionResult<CategoryDTO>> Create(CategoryDTO requestDTO)
    {
      return Ok(await _categoryService.Add(requestDTO));
    }

    [HttpPut]
    public async Task<ActionResult<CategoryDTO>> Update(CategoryDTO requestDTO)
    {
      var result = await _categoryService.Update(requestDTO);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest("Not found category");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
      var result = await _categoryService.Delete(id);
      if (result)
      {
        return Ok();
      }
      return BadRequest("Not found category");
    }
  }

}