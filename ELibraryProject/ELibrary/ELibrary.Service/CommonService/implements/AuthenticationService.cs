using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ELibrary.Data.Entities;
using ELibrary.Utilities.Constants.User;
using ELibrary.Utilities.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ELibrary.Service.CommonService.implements
{
  public class AuthenticationService : IAuthenticationService
  {
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _config;
    private readonly SignInManager<User> _signInManager;
    public AuthenticationService(UserManager<User> userManager, IConfiguration config, SignInManager<User> signInManager)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _config = config;
    }

    public async Task<string[]> Authenticate(LoginRequestDTO requestDTO)
    {
      var result = new string[2];
      var user = await _userManager.FindByNameAsync(requestDTO.UserName);
      if (user == null)
      {
        return null;
      }
      var login = await _signInManager.PasswordSignInAsync(user, requestDTO.Password, false, false);
      if (!login.Succeeded)
      {
        return null;
      }

      var userRoles = await _userManager.GetRolesAsync(user);

      var authClaims = new[]
      {
        new Claim(ClaimTypes.Name, user.FullName),
        new Claim(ClaimTypes.UserData, user.Id),
        new Claim(ClaimTypes.Role, string.Join(";",userRoles)),
      };

      var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));

      var token = new JwtSecurityToken(
          issuer: _config["Tokens:Issuer"],
          audience: _config["Tokens:Issuer"],
          expires: DateTime.Now.AddHours(3),
          claims: authClaims,
          signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
          );

      result[0] = new JwtSecurityTokenHandler().WriteToken(token);
      result[1] = string.Join(";", userRoles);

      return result;
    }
  }
}