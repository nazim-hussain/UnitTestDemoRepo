using MAUICrudApp.Models;
using MAUICrudApp.Services;
using MAUICrudApp.Views;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUICrudApp.ViewModels
{
    public partial class StudentListPageViewModel : ObservableObject
    {
        public ObservableCollection<StudentModel> Students { get; set; } = new ObservableCollection<StudentModel>();
        private readonly IStudentService studentService;

        public StudentListPageViewModel(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [ICommand]
        public async void GetStudentList()
        {
            var studentList = await studentService.GetStudentList();
            if (studentList?.Count > 0) 
            {
                Students.Clear();
                foreach (var student in studentList)
                {
                    Students.Add(student);
                }
            }
        }


        [ICommand]
        public async void AddUpdateStudent()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateStudentPage));
        } 
        
        [ICommand]
        public async void DisplayAction(StudentModel studentModel)
        {
            await Shell.Current.DisplayAlert("Info Saved", "Student saved Successfully.", "Ok");

            var response = await AppShell.Current.DisplayActionSheet("Select Option", "Ok", null, "Edit", "Delete");
            if (response == "Edit")
            {
                var navParams = new Dictionary<string, object>();
                navParams.Add("StudentDetail", studentModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdateStudentPage), navParams);
            }
            else
            {
                var delResponse =  await studentService.DeleteStudent(studentModel);
                if(delResponse > 0)
                {
                    GetStudentList();
                }
            }
        }


        //[ICommand]
        public  void InsertStudent(StudentModel student)
        {
            studentService.InsertStudent(student);
        }
        
        public IEnumerable<StudentModel> GetStudents()
        {
            return studentService.GetStudents();
        }
    }
}
