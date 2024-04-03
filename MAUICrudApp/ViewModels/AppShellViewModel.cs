using MAUICrudApp.Views;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUICrudApp.ViewModels
{
    public partial class AppShellViewModel : BaseViewModel
    {
        [ICommand]
        async void SignOut()
        {
            //await Shell.Current.Navigation.PopAsync();
            //await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");

            LoginPageViewModel viewModel = new LoginPageViewModel();
            Application.Current.MainPage = new LoginPage(viewModel);
        }
    }
}
