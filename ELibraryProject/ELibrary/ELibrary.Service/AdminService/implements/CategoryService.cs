using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELibrary.Data.EF;
using ELibrary.Data.Entities;
using ELibrary.Utilities.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ELibrary.Service.AdminService.implements
{
  public class CategoryService : ICategoryService
  {
    private readonly ELibraryDbContext _context;
    private readonly ILogger<CategoryService> _logger;
    public CategoryService(ELibraryDbContext context, ILogger<CategoryService> logger)
    {
      _context = context;
      _logger = logger;
    }

    public async Task<CategoryDTO> Add(CategoryDTO requestDTO)
    {
      var categoryEntity = new Category()
      {
        Id = new Guid(),
        Name = requestDTO.Name,
      };
      _context.Categories.Add(categoryEntity);
      await _context.SaveChangesAsync();

      var category = new CategoryDTO()
      {
        Id = categoryEntity.Id,
        Name = categoryEntity.Name,
      };

      return category;
    }

    public async Task<bool> Delete(Guid id)
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

    public async Task<CategoryDTO> FindById(Guid id)
    {
      var category = await _context.Categories.FindAsync(id);
      if (category == null) return null;
      var result = new CategoryDTO
      {
        Id = category.Id,
        Name = category.Name,
      };
      return result;
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
      }
      catch
      {
        _logger.LogInformation("Some errors happen when using database");
      }
      return result;
    }

    public async Task<PagingResult<CategoryDTO>> View(PagingRequest request)
    {
      var categories = _context.Categories.Select(x => new CategoryDTO { Id = x.Id, Name = x.Name });

      int totalRow = await categories.CountAsync();

      var data = await categories.Skip((request.PageIndex - 1) * request.PageSize)
          .Take(request.PageSize)
          .Select(x => new CategoryDTO()
          {
            Id = x.Id,
            Name = x.Name,
          }).ToListAsync();

      var pagedResult = new PagingResult<CategoryDTO>()
      {
        Items = data,
        TotalRecords = totalRow,
        PageSize = request.PageSize,
        PageIndex = request.PageIndex,
      };

      return pagedResult;
    }
  }
}