using Plugin.Clipboard;
using System;
using Xamarin.Forms;
using Xamarin.Forms.OpenWhatsApp;
using Xamarin.Forms.Xaml;

namespace Parkville.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentView : ContentPage
    {
        public PaymentView()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Chat.Open("+528681309225", "Comprobacion de mi pago por deposito o transferencia");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();

        }
        //borrar
        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            CrossClipboard.Current.SetText(cardNum.Text);
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
            await Navigation.PushAsync(new NavigationPage(new HomeTabbed()));
        }
    }
}