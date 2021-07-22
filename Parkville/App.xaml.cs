using Parkville.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
namespace Parkville
{
    public partial class App : Application
    {
        public App(bool shallNavigate)
        {
            InitializeComponent();
            var accessToken = Preferences.Get("accessToken", string.Empty);
            Xamarin.Forms.Device.SetFlags(new string[] { "MediaElement_Experimental" });
            
            if ((shallNavigate || !string.IsNullOrEmpty(accessToken)))
            {
                MainPage = new NavigationPage(new HomeTabbed());
            }
            else
            {
                MainPage = new SignupPage();
            }

            //MainPage = new Pago();
        }

        protected override void OnStart()
        {
            AppCenter.Start("ios=ffdadf1d-e881-4933-86fd-73ae3cbc9e6e;" +
                  "uwp={Your UWP App secret here};" +
                  "android={Your Android App secret here}",
                  typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
