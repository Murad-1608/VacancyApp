using MobileUI.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MobileUI.Views
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