using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _29062021.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _29062021.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {

        private readonly SampleWebApiContext _context;

        static List<TaskModel> taskList = new List<TaskModel>();

        public TaskController(SampleWebApiContext context)
        {
            _context = context;
        }

        [HttpGet("List")]
        public async Task<ActionResult> List()
        {
            return Ok(await _context.Tasks.ToListAsync());
        }

        [HttpGet("One")]
        public async Task<ActionResult<TaskModel>> TaskDetail(Guid id)
        {
            var task = await _context.Tasks.FindAsync(id);
            return Ok(task);
        }

        [HttpPost("NewOne")]
        public async Task<ActionResult<TaskModel>> TaskCreate(TaskModel model)
        {
            await _context.Tasks.AddAsync(model);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(TaskCreate), model);
        }

        [HttpPut("Change")]
        public async Task<ActionResult<TaskModel>> TaskUpdate(TaskModel model)
        {
            _context.Tasks.Update(model);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(TaskUpdate), model);
        }

        [HttpDelete("RemoveOne")]
        public async Task<ActionResult<bool>> TaskRemove(Guid id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        [HttpPost("NewList")]
        public async Task<ActionResult<List<TaskModel>>> ListTaskCreate(List<TaskModel> models)
        {
            await _context.Tasks.AddRangeAsync(models);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ListTaskCreate), models);
        }

        [HttpDelete("RemoveList")]
        public async Task<ActionResult<bool>> ListTaskRemove(List<Guid> ids)
        {
            var listOfId = _context.Tasks.Select(r => r.Id);
            var taskList = await _context.Tasks.Where(r => listOfId.Contains(r.Id)).ToListAsync();
            if (taskList != null)
            {
                _context.Tasks.RemoveRange(taskList);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
