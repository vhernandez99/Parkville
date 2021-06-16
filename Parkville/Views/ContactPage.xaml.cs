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
    public partial class ContactPage : ContentPage
    {
        public ContactPage()
        {
            InitializeComponent();
        }

        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void BtnCall_Clicked(object sender, EventArgs e)
        {
            PhoneDialer.Open("8681309225");
        }

        private void BtnCall2_Clicked(object sender, EventArgs e)
        {
            PhoneDialer.Open("8681335196");
        }

        private void BtnCall3_Clicked(object sender, EventArgs e)
        {
            PhoneDialer.Open("8682270834");
        }
    }
}