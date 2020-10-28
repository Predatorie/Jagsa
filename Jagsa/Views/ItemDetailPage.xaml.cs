using System.ComponentModel;
using Xamarin.Forms;
using Jagsa.ViewModels;

namespace Jagsa.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}