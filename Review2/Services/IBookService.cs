using System.Collections.Generic;
using Review2.Dto;
using Review2.Entities;

namespace Review2.Services
{
    public interface IBookService
    {
        List<BookDto> List();

        BookDto Create(BookEntity entity);

        BookDto Update(BookEntity entity);

        bool Delete(int id);
    }
}