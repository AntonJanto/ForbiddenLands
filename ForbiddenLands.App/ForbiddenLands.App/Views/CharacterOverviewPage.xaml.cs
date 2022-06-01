using ForbiddenLands.App.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ForbiddenLands.App.Views
{
    public partial class CharacterOverviewPage : ContentPage
    {
        private CharacterOverviewViewModel viewModel;

        public CharacterOverviewPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new CharacterOverviewViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
}