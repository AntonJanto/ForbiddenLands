using ForbiddenLands.App.ViewModels;
using ForbiddenLands.App.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ForbiddenLands.App
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CharacterOverviewPage), typeof(CharacterOverviewPage));
            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
