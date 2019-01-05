using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using WaterWatchXamarinApp.Services;
using WaterWatchXamarinApp.Views;


namespace WaterWatchXamarinApp.ViewModels
{
    public class RegisterViewModel
    {
        ApiService _apiService = new ApiService();
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Message { get; set; }


        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async() =>
                {
                    var isSuccess = await _apiService.RegisterUser(Email, Password, ConfirmPassword);

                    if (isSuccess)
                    {
                        //This message property do not show in UI, have no idea what I'm I missing
                        Message = "Register successfully";
                    }
                   
                    else
                        Message = "Retry later";
                });
                
            }
             
    }
    }
}
