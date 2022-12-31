using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SOSGame.Controls.Pages;
using SOSGame.Shared.GiphyAPI;
using System.Windows.Input;

namespace SOSGame.MVVM;

public partial class WinnerPopUpViewModel : ObservableObject
{
    [ObservableProperty]
    private string imageUrl;
    private Popup _popup;
    public WinnerPopUpViewModel(Popup popup)
    {
        _popup = popup;

        NetworkAccess accessType = Connectivity.Current.NetworkAccess;

        string url = string.Empty;

        if (accessType == NetworkAccess.Internet)
        {
            Root d = GipHyAPIRequest.SearchWinnerImage();

            int randomImage = new Random().Next(0, d.data.Count - 1);

            url = d.data[randomImage].images?.downsized.url;
        }

        if (string.IsNullOrEmpty(url))
            url = "giphy.png";

        imageUrl = url;

        NewGameCommand = new RelayCommand(NewGame);
    }

    public ICommand NewGameCommand { get; }

    private void NewGame()
    {
        Shell.Current.Navigation.RemovePage(Shell.Current.CurrentPage);
        Shell.Current.Navigation.PushAsync(new PlayingPage());
        _popup?.Close();
    }
}
