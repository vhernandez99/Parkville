using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Parkville.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SinopsisPopup : Popup
    {
        public SinopsisPopup(string description)
        {
            InitializeComponent();
            descripcionlbl.Text = "Sinopsis:" + description;
        }
        //
        //
    }
}