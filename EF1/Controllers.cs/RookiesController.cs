using System.Collections.Generic;
using System.Threading.Tasks;
using EF1.Models;
using EF1.Services;
using Microsoft.AspNetCore.Mvc;

namespace EF1.Controllers
{
    [ApiController]
    [Route("api/rookies")]
    public class RookiesController : ControllerBase
    {

        private readonly IStudentService _studentService;

        public RookiesController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("students")]
        public async Task<ActionResult<List<StudentModel>>> Students()
        {
            return Ok(await _studentService.List());
        }

        [HttpPost("student")]
        public async Task<ActionResult<StudentModel>> CreatedStudent(StudentModel student)
        {
            return Ok(await _studentService.Create(student));
        }

        [HttpPut("student")]
        public async Task<ActionResult<StudentModel>> UpdatedStudent(StudentModel student)
        {
            var model = await _studentService.Update(student);
            if (model != null)
            {
                return Ok(model);
            }
            return null;
        }

        [HttpDelete("student")]
        public async Task<bool> RemovedStudent(int id)
        {
            return await _studentService.Delete(id);
        }
    }
}