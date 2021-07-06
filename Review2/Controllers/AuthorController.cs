using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Review2.Dto;
using Review2.Entities;
using Review2.Services;

namespace Review2.Controllers
{
    [ApiController]
    [Route("api")]
    public class AuthorController: ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService){
            _authorService = authorService;
        }

        [HttpGet("authors")]
        public ActionResult<List<AuthorDto>> List(){
            return Ok(_authorService.List());
        }

        [HttpPost("author")]
        public ActionResult<AuthorDto> CreatedAuthor(AuthorEntity author){
            if(ModelState.IsValid){
                var result = _authorService.Create(author);
                if(result != null){
                    return Ok(result);
                }
            }
            return null;
        }

        [HttpPut("author")]
        public ActionResult<AuthorDto> UpdatedAuthor(AuthorEntity author){
            if(ModelState.IsValid){
                var result = _authorService.Update(author);
                if(result != null){
                    return Ok(result);
                }
            }
            return null;
        }

        [HttpDelete("author/{id}")]
        public bool DeletedAuthor(int id){
            return _authorService.Delete(id);
        }  
    }
}