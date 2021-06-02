using Parkville.Models;
using Parkville.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Parkville.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        
        public ObservableCollection<Movie> MoviesCollection { get; set; }
        public Command RefreshCommand { get; set; }
        public Command MoviesCommand { get; set; }

        private int PageNumber = 0;

        bool _isRefreshing;
        public bool IsRefreshing
        {
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
            get
            {
                return _isRefreshing;
            }
        }
        public HomePageViewModel()
        {
            MoviesCollection = new ObservableCollection<Movie>();
            
            RefreshCommand = new Command(ExecuteRefreshCommand);
            GetMovies();
            
        }
        private void ExecuteRefreshCommand(object obj)
        {
            RefreshMovies();
            IsRefreshing = false;
        }

        public async void GetMovies()
        {
            PageNumber++;
            var movies = await ApiService.GetAllMovies(PageNumber, 5);
            foreach (var movie in movies)
            {
                MoviesCollection.Add(movie);
            }
        }
        public async void RefreshMovies()
        {
            PageNumber = 0;
            PageNumber++;
            var movies = await ApiService.GetAllMovies(PageNumber,5);
            MoviesCollection.Clear();
            foreach(var movie in movies)
            {
                MoviesCollection.Add(movie);
            }
            IsRefreshing = false;
        }
        
    }
}
