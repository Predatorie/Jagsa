using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Jagsa.ViewModels;

using Microsoft.MobCAT.Forms.Pages;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jagsa.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : BaseContentPage<LoginPageViewModel>
    {
        public LoginPage()
        {
            InitializeComponent();
        }
    }
}