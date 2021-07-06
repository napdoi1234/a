using System.Collections.Generic;
using System.Linq;
using Review2.Dto;
using Review2.Entities;

namespace Review2.Services.implements
{
    public class ClientService : IClientService
    {
        private readonly BookStoreContext _context;
        public ClientService(BookStoreContext context)
        {
            _context = context;
        }
        public ClientDto Create(ClientEntity entity)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Clients.Add(entity);
                _context.SaveChanges();
                transaction.Commit();
                var dto = new ClientDto
                {
                    ClientId = entity.ClientId,
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
                var client = _context.Clients.Find(id);
                if (client != null)
                {
                    _context.Clients.Remove(client);
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

        public List<ClientDto> List()
        {
            var clientList = _context.Clients.Select(x => new ClientDto() { Name = x.Name, ClientId = x.ClientId }).ToList();
            return clientList;
        }

        public ClientDto Update(ClientEntity entity)
        {
            ClientDto dto = null;
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var client = _context.Clients.Find(entity.ClientId);
                if (client != null)
                {
                    dto = new ClientDto
                    {
                        ClientId = entity.ClientId,
                        Name = entity.Name
                    };
                    client.Name = entity.Name;
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