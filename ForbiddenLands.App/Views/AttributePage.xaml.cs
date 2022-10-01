using ForbiddenLands.App.ViewModels;

namespace ForbiddenLands.App.Views;

public partial class AttributePage : ContentPage
{
	private AttributeViewModel attributeViewModel;

    public AttributePage(AttributeViewModel attributeViewModel)
	{
        this.attributeViewModel = attributeViewModel;
		InitializeComponent();
		BindingContext = attributeViewModel;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		attributeViewModel.OnLoad();
	}
}