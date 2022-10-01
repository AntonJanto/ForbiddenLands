using ForbiddenLands.App.ViewModels;

namespace ForbiddenLands.App.Views;

public partial class EditTalentPage : ContentPage
{
    private EditTalentViewModel editTalentViewModel;

    public EditTalentPage(EditTalentViewModel editTalentViewModel)
    {
        this.editTalentViewModel = editTalentViewModel;
        InitializeComponent();
        BindingContext = editTalentViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        editTalentViewModel.OnLoad();
    }
}