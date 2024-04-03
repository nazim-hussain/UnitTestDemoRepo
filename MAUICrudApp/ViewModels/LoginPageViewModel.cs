using MAUICrudApp.Models;
using MAUICrudApp.Views.Dashboard;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MAUICrudApp.ViewModels
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _email;
        
        [ObservableProperty]
        private string _password;

        #region Commands

        [ICommand]
        async void Login()
        {
            try
            {
                if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password))
                {
                    // call an api here 

                    var userDetails = new UserBasicsInfo
                    {
                        Email = Email,
                        FullName = "Ammar Ahmed",
                    };
                    if(Preferences.ContainsKey(nameof(App.UserDetails)))
                    {
                        Preferences.Remove(nameof(App.UserDetails));    
                    }
                    string userDetailsStr = JsonConvert.SerializeObject(userDetails);
                    Preferences.Set(nameof(App.UserDetails), userDetailsStr);
                    App.UserDetails = userDetails;
                    //await Shell.Current.GoToAsync($"//{nameof(DashboardPage)}");
                    Application.Current.MainPage = new AppShell();
                    await Shell.Current.GoToAsync($"//{nameof(DashboardPage)}");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error!", "Please Enter your Credential.", "Ok");
                }

            }
            catch (Exception ex)
            {

            }
        }
        #endregion
    }
}
