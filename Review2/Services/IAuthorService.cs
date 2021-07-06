using System.Collections.Generic;
using Review2.Dto;
using Review2.Entities;

namespace Review2.Services
{
    public interface IAuthorService
    {
        List<AuthorDto> List();

        AuthorDto Create(AuthorEntity entity);

        AuthorDto Update(AuthorEntity entity);

        bool Delete(int id);
    }
}