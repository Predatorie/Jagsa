// Bootstrap.cs
//
// Author:
//       mac-dev <aphextwin@gamerunners.co>
//
// Copyright (c) 2020 

namespace Jagsa
{
    using System;
    using System.Reflection;

    using Jagsa.Services;
    using Jagsa.Views;

    using Microsoft.MobCAT;
    using Microsoft.MobCAT.Forms.Services;
    using Microsoft.MobCAT.MVVM.Abstractions;

    public static class Bootstrap
    {
        public static void Begin(Action platformSpecificBegin = null)
        {
            var navigationService = new NavigationService();

            // registers via naming convention ala Prism - Page/PageViewModel
            navigationService.RegisterViewModels(typeof(HomePage).GetTypeInfo().Assembly);

            // MobCAT navigation service
            ServiceContainer.Register<INavigationService>(navigationService);

            // register our services
            ServiceContainer.Register<ISteamService>(new SteamService());
            ServiceContainer.Register<ITwitchService>(new TwitchService());
            ServiceContainer.Register<ISmashcastService>(new SmashcastService());

            // if we have any platform specific registrations this will
            // override what was set above, last man wins.
            platformSpecificBegin?.Invoke();
        }
    }
}
