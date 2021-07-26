using System.Threading.Tasks;
using ELibrary.Utilities.DTO;

namespace ELibrary.Service.CommonService
{
  public interface IBookService
  {
    public Task<PagingResult<BookDTO>> View(BookDTO requestDTO);
  }
}