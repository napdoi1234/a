using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using ELibrary.Utilities.DTO;

namespace ELibrary.Service.CommonService
{
  public interface IAuthenticationService
  {
    public Task<string[]> Authenticate(LoginRequestDTO requestDTO);
  }
}