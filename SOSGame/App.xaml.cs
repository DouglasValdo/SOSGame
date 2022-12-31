using SOSGame.Shared;
namespace SOSGame;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		new ApplicationWindowSizeModifier().Resize();

		MainPage = new AppShell();
	}
}
