// App.xaml.cs
//
// Author:
//       <aphextwin@gamerunners.co>
//
// Copyright (c) 2020 

namespace Jagsa
{
    using Xamarin.Forms;
    using System;
    using System.Diagnostics;
    using Jagsa.Extensions;

    public partial class App : Application
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            // Login or Home Page
            this.OnInit();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        /// <summary>
        /// Determine whether to show login or home screen from saved preferences.
        /// </summary>
        private void OnInit()
        {
            // If we have saved data from previous session get it and go to the home page
            var id = Xamarin.Essentials.Preferences.Get("steamId", string.Empty);
            if (!string.IsNullOrEmpty(id))
            {
                var args =
                           $"personna={Xamarin.Essentials.Preferences.Get("personna", string.Empty)}" +
                           $"&profileAvatar={Xamarin.Essentials.Preferences.Get("profileAvatar", string.Empty)}" +
                           $"&steamId={id}";

                Shell.Current.GoToAsync($"//home/?{args}").Await(this.SuccessHandler, this.ErrorHandler);
            }
            else
            {
                Shell.Current.GoToAsync("//login").Await(this.SuccessHandler, this.ErrorHandler);
            }
        }

        /// <summary>
        /// Success callback handler
        /// </summary>
        private void SuccessHandler()
        {
            Debug.Print("Navigation Success!");
        }

        /// <summary>
        /// Error callback handler
        /// </summary>
        /// <param name="ex">The exception</param>
        private void ErrorHandler(Exception ex)
        {
            Debug.Print($"Navigation Exception! {ex.Message}");
        }
    }
}
