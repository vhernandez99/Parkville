using Microsoft.AppCenter.Analytics;
using Parkville.Models;
using Parkville.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Parkville.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public ObservableCollection<Movie> MoviesCollection { get; set; }
        public ObservableCollection<BannerImage> BannerImagesCollection { get; set; }
        public Command RefreshCommand { get; set; }
        public Command MoviesCommand { get; set; }
        //comentario borrar
        private int PageNumber = 0;
        private bool _isRefreshing;
        public bool IsRefreshing
        {
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
            get => _isRefreshing;
        }
        public HomePageViewModel()
        {
            MoviesCollection = new ObservableCollection<Movie>();
            BannerImagesCollection = new ObservableCollection<BannerImage>();
            RefreshCommand = new Command(ExecuteRefreshCommand);
            GetMovies();
            GetBannerImagesSource();
        }

        public async void GetBannerImagesSource()
        {
            List<BannerImage> ImagesBanner = await ApiService.GetAllBannerImages();
            foreach (BannerImage ImageBanner in ImagesBanner)
            {
                BannerImagesCollection.Add(ImageBanner);
            }
            ImageSource1 = BannerImagesCollection[0].FullImageUrl;
            ImageSource2 = BannerImagesCollection[1].FullImageUrl;
            ImageSource3 = BannerImagesCollection[2].FullImageUrl;
            ImageSource4 = BannerImagesCollection[3].FullImageUrl;
            ImageSource5 = BannerImagesCollection[4].FullImageUrl;
            ImageSource6 = BannerImagesCollection[5].FullImageUrl;
            ImageSource7 = BannerImagesCollection[6].FullImageUrl;
            ImageSource8 = BannerImagesCollection[7].FullImageUrl;
            ImageSource9 = BannerImagesCollection[8].FullImageUrl;
            ImageSource10 = BannerImagesCollection[9].FullImageUrl;
        }

        private void ExecuteRefreshCommand(object obj)
        {
            RefreshMovies();
            IsRefreshing = false;
        }

        public async void GetMovies()
        {
            PageNumber++;
            List<Movie> movies = await ApiService.GetAllMovies(PageNumber, 10);
            foreach (Movie movie in movies)
            {
                MoviesCollection.Add(movie);
            }
        }
        public async void RefreshMovies()
        {
            PageNumber = 0;
            PageNumber++;
            List<Movie> movies = await ApiService.GetAllMovies(PageNumber, 10);
            MoviesCollection.Clear();
            foreach (Movie movie in movies)
            {
                MoviesCollection.Add(movie);
            }
            IsRefreshing = false;
        }


        private string _ImageSource1;
        public string ImageSource1
        {
            set
            {
                _ImageSource1 = value;
                OnPropertyChanged();
            }
            get => _ImageSource1;
        }

        private string _ImageSource2;
        public string ImageSource2
        {
            set
            {
                _ImageSource2 = value;
                OnPropertyChanged();
            }
            get => _ImageSource2;
        }

        private string _ImageSource3;
        public string ImageSource3
        {
            set
            {
                _ImageSource3 = value;
                OnPropertyChanged();
            }
            get => _ImageSource3;
        }

        private string _ImageSource4;
        public string ImageSource4
        {
            set
            {
                _ImageSource4 = value;
                OnPropertyChanged();
            }
            get => _ImageSource4;
        }

        private string _ImageSource5;
        public string ImageSource5
        {
            set
            {
                _ImageSource5 = value;
                OnPropertyChanged();
            }
            get => _ImageSource5;
        }

        private string _ImageSource6;
        public string ImageSource6
        {
            set
            {
                _ImageSource6 = value;
                OnPropertyChanged();
            }
            get => _ImageSource6;
        }

        private string _ImageSource7;
        public string ImageSource7
        {
            set
            {
                _ImageSource7 = value;
                OnPropertyChanged();
            }
            get => _ImageSource7;
        }

        private string _ImageSource8;
        public string ImageSource8
        {
            set
            {
                _ImageSource8 = value;
                OnPropertyChanged();
            }
            get => _ImageSource8;
        }

        private string _ImageSource9;
        public string ImageSource9
        {
            set
            {
                _ImageSource9 = value;
                OnPropertyChanged();
            }
            get => _ImageSource9;
        }

        private string _ImageSource10;
        public string ImageSource10
        {
            set
            {
                _ImageSource10 = value;
                OnPropertyChanged();
            }
            get => _ImageSource10;
        }
    }
}
