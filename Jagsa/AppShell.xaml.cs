using System;
using System.Collections.Generic;

using Jagsa.ViewModels;
using Jagsa.Views;

using Xamarin.Forms;

namespace Jagsa
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            this.RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            // set in xaml?
            //Routing.RegisterRoute("home", typeof(HomePage));
            //Routing.RegisterRoute("library", typeof(LibraryPage));
            //Routing.RegisterRoute("streams", typeof(GameStreamResultsPage));
            //Routing.RegisterRoute("friends", typeof(FriendsPage));
        }
    }
}
