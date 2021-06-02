using Parkville.Models;
using Parkville.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Parkville.ViewModels
{
    public class PerfilViewModel:BaseViewModel
    {
        
        public PerfilViewModel() 
        {
            
            
            BannerImagesCollection = new ObservableCollection<BannerImage>();
            AsignImagesResource();
        }
        public ObservableCollection<BannerImage> BannerImagesCollection { get; set; }
        string _ImageSource1;

        
        public string ImageSource1
        {
            set
            {
                _ImageSource1 = value;
                OnPropertyChanged();
            }
            get
            {
                return _ImageSource1;
            }
        }

        string _ImageSource2;
        public string ImageSource2
        {
            set
            {
                _ImageSource2 = value;
                OnPropertyChanged();
            }
            get
            {
                return _ImageSource2;
            }
        }

        string _ImageSource3;
        public string ImageSource3
        {
            set
            {
                _ImageSource3 = value;
                OnPropertyChanged();
            }
            get
            {
                return _ImageSource3;
            }
        }

        string _ImageSource4;
        public string ImageSource4
        {
            set
            {
                _ImageSource4 = value;
                OnPropertyChanged();
            }
            get
            {
                return _ImageSource4;
            }
        }

        string _ImageSource5;
        public string ImageSource5
        {
            set
            {
                _ImageSource5 = value;
                OnPropertyChanged();
            }
            get
            {
                return _ImageSource5;
            }
        }
        public async Task<ObservableCollection<BannerImage>> GetBannerImagesSource()
        {
            var ImagesBanner = await ApiService.GetAllBannerImages();
            foreach (var ImageBanner in ImagesBanner)
            {
                BannerImagesCollection.Add(ImageBanner);
            }
            return BannerImagesCollection;
        }
        private async void AsignImagesResource()
        {
            var source = await GetBannerImagesSource();
            ImageSource1 = source[0].FullImageUrl;
            ImageSource2 = source[1].FullImageUrl;
            ImageSource3 = source[2].FullImageUrl;
            ImageSource4 = source[3].FullImageUrl;
            ImageSource5 = source[4].FullImageUrl;
        }
    }
}
