using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WaterWatchXamarinApp.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace WaterWatchXamarinApp.Services
{
    public class ApiService
    {
        public async Task<bool> LoginUser(string userName, string passWord)
        {
            var keyValues = new List<KeyValuePair<string, string>>();
            {
                keyValues.Add(new KeyValuePair<string, string>("username", userName));
                keyValues.Add(new KeyValuePair<string, string>("password", passWord));
                keyValues.Add(new KeyValuePair<string, string>("grant_type", "password"));

            };
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:52884/Token");
            request.Content = new FormUrlEncodedContent(keyValues);
            var httpclient = new HttpClient();
            var respond = await httpclient.SendAsync(request);

            Debug.WriteLine(await respond.Content.ReadAsStringAsync());

            return respond.IsSuccessStatusCode;
        }


        public async Task<bool> RegisterUser(string email, string password, string confirmPassword)
        {
            var httpClient = new HttpClient();

            var registerModel = new RegisterBindingModel
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword

            };
            var json = JsonConvert.SerializeObject(registerModel);
            HttpContent HttpContent = new StringContent(json);
            HttpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var respond= await httpClient.PostAsync("http://localhost:52884/api/Account/Register", HttpContent);

            return respond.IsSuccessStatusCode;

        }
    }
}
