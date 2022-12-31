using SOSGame.MVVM;

namespace SOSGame.Controls.Pages;

public partial class MainMenuPage : ContentPage
{
	public MainMenuPage()
	{
		InitializeComponent();
		BindingContext = new MainMenuPageViewModel();
	}
}