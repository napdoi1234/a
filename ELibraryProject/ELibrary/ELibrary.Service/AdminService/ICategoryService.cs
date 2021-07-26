using System.Threading.Tasks;
using ELibrary.Utilities.DTO;

namespace ELibrary.Service.AdminService
{
  public interface ICategoryService
  {
    public Task<PagingResult<CategoryDTO>> View(CategoryDTO requestDTO);
    public Task<CategoryDTO> Add(CategoryDTO requestDTO);
    public Task<CategoryDTO> Update(CategoryDTO requestDTO);
    public Task<bool> Delete(int id);
  }
}