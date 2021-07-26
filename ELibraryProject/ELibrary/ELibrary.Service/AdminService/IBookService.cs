using System.Threading.Tasks;
using ELibrary.Utilities.DTO;

namespace ELibrary.Service.AdminService
{
  public interface IBookService
  {
    public Task<BookDTO> Add(BookDTO requestDTO);
    public Task<BookDTO> Update(BookDTO requestDTO);
    public Task<bool> Delete(int id);
    public Task<bool> AddCategory(BookDTO requestDTO);
  }
}