using Parkville.Models;
using Parkville.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Parkville.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyReservations : ContentPage
    {
        public ObservableCollection<UserReservations> ReservationsCollection;
        public UserReservations userReservation;
        
        public MyReservations()
        {
            InitializeComponent();
            
            ReservationsCollection = new ObservableCollection<UserReservations>();
            
            GetReservationsList();
            NavigationPage.SetBackButtonTitle(this, "");
        }

        private async void GetReservationsList()
        {
            CultureInfo provider = CultureInfo.CreateSpecificCulture("es-ES");

            var reservations = await ApiService.GetMyReservations();
            
            foreach (var reservation in reservations)
            {
                ReservationsCollection.Add(reservation); 
            }
            CvReservations.ItemsSource = ReservationsCollection;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private async void CvReservations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentSelection = e.CurrentSelection.FirstOrDefault() as UserReservations;
            if (currentSelection == null) return;
            await Navigation.PushAsync(new ReservacionQR(currentSelection.ReservationId));
            ((CollectionView)sender).SelectedItem = null;
        }

        private async void Pagar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PaymentView());
        }

        //Navigation.PopModalAsync();
    }
}