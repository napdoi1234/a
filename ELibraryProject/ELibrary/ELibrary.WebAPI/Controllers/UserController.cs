using System.Threading.Tasks;
using ELibrary.Service.CommonService;
using ELibrary.Utilities.Constants.User;
using ELibrary.Utilities.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.WebAPI.Controllers
{
  [ApiController]
  [Route("api/user")]
  public class UserController : ControllerBase
  {
    private readonly IAuthenticationService _authenService;
    public UserController(IAuthenticationService authenService)
    {
      _authenService = authenService;
    }

    [HttpPost("authentication")]
    public async Task<ActionResult> Authentication(LoginRequestDTO requestDTO)
    {
      var result = await _authenService.Authenticate(requestDTO);
      if (result == UserConstant.NotFoundUser)
      {
        return BadRequest(UserConstant.NotFoundUser);
      }
      else if (result == UserConstant.WrongPassword)
      {
        return BadRequest(UserConstant.WrongPassword);
      }
      return Ok(result);
    }
  }
}