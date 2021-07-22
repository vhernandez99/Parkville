using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Gms.Common;
using Xamarin.Essentials;
using MediaManager;
using PanCardView.Droid;
using Android.Views;
using Xamarin.Forms.Xaml;

namespace Parkville.Droid
{
    [Activity(Label = "Parkville", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            //Pantalla completa
            //if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
            //{
            //    Window.SetFlags(WindowManagerFlags.LayoutNoLimits, WindowManagerFlags.LayoutNoLimits);
            //    Window.AddFlags(WindowManagerFlags.Fullscreen);
            //    Window.ClearFlags(WindowManagerFlags.ForceNotFullscreen);
            //}
            
            CrossMediaManager.Current.Init(this);
            IsplayServicesAvailable();

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            CardsViewRenderer.Preserve();
            bool flag = false;
            if (Intent.Extras != null)
            {
                flag = true;
            }
            LoadApplication(new App(flag));
            Window.SetStatusBarColor(Android.Graphics.Color.Argb(255, 191, 0, 0));

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void IsplayServicesAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            bool isGooglePlayService = resultCode != ConnectionResult.Success;
            Preferences.Set("isGooglePlayService", isGooglePlayService);
        }

    }
}