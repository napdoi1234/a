using System.Collections.Generic;
using System.Threading.Tasks;
using EF1.Models;

namespace EF1.Services
{
    public interface IStudentService
    {
        Task<StudentModel> Create(StudentModel student);
        Task<List<StudentModel>> List();
        Task<StudentModel> Update(StudentModel student);
        Task<bool> Delete(int id);
    }
}