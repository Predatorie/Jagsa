// LoginPage.xaml.cs
//
// Author:
//       <aphextwin@gamerunners.co>
//
// Copyright (c) 2020 

namespace Jagsa.Views
{
    using Jagsa.ViewModels;

    using Microsoft.MobCAT.Forms.Pages;

    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : BaseContentPage<LoginPageViewModel>
    {
        public LoginPage()
        {
            InitializeComponent();
        }
    }
}