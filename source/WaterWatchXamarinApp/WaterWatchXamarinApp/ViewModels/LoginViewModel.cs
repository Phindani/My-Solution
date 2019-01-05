using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using WaterWatchXamarinApp.Services;

namespace WaterWatchXamarinApp.ViewModels
{
    public class LoginViewModel
    {
        private ApiService _apiService = new ApiService();

        public string Username { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async() =>
                {
                    var isSuccess = await _apiService.LoginUser(Username, Password);
                    if (isSuccess)
                    {
                        //Had difficulties navigating to TabsPage 
                    }
                    else
                    {
                        //This message property do not show in UI, have no idea what I'm I missing
                        Message = "Login failed, Retry later";
                    }
                });
            }
        }
    }
}
