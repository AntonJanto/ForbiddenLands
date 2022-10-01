using ForbiddenLands.App.Views;

namespace ForbiddenLands.App;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute("talent", typeof(EditTalentPage));
	}
}
