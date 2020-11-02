
using Jagsa.ViewModels;

using Xamarin.Forms.Xaml;

namespace Jagsa.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : TinyMvvm.Forms.ShellViewBase<LoginPageViewModel>
    {
        public LoginPage()
        {
            InitializeComponent();
        }
    }
}