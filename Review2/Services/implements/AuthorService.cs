using System.Collections.Generic;
using System.Linq;
using Review2.Dto;
using Review2.Entities;

namespace Review2.Services.implements
{
    public class AuthorService : IAuthorService
    {
        private readonly BookStoreContext _context;
        public AuthorService(BookStoreContext context)
        {
            _context = context;
        }
        public AuthorDto Create(AuthorEntity entity)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Authors.Add(entity);
                _context.SaveChanges();
                transaction.Commit();
                var dto = new AuthorDto
                {
                    AuthorId = entity.AuthorId,
                    Name = entity.Name
                };
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
                var author = _context.Authors.Find(id);
                if (author != null)
                {
                    _context.Authors.Remove(author);
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

        public List<AuthorDto> List()
        {
            var authorList = _context.Authors.Select(x => new AuthorDto() { Name = x.Name, AuthorId = x.AuthorId }).ToList();
            return authorList;
        }

        public AuthorDto Update(AuthorEntity entity)
        {
            AuthorDto dto = null;
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var author = _context.Authors.Find(entity.AuthorId);
                if (author != null)
                {
                    dto = new AuthorDto
                    {
                        AuthorId = entity.AuthorId,
                        Name = entity.Name
                    };
                    author.Name = entity.Name;
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