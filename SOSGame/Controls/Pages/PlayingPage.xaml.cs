using SOSGame.MVVM;

namespace SOSGame.Controls.Pages;

public partial class PlayingPage : ContentPage
{
	public PlayingPage()
	{
		InitializeComponent();

		var playingPageViewModel = new PlayingPageViewModel(BoxContainer, LetterChooserContainer);
        BindingContext = playingPageViewModel;

        playingPageViewModel.StartGame();
        LetterChooserContainer.BindingContext = new LetterChooserViewModel(playingPageViewModel.SOSGameContext);
    }
}