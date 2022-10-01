using ForbiddenLands.App.Models;
using ForbiddenLands.App.Options;
using ForbiddenLands.App.Services.Navigation;
using ForbiddenLands.App.ViewModels;
using ForbiddenLands.App.Views;
using JsonFlatFileDataStore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace ForbiddenLands.App;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureEssentials()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("skullz.ttf", "skullz");
                fonts.AddFont("IMFellDWPicaSC-Regular.ttf", "FellPicaRegular");
            });

        using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ForbiddenLands.App.appsettings.json");
        var configRoot = new ConfigurationBuilder()
            .AddJsonStream(stream)
            .Build();
        var jsonFlatFileOptions = configRoot.GetSection(nameof(JsonFlatFileOptions)).Get<JsonFlatFileOptions>();
        builder.Configuration.AddConfiguration(configRoot);

        builder.Services
            .AddTransient<AttributePage>()
            .AddTransient<TalentPage>()
            .AddTransient<EditTalentPage>();

        builder.Services
            .AddTransient<AttributeViewModel>()
            .AddTransient<EditTalentViewModel>()
            .AddTransient<TalentsViewModel>();

        builder.Services.AddSingleton<INavigationService, MauiNavigationService>();
        builder.Services
            .AddSingleton<IDataStore>((svc) =>
            {
                var ds = new DataStore(
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), jsonFlatFileOptions.Path),
                    jsonFlatFileOptions.UseLowerCamelCase, 
                    jsonFlatFileOptions.KeyProperty, 
                    jsonFlatFileOptions.ReloadBeforeGetCollection, 
                    null);

                try
                {
                    ds.GetItem<Attributes>(nameof(Attributes));
                }
                catch (KeyNotFoundException)
                {
                    ds.InsertItem(nameof(Attributes), new Attributes());
                }
                return ds;
            });

        return builder.Build();
    }
}
