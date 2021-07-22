using Parkville.Models;
using Parkville.Services;
using System;
using System.Collections.Generic;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Parkville.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieDetailPage : ContentPage
    {
        public MovieDetail movie;
        private readonly int IdMovie;
        public MovieDetailPage(int movieId)
        {
            InitializeComponent();
            GetMovieDetail(movieId);
            IdMovie = movieId;
        }
       
        private async void GetMovieDetail(int movieId)
        {
            movie = await ApiService.GetMovieDetail(movieId);
            Title = movie.Name;
            ImgMovie.Source = movie.FullImageUrl;
            ImgMovieCover.Source = movie.FullImageUrl;
            ////LblMovieName.Text = movie.Name;
            LblGenre.Text = movie.Genre;
            ////LblRating.Text = movie.Rating.ToString();
            LblLanguage.Text = movie.Language;
            LblDuration.Text = movie.Duration;

            ////StringFormat='{0:dd/MM/yy}'}
            ////LblPlayingDate.Text = movie.PlayingDate.ToString("dd/MM/yyyy");
            ////LblPlayingTime.Text = movie.PlayingTime.ToString("hh:mm tt");
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

            LblTicketPrice.Text = "$" + movie.TicketPrice;
            //LblMovieDescription.Text = movie.Description;

            //
        }
        

        private void ImgBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private async void TapVideo_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VideoPlayerPage(movie.TrailorUrl));
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.ShowPopup(new SinopsisPopup(movie.Description));
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (pickerfunciones.SelectedIndex == -1)
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
                        MovieId = movie.Id,
                        Qty = 1,
                        Price = movie.TicketPrice,
                        IsPaid = "No",
                        IsUsed = "No",
                        HorarioDePelicula = pickerfunciones.Items[pickerfunciones.SelectedIndex]
                    };
                    bool response = await ApiService.ReserveMovieTicket(reservation);
                    if (response)
                    {
                        await DisplayAlert("", "Tu boleto ha sido reservado, favor de pagar", "Ok");
                        await Navigation.PushAsync(new PaymentView());
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
    }
}