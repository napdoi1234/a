using System.Collections.Generic;
using System.Linq;
using Review2.Dto;
using Review2.Entities;

namespace Review2.Services.implements
{
    public class BookService : IBookService
    {
        private readonly BookStoreContext _context;
        public BookService(BookStoreContext context)
        {
            _context = context;
        }
        public BookDto Create(BookEntity entity)
        {
            BookDto dto = null;
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var client = _context.Clients.Find(entity.ClientId);
                if (client != null)
                {
                    _context.Books.Add(entity);
                    _context.SaveChanges();
                    transaction.Commit();
                    dto = new BookDto
                    {
                        BookId = entity.BookId,
                        Name = entity.Name,
                        ClientId = entity.ClientId
                    };
                }
                return dto;
            }
            catch
            {
                return null;
            }
        }

        public bool Delete(int id)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var book = _context.Books.Find(id);
                if (book != null)
                {
                    _context.Books.Remove(book);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public List<BookDto> List()
        {
            var bookList = _context.Books.Select(x => new BookDto() { Name = x.Name, ClientId = x.ClientId, BookId = x.BookId }).ToList();
            return bookList;
        }

        public BookDto Update(BookEntity entity)
        {
            BookDto dto = null;
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var book = _context.Books.Find(entity.BookId);
                var client = _context.Clients.Find(entity.ClientId);
                if (book != null && client != null)
                {
                    dto = new BookDto
                    {
                        ClientId = entity.ClientId,
                        Name = entity.Name
                    };
                    book.Name = entity.Name;
                    book.ClientId = entity.ClientId;
                    _context.SaveChanges();
                }
                return dto;
            }
            catch
            {
                return null;
            }
        }
    }
}