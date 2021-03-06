using Parkville.Models;
using Parkville.Services;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Parkville.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReservationPage : ContentPage
    {

        private readonly int ticketPrice;
        private readonly int movieId;
        public ReservationPage(MovieDetail movie)
        {
            InitializeComponent();
            LblMovieName.Text = movie.Name;
            LblGenre.Text = movie.Genre;
            LblRating.Text = movie.Rating.ToString();
            LblLanguage.Text = movie.Language;
            LblDuration.Text = movie.Duration;
            ImgMovie.Source = movie.FullImageUrl;
            SpanPrice.Text = SpanTotalPrice.Text = movie.TicketPrice.ToString();
            ticketPrice = movie.TicketPrice;
            movieId = movie.Id;

            List<string> funcionesList = new List<string>();
            if (movie.PlayingDate.ToString() != "1/1/1900 12:00:00 AM")
            {
                funcionesList.Add(movie.PlayingDate.ToString("dd/MM/yyyy") + " " + movie.PlayingTime.ToString("hh:mm tt"));
            }
            if (movie.PlayingDate2.ToString() != "1/1/1900 12:00:00 AM")
            {
                funcionesList.Add(movie.PlayingDate2.ToString("dd/MM/yyyy") + " " + movie.PlayingTime2.ToString("hh:mm tt"));
            }
            if (movie.PlayingDate3.ToString() != "1/1/1900 12:00:00 AM")
            {
                funcionesList.Add(movie.PlayingDate3.ToString("dd/MM/yyyy") + " " + movie.PlayingTime3.ToString("hh:mm tt"));
            }
            if (movie.PlayingDate4.ToString() != "1/1/1900 12:00:00 AM")
            {
                funcionesList.Add(movie.PlayingDate4.ToString("dd/MM/yyyy") + " " + movie.PlayingTime4.ToString("hh:mm tt"));
            }
            if (movie.PlayingDate5.ToString() != "1/1/1900 12:00:00 AM")
            {
                funcionesList.Add(movie.PlayingDate5.ToString("dd/MM/yyyy") + " " + movie.PlayingTime5.ToString("hh:mm tt"));
            }
            pickerfunciones.ItemsSource = funcionesList;
            pickerfunciones.SelectedIndex = 0;
        }

        //private void PickerQty_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var qty=PickerQty.Items[PickerQty.SelectedIndex];
        //    SpanQty.Text = qty;
        //    int totalprice=Convert.ToInt16(SpanQty.Text) * ticketPrice;
        //    SpanTotalPrice.Text = totalprice.ToString();
        //}

        private void ImgReserve_Tapped(object sender, EventArgs e)
        {
            
            Device.BeginInvokeOnMainThread(async () =>
            {
                if(pickerfunciones.SelectedIndex == -1)
                {
                    await DisplayAlert("", "Favor de seleccionar una función", "Ok");
                    return;
                }
                bool result = await DisplayAlert("", "¿Realmente desea comprar un boleto?", "Si", "No");
                if (result)
                {
                    Reservation reservation = new Reservation
                    {
                        UserId = Preferences.Get("userId", 0),
                        MovieId = movieId,
                        Qty = Convert.ToInt32(SpanQty.Text),
                        Price = Convert.ToInt32(SpanTotalPrice.Text),
                        IsPaid = "No",
                        IsUsed = "No",
                        HorarioDePelicula = pickerfunciones.Items[pickerfunciones.SelectedIndex]
                    };
                    bool response = await ApiService.ReserveMovieTicket(reservation);
                    if (response)
                    {
                        await DisplayAlert("", "Tu boleto ha sido reservado, favor de pagar", "Ok");
                        await Navigation.PushModalAsync(new PaymentView());
                    }
                    else
                    {
                        await DisplayAlert("", "Algo salio mal", "Intentar de nuevo");
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