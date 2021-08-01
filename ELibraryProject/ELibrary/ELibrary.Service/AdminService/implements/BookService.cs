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
      var book = await _context.Books.Include(x => x.CategoryList).FirstOrDefaultAsync(x => x.Id == id);
      if (book == null)
      {
        return false;
      };
      book.CategoryList = null;
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
        var book = await _context.Books.Include(x => x.CategoryList).FirstOrDefaultAsync(x => x.Id == requestDTO.Id);
        if (book == null)
        {
          return null;
        };

        book.Name = requestDTO.Name;
        book.Author = requestDTO.Author;
        var categories = new List<Category>();

        Category category = null;
        foreach (Guid id in requestDTO.CategoryID)
        {
          category = await _context.Categories.FindAsync(id);
          if (category == null) return null;
          categories.Add(category);
        }
        book.CategoryList = categories;
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
      var book = await _context.Books.Include(x => x.CategoryList).FirstOrDefaultAsync(x => x.Id == id);
      if (book == null) return null;

      List<Guid> categoryId = book.CategoryList == null
      ? new List<Guid>() : book.CategoryList.Select(x => x.Id).ToList();

      var result = new BookDTO
      {
        Id = book.Id,
        Name = book.Name,
        Author = book.Author,
        CategoryID = categoryId
      };
      return result;
    }
  }
}