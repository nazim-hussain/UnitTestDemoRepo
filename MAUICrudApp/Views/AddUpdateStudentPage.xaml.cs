using MAUICrudApp.Models;
using MAUICrudApp.ViewModels;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace MAUICrudApp.Views;


public partial class AddUpdateStudentPage : ContentPage
{
    public AddUpdateStudentPage(AddUpdateStudentVModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}