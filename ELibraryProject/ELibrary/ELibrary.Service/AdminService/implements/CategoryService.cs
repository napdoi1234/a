using System.Linq;
using System.Threading.Tasks;
using ELibrary.Data.EF;
using ELibrary.Data.Entities;
using ELibrary.Utilities.DTO;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.Service.AdminService.implements
{
  public class CategoryService : ICategoryService
  {
    private readonly ELibraryDbContext _context;
    public CategoryService(ELibraryDbContext context)
    {
      _context = context;
    }

    public async Task<CategoryDTO> Add(CategoryDTO requestDTO)
    {
      CategoryDTO category = null;

      var categoryEntity = new Category()
      {
        Name = requestDTO.Name
      };
      _context.Categories.Add(categoryEntity);
      await _context.SaveChangesAsync();

      category = new CategoryDTO
      {
        Id = category.Id,
        Name = categoryEntity.Name,
      };

      return category;
    }

    public async Task<bool> Delete(int id)
    {
      var category = await _context.Categories.FindAsync(id);
      if (category == null)
      {
        return false;
      };
      _context.Categories.Remove(category);
      await _context.SaveChangesAsync();
      return true;
    }

    public async Task<CategoryDTO> Update(CategoryDTO requestDTO)
    {
      CategoryDTO result = null;
      using var transaction = await _context.Database.BeginTransactionAsync();
      try
      {
        var category = await _context.Categories.FindAsync(requestDTO.Id);
        if (category == null)
        {
          return null;
        };

        category.Name = requestDTO.Name;
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
        await transaction.CommitAsync();

        result = new CategoryDTO()
        {
          Id = category.Id,
          Name = category.Name,
        };
        return result;
      }
      catch
      {
        return result;
      }
    }

    public async Task<PagingResult<CategoryDTO>> View(CategoryDTO requestDTO)
    {
      var categories = _context.Categories.Select(x => new CategoryDTO { Id = x.Id, Name = x.Name });

      int totalRow = await categories.CountAsync();

      var data = await categories.Skip((requestDTO.PageIndex - 1) * requestDTO.PageSize)
          .Take(requestDTO.PageSize)
          .Select(x => new CategoryDTO()
          {
            Id = x.Id,
            Name = x.Name,
          }).ToListAsync();

      var pagedResult = new PagingResult<CategoryDTO>()
      {
        Items = data,
        TotalRecords = totalRow,
        PageSize = requestDTO.PageSize,
        PageIndex = requestDTO.PageIndex,
      };

      return pagedResult;
    }
  }
}