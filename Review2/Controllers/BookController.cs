using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Review2.Dto;
using Review2.Entities;
using Review2.Services;

namespace Review2.Controllers
{
    [ApiController]
    [Route("api")]
    public class BookController: ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService){
            _bookService = bookService;
        }

        [HttpGet("books")]
        public ActionResult<List<BookDto>> List(){
            return Ok(_bookService.List());
        }

        [HttpPost("book")]
        public ActionResult<BookDto> CreatedBook(BookEntity book){
            if(ModelState.IsValid){
                var result = _bookService.Create(book);
                if(result != null){
                    return Ok(result);
                }
            }
            return null;
        }

        [HttpPut("book")]
        public ActionResult<BookDto> UpdatedBook(BookEntity book){
            if(ModelState.IsValid){
                var result = _bookService.Update(book);
                if(result != null){
                    return Ok(result);
                }
            }
            return null;
        }

        [HttpDelete("book/{id}")]
        public bool DeletedBook(int id){
            return _bookService.Delete(id);
        }  
    }
}