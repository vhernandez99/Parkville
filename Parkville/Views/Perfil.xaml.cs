using Parkville.ViewModels;
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
    public partial class Perfil : ContentPage
    {
        PerfilViewModel pVM;
        public Perfil()
        {
            InitializeComponent();
            pVM = new PerfilViewModel();
            this.BindingContext = pVM;
            var userName= Preferences.Get("userName", string.Empty);
            //title.Text = "Bienvenido    " + userName;
            Title = "Bienvenido " + userName;
            NavigationPage.SetBackButtonTitle(this, "");
           
        }

        private async void tapReservaciones_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MyReservations());
        }

        private async void tapNosotros_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Nosotros());
        }

        private async void tapContactanos_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContactPage());
        }

        private async void tapPreguntas_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PreguntasFrecuentesPage());
        }

        private async void tapPrivacidad_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PoliticasPage());
        }

        private async void tapTerminos_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TerminosPage());
        }

        private void tapCerrar_Tapped(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Alerta", "Realmente desea cerrar sesion?", "Si", "No");
                if (result)
                {
                    Preferences.Set("acessToken", string.Empty);
                    Preferences.Set("tokenExpirationTime", 0);
                    Application.Current.MainPage = new NavigationPage(new SignupPage());
                }
                else
                {
                    return;
                }
            });        
        }
    }
}