using System;
using System.Threading.Tasks;
using ELibrary.Utilities.DTO;

namespace ELibrary.Service.AdminService
{
  public interface ICategoryService
  {
    public Task<PagingResult<CategoryDTO>> View(PagingRequest request);
    public Task<CategoryDTO> Add(CategoryDTO requestDTO);
    public Task<CategoryDTO> Update(CategoryDTO requestDTO);
    public Task<CategoryDTO> FindById(Guid id);
    public Task<bool> Delete(Guid id);
  }
}