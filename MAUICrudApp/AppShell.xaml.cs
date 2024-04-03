using MAUICrudApp.ViewModels;
using MAUICrudApp.Views;
using MAUICrudApp.Views.Dashboard;

namespace MAUICrudApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            this.BindingContext = new AppShellViewModel();
            Routing.RegisterRoute(nameof(DashboardPage), typeof(DashboardPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(AddUpdateStudentPage), typeof(AddUpdateStudentPage));
        }
    }
}
