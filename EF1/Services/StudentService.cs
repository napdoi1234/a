using System.Collections.Generic;
using System.Threading.Tasks;
using EF1.Models;
using Microsoft.EntityFrameworkCore;
namespace EF1.Services
{
    public class StudentService : IStudentService
    {
        private EFCoreContext _context;
        public StudentService(EFCoreContext context)
        {
            _context = context;
        }

        public async Task<StudentModel> Create(StudentModel student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<bool> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<StudentModel>> List()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<StudentModel> Update(StudentModel student)
        {
            var model = await _context.Students.FindAsync(student.StudentId);
            if (model != null)
            {
                model.FirstName = student.FirstName;
                model.LastName = student.LastName;
                model.City = student.City;
                model.State = student.State;
                await _context.SaveChangesAsync();
            }
            return model;
        }
    }
}