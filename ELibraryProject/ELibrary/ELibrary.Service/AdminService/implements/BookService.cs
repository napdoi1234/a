using System.Linq;
using System.Threading.Tasks;
using ELibrary.Data.EF;
using ELibrary.Data.Entities;
using ELibrary.Utilities.DTO;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.Service.AdminService.implements
{
  public class BookService : IBookService
  {
    private readonly ELibraryDbContext _context;
    public BookService(ELibraryDbContext context)
    {
      _context = context;
    }

    public async Task<BookDTO> Add(BookDTO requestDTO)
    {
      BookDTO book = null;

      var bookEntity = new Book()
      {
        Name = requestDTO.Name,
        Author = requestDTO.Author,
      };
      _context.Books.Add(bookEntity);
      await _context.SaveChangesAsync();

      book = new BookDTO
      {
        Id = bookEntity.Id,
        Name = bookEntity.Name,
        Author = bookEntity.Author
      };

      return book;
    }

    public async Task<bool> Delete(int id)
    {
      var book = await _context.Books.FindAsync(id);
      if (book == null)
      {
        return false;
      };
      _context.Books.Remove(book);
      await _context.SaveChangesAsync();
      return true;
    }

    public async Task<BookDTO> Update(BookDTO requestDTO)
    {
      BookDTO result = null;
      using var transaction = await _context.Database.BeginTransactionAsync();
      try
      {
        var book = await _context.Books.FindAsync(requestDTO.Id);
        if (book == null)
        {
          return null;
        };

        book.Name = requestDTO.Name;
        book.Author = requestDTO.Author;
        _context.Books.Update(book);
        await _context.SaveChangesAsync();
        await transaction.CommitAsync();

        result = new BookDTO()
        {
          Id = book.Id,
          Name = book.Name,
          Author = book.Author
        };
        return result;
      }
      catch
      {
        return result;
      }
    }

    public async Task<bool> AddCategory(BookDTO requestDTO)
    {
      var book = await _context.Books.FindAsync(requestDTO.Id);
      if (book == null) return false;

      Category category = null;
      foreach (int id in requestDTO.CategoryID)
      {
        category = await _context.Categories.FindAsync(id);
        book.CategoryList.Add(category);
      }
      _context.Books.Update(book);
      await _context.SaveChangesAsync();
      return true;
    }
  }
}