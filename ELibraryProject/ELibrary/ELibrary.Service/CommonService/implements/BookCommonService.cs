using System.Linq;
using System.Threading.Tasks;
using ELibrary.Data.EF;
using ELibrary.Utilities.DTO;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.Service.CommonService.implements
{
  public class BookCommonService : IBookCommonService
  {
    private readonly ELibraryDbContext _context;
    public BookCommonService(ELibraryDbContext context)
    {
      _context = context;
    }
    public async Task<PagingResult<BookDTO>> View(PagingRequest request)
    {
      var books = _context.Books.Select(x => new BookDTO
      {
        Id = x.Id,
        Name = x.Name,
        Author = x.Author,
        CategoryName = x.CategoryList.Select(x => x.Name).ToList(),
      });

      int totalRow = await books.CountAsync();

      var data = await books.Skip((request.PageIndex - 1) * request.PageSize)
          .Take(request.PageSize)
          .Select(x => new BookDTO()
          {
            Id = x.Id,
            Name = x.Name,
            Author = x.Author,
            CategoryName = x.CategoryName
          }).ToListAsync();

      var pagedResult = new PagingResult<BookDTO>()
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