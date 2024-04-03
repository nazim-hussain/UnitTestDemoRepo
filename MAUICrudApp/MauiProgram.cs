using MAUICrudApp.Services;
using MAUICrudApp.ViewModels;
using MAUICrudApp.Views;
using MAUICrudApp.Views.Dashboard;
using Microsoft.Extensions.Logging;

namespace MAUICrudApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // services
            builder.Services.AddSingleton<IStudentService, StudentService>();

            // views registeration
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<DashboardPage>();
            
            builder.Services.AddTransient<StudentListPage>();
            builder.Services.AddTransient<AddUpdateStudentPage>();


            // view models
            builder.Services.AddSingleton<LoginPageViewModel>();
            builder.Services.AddSingleton<DashboardPageViewModel>();
            
            builder.Services.AddTransient<StudentListPageViewModel>();
            builder.Services.AddTransient<AddUpdateStudentVModel>();


#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
