using System.Linq;
using System.Threading.Tasks;
using ELibrary.Data.EF;
using ELibrary.Utilities.DTO;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.Service.CommonService.implements
{
  public class BookService : IBookService
  {
    private readonly ELibraryDbContext _context;
    public BookService(ELibraryDbContext context)
    {
      _context = context;
    }
    public async Task<PagingResult<BookDTO>> View(BookDTO requestDTO)
    {
      var books = _context.Books.Select(x => new BookDTO { Id = x.Id, Name = x.Name, Author = x.Author });

      int totalRow = await books.CountAsync();

      var data = await books.Skip((requestDTO.PageIndex - 1) * requestDTO.PageSize)
          .Take(requestDTO.PageSize)
          .Select(x => new BookDTO()
          {
            Id = x.Id,
            Name = x.Name,
            Author = x.Author
          }).ToListAsync();

      var pagedResult = new PagingResult<BookDTO>()
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