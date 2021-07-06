using System.Collections.Generic;
using Review2.Dto;
using Review2.Entities;
namespace Review2.Services
{
    public interface IClientService
    {
        List<ClientDto> List();

        ClientDto Create(ClientEntity entity);

        ClientDto Update(ClientEntity entity);

        bool Delete(int id);
    }
}