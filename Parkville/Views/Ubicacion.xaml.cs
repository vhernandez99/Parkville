using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
namespace Parkville.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ubicacion : ContentPage
    {
        public double lng = -97.51318821146145;
        public double lat = 25.826882099746477;
        public Ubicacion()
        {
            InitializeComponent();
        }

        private async void ruta_Clicked(object sender, EventArgs e)
        {
            await Map.OpenAsync(lat, lng, new MapLaunchOptions
            {
                Name = "Parkville Autocinema",
                NavigationMode = NavigationMode.Driving
            });
        }

        private async void ubicacion_Clicked(object sender, EventArgs e)
        {
            await Map.OpenAsync(lat, lng, new MapLaunchOptions
            {
                Name = "Parkville Autocinema",
                NavigationMode = NavigationMode.None
            });
        }
    }
}