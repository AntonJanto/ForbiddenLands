using ForbiddenLands.App.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ForbiddenLands.App.Views
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