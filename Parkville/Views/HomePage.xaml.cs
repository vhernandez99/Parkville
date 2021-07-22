using MediaManager;
using PanCardView;
using Parkville.Helpers;
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
            CvMovies.ItemTemplate = CvMovies.ItemTemplate.WithSelectedBackgroundColor(Color.Transparent);

        }
        private async void CvMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentSelection=e.CurrentSelection.FirstOrDefault() as Movie;
            if (currentSelection == null) return;
            await Navigation.PushAsync(new MovieDetailPage(currentSelection.Id));
            ((CollectionView)sender).SelectedItem = null;
        }
        private void CvMovies_RemainingItemsThresholdReached(object sender, EventArgs e)
        {
            hpvm.GetMovies();
        }
    }
}