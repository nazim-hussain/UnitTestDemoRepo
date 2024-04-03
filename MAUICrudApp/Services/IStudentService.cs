using MAUICrudApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUICrudApp.Services
{
    public interface IStudentService
    {
        Task<int> AddStudent(StudentModel student);
        Task<int> UpdateStudent(StudentModel student);
        Task<int> DeleteStudent(StudentModel student);
        Task<List<StudentModel>> GetStudentList();
        void InsertStudent(StudentModel student);
        IEnumerable<StudentModel> GetStudents();

    }
}
