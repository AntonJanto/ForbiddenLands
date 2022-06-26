using ForbiddenLands.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ForbiddenLands.App.Views
{
    public class ContentPageBase : ContentPage
    {
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is BaseViewModel vmb)
            {
                await vmb.OnAppearing();
            }
        }
    }
}
