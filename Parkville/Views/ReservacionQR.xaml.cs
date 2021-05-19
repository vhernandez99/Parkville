using Parkville.Models;
using Parkville.Services;
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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReservacionQR : ContentPage
    {

        public ReservacionQR(int reservationId)
        {
            InitializeComponent();
            GetReservation(reservationId);
        }
        private async void GetReservation(int reservationId)
        {
            var reservation = await ApiService.GetMyReservationDetails(reservationId);
            //string isPaid= reservation.IsPaid.ToString();
            var id= reservation.ReservationId.ToString();
            //var date = reservation.PlayingDate.ToString("dd / MM / yyyy");
            //var movie = reservation.MovieName.ToString();
            //var fullValue = "Id" + " "  + id + " " + "Fecha de funcion" + " " + date + " " + "Pelicula" + " "  + movie + " " + "Pagado" + " " + isPaid;
            //string[] data = { id, date, movie, isPaid };
            ReservationQR.BarcodeValue = id;
            MovieName.Text = reservation.MovieName;
            PlayingDate.Text = reservation.PlayingDate.ToString("dd/MM/yyyy");

        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}