using Parkville.Services;
using Parkville.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Parkville.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        public int MaxLength { get; set; }
        private string _Username;
        public string Username
        {
            set
            {
                _Username = value;
                OnPropertyChanged();
            }
            get
            {
                return _Username;
            }
        }

        private string _Password;
        public string Password
        {
            set
            {
                _Password = value;
                OnPropertyChanged();
            }
            get
            {
                return _Password;
            }
        }
        private string _ConfirmPassword;
        public string ConfirmPassword
        {
            set
            {
                _ConfirmPassword = value;
                OnPropertyChanged();
            }
            get
            {
                return _ConfirmPassword;
            }
        }



        private string _Email;
        public string Email
        {
            set
            {
                _Email = value;
                OnPropertyChanged();
            }
            get
            {
                return _Email;
            }
        }
        private string _Phonenumber;
        public string Phonenumber
        {
            set
            {
                _Phonenumber = value;
                OnPropertyChanged();
            }
            get
            {
                return _Phonenumber;
            }
        }

        private bool _IsBusy;
        public bool IsBusy
        {
            set
            {
                _IsBusy = value;
                OnPropertyChanged();
            }
            get
            {
                return _IsBusy;
            }
        }

        private bool _ButtonNotbusy =true;
        public bool ButtonNotBusy
        {
            set
            {
                _ButtonNotbusy = value;
                OnPropertyChanged();
            }
            get
            {
                return _ButtonNotbusy;
            }
        }

        public Command SignupCommand { get; set; }
        public Command LoginCommand { get; set; }
        public Command GoToLoginPage { get; set; }
        public Command GoToSignupPage { get; set; }

        public LoginViewModel()
        {
            SignupCommand = new Command(async () => await SignupCommandAsync());
            LoginCommand = new Command(async () => await LoginCommandAsync());
            GoToLoginPage = new Command(async () => await UIViewModel.GoToLoginPageAsync());
            GoToSignupPage = new Command(async () => await UIViewModel.GoToSignupPageAsync());
        }

        private async Task SignupCommandAsync()
        {
            ButtonNotBusy = false;
            if (IsBusy)
                return;
            if (SignUpVerification())
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Favor de verificar su informacion", "Aceptar");
                ButtonNotBusy = true;
                return;
            }
            try
            {
                var tokenFirebase = Preferences.Get("TokenFirebase", string.Empty);
                IsBusy = true;
                var response = await ApiService.RegisterUser(Username, Email, Password, Phonenumber, tokenFirebase);
                IsBusy = false;

                if (response)
                {
                    await Application.Current.MainPage.DisplayAlert("Alerta", "Cuenta creada correctamente", "Aceptar");
                    await Application.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
                    IsBusy = false;
                    ButtonNotBusy = true;
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Correo ya registrado", "Aceptar");
                    IsBusy = false;
                    ButtonNotBusy = true;
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                ButtonNotBusy = true;
            }
            finally
            {
                IsBusy = false;
                ButtonNotBusy = true;
            }
        }
        public bool SignUpVerification()
        {
            var verification = (string.IsNullOrEmpty(_Email) || string.IsNullOrEmpty(_Password) || string.IsNullOrEmpty(_ConfirmPassword) || _ConfirmPassword != _Password||
                Phonenumber.Length<10);
            return verification;
        }
        public bool LoginVerification()
        {
            var verification = (string.IsNullOrEmpty(_Email) || string.IsNullOrEmpty(_Password));
            return verification;
        }

        private async Task LoginCommandAsync()
        {

            ButtonNotBusy = false;
            if (IsBusy)
                return;
            if (LoginVerification())
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Favor de verificar su informacion", "Aceptar");
                ButtonNotBusy = true;
                return;
            }
            try
            {
                var response = await ApiService.Login(Email, Password);
                Preferences.Set("email", Email);
                Preferences.Set("password", Password);
                if (response)
                {
                    //Application.Current.MainPage = new NavigationPage(new HomePage());
                    Application.Current.MainPage = new HomeTabbed();
                    ButtonNotBusy = true;
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Usuario o contraseña incorrecta", "Aceptar");
                    ButtonNotBusy = true;
                }
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
            finally
            {
                IsBusy = false;
                ButtonNotBusy = true;
            }
            
        }





        
        
    }
}
