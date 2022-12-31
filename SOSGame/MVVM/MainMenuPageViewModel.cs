using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SOSGame.Controls.Pages;
using System.Windows.Input;

namespace SOSGame.MVVM;

public partial class MainMenuPageViewModel : ObservableObject
{
    public MainMenuPageViewModel()
    {
        PlayCommand = new RelayCommand(GoToPlay);
    }
    public ICommand PlayCommand { get; }

    private void GoToPlay()
    {
        Shell.Current.Navigation.PushAsync(new PlayingPage());
        //Shell.Current.GoToAsync($"//{nameof(PlayingPage)}");
    }
}
