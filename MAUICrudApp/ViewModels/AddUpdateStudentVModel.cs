using MAUICrudApp.Models;
using MAUICrudApp.Services;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUICrudApp.ViewModels
{
    [QueryProperty(nameof(StudentDetail), "StudentDetail")]
    public partial class AddUpdateStudentVModel : ObservableObject
    {
        [ObservableProperty]
        private StudentModel _studentDetail = new StudentModel();


        private readonly IStudentService studentService;
        public AddUpdateStudentVModel(IStudentService _studentService)
        {
            studentService = _studentService;
        }

        //[ObservableProperty]
        //private string _name;

        //[ObservableProperty]
        //private string _gender;

        //[ObservableProperty]
        //private string _email;

        [ICommand]
        public async void AddUpdateStudent()
        {
            var response = -1;
            if(StudentDetail.StudentId > 0)
            {
                response = await studentService.UpdateStudent(StudentDetail);
            }
            else
            {
                response = await studentService.AddStudent(new StudentModel
                {
                    Name = StudentDetail.Name,
                    Email = StudentDetail.Email,
                    Gender = StudentDetail.Gender,
                });
            }
            
            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Info Saved", "Student saved Successfully.", "Ok");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error!", "Something went wrog.", "Ok");
            }
        }
    }

}