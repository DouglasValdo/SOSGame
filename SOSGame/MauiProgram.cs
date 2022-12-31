using CommunityToolkit.Maui;
using SOSGame.Shared;

namespace SOSGame;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("Pixelfy.ttf", "Pixelfy");
				fonts.AddFont("Plaguard-ZVnjx.otf", "Plaguard");
			});

        return builder.Build();
	}
}
