using MediaManager;
using Parkville.Models;
using Parkville.Services;
using Parkville.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Parkville.Views
{
    [XamlCompilation(XamlCompilationOptions.Skip)]
    public partial class HomePage : ContentPage
    {
        HomePageViewModel hpvm;
        public HomePage()
        {
            InitializeComponent();
            
            hpvm = new HomePageViewModel();
            this.BindingContext = hpvm;
            //LblUserName.Text= Preferences.Get("userName", string.Empty);
        }
        private void CvMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentSelection=e.CurrentSelection.FirstOrDefault() as Movie;
            if (currentSelection == null) return;
            Navigation.PushModalAsync(new MovieDetailPage(currentSelection.Id));
            ((CollectionView)sender).SelectedItem = null;
        }

        private void TapSearch_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new SearchMoviesPage());
        }
        private void CvMovies_RemainingItemsThresholdReached(object sender, EventArgs e)
        {
            hpvm.GetMovies();
        }

      

        








        //private void TapLogout_Tapped(object sender, EventArgs e)
        //{
        //    Preferences.Set("acessToken", string.Empty);
        //    Preferences.Set("tokenExpirationTime", 0);
        //    Application.Current.MainPage = new NavigationPage(new SignupPage());
        //}



    }
}