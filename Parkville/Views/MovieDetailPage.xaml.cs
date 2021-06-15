using Parkville.Models;
using Parkville.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Parkville.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieDetailPage : ContentPage
    {
        public MovieDetail movie;
        public MovieDetailPage(int movieId)
        {
            InitializeComponent();
            GetMovieDetail(movieId);
        }
        private async void GetMovieDetail(int movieId)
        {
            movie= await ApiService.GetMovieDetail(movieId);
            LblMovieName.Text = movie.Name;
            LblGenre.Text = movie.Genre;
            LblRating.Text = movie.Rating.ToString();
            LblLanguage.Text = movie.Language;
            LblDuration.Text = movie.Duration;
            //StringFormat='{0:dd/MM/yy}'}
            LblPlayingDate.Text = movie.PlayingDate.ToString("dd/MM/yyyy");
            LblPlayingTime.Text = movie.PlayingTime.ToString("hh:mm tt");
            LblPlayingDate2.Text = movie.PlayingDate2.ToString("dd/MM/yyyy");
            LblPlayingTime2.Text = movie.PlayingTime2.ToString("hh:mm tt");
            LblPlayingDate3.Text = movie.PlayingDate3.ToString("dd/MM/yyyy");
            LblPlayingTime3.Text = movie.PlayingTime3.ToString("hh:mm tt");
            LblPlayingDate4.Text = movie.PlayingDate4.ToString("dd/MM/yyyy");
            LblPlayingTime4.Text = movie.PlayingTime4.ToString("hh:mm tt");
            LblPlayingDate5.Text = movie.PlayingDate5.ToString("dd/MM/yyyy");
            LblPlayingTime5.Text = movie.PlayingTime5.ToString("hh:mm tt");
            //2022-05-12T00:00:00
            //2021-04-11T19:00:00


            LblTicketPrice.Text = "$" + movie.TicketPrice;
            LblMovieDescription.Text = movie.Description;
            ImgMovie.Source = movie.FullImageUrl;
            ImgMovieCover.Source = movie.FullImageUrl;
        }

        private void ImgBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void TapVideo_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new VideoPlayerPage(movie.TrailorUrl));
        }

        private void ImgBookTicket_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ReservationPage(movie));
        }
    }
}