using ForbiddenLands.App.Models;
using ForbiddenLands.App.ViewModels;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace ForbiddenLands.App.Views;

public partial class TalentPage : ContentPage
{
    private TalentsViewModel talentsViewModel;

    public TalentPage(TalentsViewModel talentsViewModel)
    {
        this.talentsViewModel = talentsViewModel;
        InitializeComponent();
        BindingContext = talentsViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        talentsViewModel.OnLoad();
    }
}