using System.IdentityModel.Tokens.Jwt;
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
      if (result == null)
      {
        return BadRequest(UserConstant.WrongAuthen);
      }
      return Ok(new
      {
        token = result[0],
        role = result[1]
      });
    }
  }
}