using System.Threading.Tasks;
using ELibrary.Utilities.DTO;

namespace ELibrary.Service.CommonService
{
  public interface IBookCommonService
  {
    public Task<PagingResult<BookDTO>> View(PagingRequest request);
  }
}