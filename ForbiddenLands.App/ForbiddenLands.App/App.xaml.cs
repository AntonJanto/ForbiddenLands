using ForbiddenLands.App.Data;
using ForbiddenLands.Core.Managers;
using ForbiddenLands.Core.Services;
using ForbiddenLands.Data.FileSystem;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ForbiddenLands.App
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            FileDataStore datastore = new FileDataStore();
            Task.Run(() => datastore.LoadCharacters());
            DependencyService.RegisterSingleton<IDataStore>(datastore);
            DependencyService.Register<CharacterSheetManager>();
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
