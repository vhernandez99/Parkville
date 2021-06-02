using Parkville.Models;
using Parkville.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Parkville.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReservationPage : ContentPage
    {
        private int ticketPrice;
        private int movieId;
        public ReservationPage(MovieDetail movie)
        {
            InitializeComponent();
            LblMovieName.Text= movie.Name;
            LblGenre.Text = movie.Genre;
            LblRating.Text = movie.Rating.ToString();
            LblLanguage.Text = movie.Language;
            LblDuration.Text = movie.Duration;
            ImgMovie.Source = movie.FullImageUrl;
            SpanPrice.Text =SpanTotalPrice.Text= movie.TicketPrice.ToString();
            ticketPrice = movie.TicketPrice;
            movieId = movie.Id;
        }

        private void PickerQty_SelectedIndexChanged(object sender, EventArgs e)
        {
            var qty=PickerQty.Items[PickerQty.SelectedIndex];
            SpanQty.Text = qty;
            int totalprice=Convert.ToInt16(SpanQty.Text) * ticketPrice;
            SpanTotalPrice.Text = totalprice.ToString();
        }

        private void ImgReserve_Tapped(object sender, EventArgs e)
        {

            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Alerta", "Realmente desea hacer una reservacion?", "Si", "No");
                if (result)
                {
                    var reservation = new Reservation
                    {
                        UserId = Preferences.Get("userId", 0),
                        MovieId = movieId,
                        Qty = Convert.ToInt32(SpanQty.Text),
                        Price = Convert.ToInt32(SpanTotalPrice.Text),
                        IsPaid = "No",
                        IsUsed = "No"
                    };
                    var response = await ApiService.ReserveMovieTicket(reservation);
                    if (response)
                    {
                        await DisplayAlert("", "Tu ticket ha sido reservado, favor de pagar", "Ok");
                        await Navigation.PushModalAsync(new PaymentView());
                    }
                    else
                    {
                        await DisplayAlert("Error", "Algo salio mal", "Cancel");
                    }
                }
                else
                {
                    return;
                }
            });
            
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}