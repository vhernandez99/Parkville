using Parkville.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Parkville
{
    public partial class App : Application
    {
        public App(bool shallNavigate)
        {
            InitializeComponent();
            var accessToken = Preferences.Get("accessToken", string.Empty);
            Device.SetFlags(new string[] { "MediaElement_Experimental" });
            if ((shallNavigate || !string.IsNullOrEmpty(accessToken)))
            {
                MainPage = new HomeTabbed();
            }
            else
            {
                MainPage = new SignupPage();
            }




            //MainPage = new Pago();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
