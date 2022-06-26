using ForbiddenLands.App.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ForbiddenLands.App.Views
{
    public partial class CharacterSheetPage : ContentPageBase
    {
        CharacterSheetViewModel viewModel;

        public CharacterSheetPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new CharacterSheetViewModel();
        }
    }
}