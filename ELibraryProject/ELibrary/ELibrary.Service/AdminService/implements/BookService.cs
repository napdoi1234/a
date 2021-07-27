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
  public class BookService : IBookService
  {
    private readonly ELibraryDbContext _context;
    private readonly ILogger<BookService> _logger;
    public BookService(ELibraryDbContext context, ILogger<BookService> logger)
    {
      _context = context;
      _logger = logger;
    }

    public async Task<BookDTO> Add(BookDTO requestDTO)
    {
      var bookEntity = new Book()
      {
        Id = new Guid(),
        Name = requestDTO.Name,
        Author = requestDTO.Author,
      };
      _context.Books.Add(bookEntity);
      await _context.SaveChangesAsync();

      return new BookDTO
      {
        Id = bookEntity.Id,
        Name = bookEntity.Name,
        Author = bookEntity.Author
      };
    }

    public async Task<bool> Delete(Guid id)
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
        var book = await _context.Books.Where(x => x.Id == requestDTO.Id).Include(x => x.CategoryList).FirstOrDefaultAsync();
        if (book == null)
        {
          return null;
        };

        book.Name = requestDTO.Name;
        book.Author = requestDTO.Author;
        if (book.CategoryList == null)
        {
          book.CategoryList = new List<Category>();
        }

        Category category = null;
        foreach (Guid id in requestDTO.CategoryID)
        {
          category = await _context.Categories.FindAsync(id);
          if (category == null) return null;
          book.CategoryList.Add(category);
        }
        _context.Books.Update(book);
        await _context.SaveChangesAsync();
        await transaction.CommitAsync();

        result = new BookDTO()
        {
          Id = book.Id,
          Name = book.Name,
          Author = book.Author,
          CategoryName = book.CategoryList.Select(x => x.Name).ToList(),
        };

      }
      catch
      {
        _logger.LogInformation("Some errors happen when using database");
      }
      return result;
    }

    public async Task<BookDTO> FindById(Guid id)
    {
      var book = await _context.Books.Where(x => x.Id == id).Include(x => x.CategoryList).FirstOrDefaultAsync();
      if (book == null) return null;

      List<string> category = book.CategoryList == null
      ? new List<string>() : book.CategoryList.Select(x => x.Name).ToList();
      var result = new BookDTO
      {
        Id = book.Id,
        Name = book.Name,
        Author = book.Author,
        CategoryName = category
      };
      return result;
    }
  }
}