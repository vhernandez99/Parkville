using Parkville.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Parkville.ViewModels
{
    public static class UIViewModel
    {
        

        public static async Task GoToLoginPageAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new LoginPage()));
        }
        public static async Task GoToSignupPageAsync()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
            
        }
    }
}
