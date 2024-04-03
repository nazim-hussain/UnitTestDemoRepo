
namespace MAUICrudUnitTest
{
    public class CustomUnitTest
    {
        [Fact]
        public void StudentListPageViewModelTest()
        {
            // Arrange
            IStudentService studentService = new StudentService();
            var studentViewModel = new StudentListPageViewModel(studentService);

            // Act
            var student = new StudentModel { StudentId = 50, Name = "Mathew", Email = "Mathew@gmail.com", Gender = "Male" };
            studentViewModel.InsertStudent(student);

            // Assert
            Assert.Contains(student, studentService.GetStudents());
        }

    }
}