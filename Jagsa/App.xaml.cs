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
    using System.Reflection;
    using TinyNavigationHelper.Forms;
    using TinyNavigationHelper;
    using Jagsa.Services;
    using TinyMvvm.IoC;
    using Autofac;
    using TinyMvvm;
    using TinyMvvm.Autofac;
    using Jagsa.Extensions;
    using Jagsa.Models;
    using Jagsa.ViewModels;

    public partial class App : Application
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public App()
        {
            InitializeComponent();

            var currentAssembly = Assembly.GetExecutingAssembly();
            var navigationHelper = new ShellNavigationHelper();

            navigationHelper.RegisterViewsInAssembly(currentAssembly);

            // Register our Navigation Helper
            var builder = new ContainerBuilder();
            builder.RegisterInstance<INavigationHelper>(navigationHelper);

            // Register all pages and viewmodels
            var appAssembly = typeof(App).GetTypeInfo().Assembly;
            builder.RegisterAssemblyTypes(appAssembly).Where(x => x.IsSubclassOf(typeof(Page)));
            builder.RegisterAssemblyTypes(appAssembly).Where(x => x.IsSubclassOf(typeof(ViewModelBase)));

            // Register our Services
            builder.RegisterInstance(nameof(SteamService));
            builder.RegisterInstance(nameof(TwitchService));
            builder.RegisterInstance(nameof(SmashcastService));

            var container = builder.Build();
            Resolver.SetResolver(new AutofacResolver(container));

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
            var navigationHelper = Resolver.Resolve<INavigationHelper>();

            // If we have saved data from previous session get it and go to the home page
            var id = Xamarin.Essentials.Preferences.Get("steamId", string.Empty);
            if (!string.IsNullOrEmpty(id))
            {
                var user = new User
                {
                    Persona = Xamarin.Essentials.Preferences.Get("personna", string.Empty),
                    Avatar = new Uri(Xamarin.Essentials.Preferences.Get("profileAvatar", string.Empty))
                };

                navigationHelper.NavigateToAsync($"{nameof(HomePageViewModel)}?id={id}", user).Await(this.SuccessHandler, this.ErrorHandler);
            }
            else
            {
                navigationHelper.NavigateToAsync(nameof(LoginPageViewModel));
            }
        }

        /// <summary>
        /// Success callback handler
        /// </summary>
        private void SuccessHandler()
        {
            Debug.Print("Navigation Success");
        }

        /// <summary>
        /// Error callback handler
        /// </summary>
        /// <param name="ex">The exception</param>
        private void ErrorHandler(Exception ex)
        {
            Debug.Print($"Navigation Exception {ex.Message}");
        }
    }
}
