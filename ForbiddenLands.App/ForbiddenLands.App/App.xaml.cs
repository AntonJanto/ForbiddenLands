using ForbiddenLands.Core.Services;
using ForbiddenLands.Data.File;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ForbiddenLands.App
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<IDataStore, MockCharacterData>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
