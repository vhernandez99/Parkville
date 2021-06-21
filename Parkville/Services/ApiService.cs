using Newtonsoft.Json;
using Parkville.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UnixTimeStamp;
using Xamarin.Essentials;

namespace Parkville.Services
{
    public static class ApiService
    {
        public static async Task<bool> RegisterUser(string name, string email, string password, string phoneNumber, string tokenFirebase)
        {
            var register = new Register()
            {
                Name = name,
                Email = email,
                Password = password,
                PhoneNumber = phoneNumber,
                TokenFirebase = tokenFirebase
            };
            var httpClient = new HttpClient();
            var jsonRegister = JsonConvert.SerializeObject(register);
            var content = new StringContent(jsonRegister, Encoding.UTF8, "application/json");
            var ApiResponse = await httpClient.PostAsync(AppSettings.ApiUrl + "api/users/Register", content);
            if (!ApiResponse.IsSuccessStatusCode) return false;
            return true;
        }
        public static async Task<bool> Login(string email, string password)
        {
            var login = new Login()
            {
                Email = email,
                Password = password
            };
            var httpclient = new HttpClient();
            var jsonRegister = JsonConvert.SerializeObject(login);
            var content = new StringContent(jsonRegister, Encoding.UTF8, "application/json");
            var ApiResponse = await httpclient.PostAsync(AppSettings.ApiUrl + "api/users/login", content);
            if (!ApiResponse.IsSuccessStatusCode) return false;
            var jsonresult = await ApiResponse.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Token>(jsonresult);
            Preferences.Set("accessToken", result.Access_token);
            Preferences.Set("userId", result.User_id);
            Preferences.Set("userName", result.User_Name);
            Preferences.Set("tokenExpirationTime", result.Expiration_Time);
            Preferences.Set("currentTime", UnixTime.GetCurrentTime());
            return true;
        }
        public static async Task<List<Movie>> GetAllMovies(int pageNumber, int pageSize)
        {
            await TokenValidator.CheckTokenValidity();
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + string.Format("api/movies/AllMovies?sort=asc&pageNumber={0}&pageSize={1}", pageNumber, pageSize));
            return JsonConvert.DeserializeObject<List<Movie>>(response);
        }

        public static async Task<List<BannerImage>> GetAllBannerImages()
        {
            await TokenValidator.CheckTokenValidity();
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + string.Format("api/movies/AllBannerImages"));
            return JsonConvert.DeserializeObject<List<BannerImage>>(response);
        }
        public static async Task<MovieDetail> GetMovieDetail(int movieId)
        {
            await TokenValidator.CheckTokenValidity();
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "api/movies/MovieDetail/" + movieId);
            return JsonConvert.DeserializeObject<MovieDetail>(response);
        }
        public static async Task<List<FindMovie>> FindMovies(string movieName)
        {
            await TokenValidator.CheckTokenValidity();
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "api/movies/FindMovies?movieName=" + movieName);
            return JsonConvert.DeserializeObject<List<FindMovie>>(response);
        }
        public static async Task<bool> ReserveMovieTicket(Reservation reservation)
        {
            await TokenValidator.CheckTokenValidity();
            var httpClient = new HttpClient();
            var jsonRegister = JsonConvert.SerializeObject(reservation);
            var content = new StringContent(jsonRegister, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var ApiResponse = await httpClient.PostAsync(AppSettings.ApiUrl + "api/reservations/CreateReservation", content);
            if (!ApiResponse.IsSuccessStatusCode) return false;
            return true;
        }
        public static async Task<List<UserReservations>> GetMyReservations()
        {
            await TokenValidator.CheckTokenValidity();
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var userId = Preferences.Get("userId", 0);
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "api/reservations/GetMyReservations/" + userId);
            return JsonConvert.DeserializeObject<List<UserReservations>>(response);
        }
        public static async Task<UserReservations> GetMyReservationDetails(int reservationId)
        {
            await TokenValidator.CheckTokenValidity();
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "api/reservations/GetMyReservationDetails/" + reservationId);
            return JsonConvert.DeserializeObject<UserReservations>(response);
        }
    }
    public static class TokenValidator
    {
        public static async Task CheckTokenValidity()
        {
            var expirationTime = Preferences.Get("tokenExpiration", 0);
            Preferences.Set("currentTime", UnixTime.GetCurrentTime());
            var currentTime = Preferences.Get("currentTime", 0);
            if (expirationTime < currentTime)
            {
                var email = Preferences.Get("email", string.Empty);
                var password = Preferences.Get("password", string.Empty);
                await ApiService.Login(email, password);
            }
        }
    }
}