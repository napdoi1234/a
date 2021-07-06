using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Review2.Dto;
using Review2.Entities;
using Review2.Services;

namespace Review2.Controllers
{
    [ApiController]
    [Route("api")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService){
            _clientService = clientService;
        }

        [HttpGet("clients")]
        public ActionResult<List<ClientDto>> List(){
            return Ok(_clientService.List());
        }

        [HttpPost("client")]
        public ActionResult<ClientDto> CreatedClient(ClientEntity client){
            if(ModelState.IsValid){
                var result = _clientService.Create(client);
                if(result != null){
                    return Ok(result);
                }
            }
            return null;
        }

        [HttpPut("client")]
        public ActionResult<ClientDto> UpdatedClient(ClientEntity client){
            if(ModelState.IsValid){
                var result = _clientService.Update(client);
                if(result != null){
                    return Ok(result);
                }
            }
            return null;
        }

        [HttpDelete("client/{id}")]
        public bool DeletedClient(int id){
            return _clientService.Delete(id);
        }  
    }
}
