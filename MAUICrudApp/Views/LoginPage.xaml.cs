using MAUICrudApp.ViewModels;
//using static Java.Util.Jar.Attributes;

namespace MAUICrudApp.Views;

//[QueryProperty(nameof(Name), "name")]
public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}