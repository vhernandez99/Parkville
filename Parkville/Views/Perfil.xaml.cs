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
            title.Text = "Bienvenido    " + userName;
        }

        private void tapReservaciones_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MyReservations());
        }

        private void tapNosotros_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Nosotros());
        }

        private void tapContactanos_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ContactPage());
        }

        private void tapPreguntas_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new PreguntasFrecuentesPage());
        }

        private void tapPrivacidad_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new PoliticasPage());
        }

        private void tapTerminos_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new TerminosPage());
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