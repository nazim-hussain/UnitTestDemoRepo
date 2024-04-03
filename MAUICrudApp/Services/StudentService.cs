using MAUICrudApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUICrudApp.Services
{
    public class StudentService : IStudentService
    {
        List<StudentModel> studentList = new List<StudentModel>();

        private SQLiteAsyncConnection dbConnection;
        public StudentService()
        {
            if (dbConnection == null) SetupDb();
        }

        private async void SetupDb()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "StudentDb.db3");
            dbConnection = new SQLiteAsyncConnection(dbPath);
            await dbConnection.CreateTableAsync<StudentModel>();
        }

        public async Task<int> AddStudent(StudentModel student)
        {
            return await dbConnection.InsertAsync(student);
        }
        public async Task<int> UpdateStudent(StudentModel student)
        {
            return await dbConnection.UpdateAsync(student);
        }

        public async Task<int> DeleteStudent(StudentModel student)
        {
            return await dbConnection.DeleteAsync(student);
        }

        public async Task<List<StudentModel>> GetStudentList()
        {
            try
            {
                var studentList = await dbConnection.Table<StudentModel>().ToListAsync();
                return studentList;
            }
            catch (Exception ex)
            {
                return new List<StudentModel>();
            }
        }


        public void InsertStudent(StudentModel student)
        {
            studentList.Add(student);
        }
        public IEnumerable<StudentModel> GetStudents()
        {
            return studentList;
        }

    }
}
