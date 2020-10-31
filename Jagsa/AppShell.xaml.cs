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

            // Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
