// LoginPage.xaml.cs
//
// Author:
//       <aphextwin@gamerunners.co>
//
// Copyright (c) 2020 

namespace Jagsa.Views
{
    using Jagsa.ViewModels;

    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : TinyMvvm.Forms.ShellViewBase<LoginPageViewModel>
    {
        public LoginPage()
        {
            InitializeComponent();
        }
    }
}