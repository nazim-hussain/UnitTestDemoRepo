using MAUICrudApp.Handlers;
using MAUICrudApp.Models;
using Microsoft.Maui.Platform;

namespace MAUICrudApp
{
    public partial class App : Application
    {
        public static UserBasicsInfo UserDetails;

        public App()
        {
            InitializeComponent();

            // Boder less entry handler
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) =>
            {
                if (view is BorderlessEntry) 
                {
#if __ANDROID__
                    handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif __IOS__
                    handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
                }
            });


            MainPage = new AppShell();
        }
    }
}
