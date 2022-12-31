using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SOSGame.Controls.Custom;
using SOSGame.Controls.Pages;
using SOSGame.Shared.BusinessLogic;
using System.Windows.Input;

namespace SOSGame.MVVM;

public partial class LetterChooserViewModel : ObservableObject
{
    [ObservableProperty]
    private bool isMenuChooseLetterVisible;
    public BoxRepresentationViewModel ClickedBox { get; set; }
    private SOSGameContext _context;

    public LetterChooserViewModel(SOSGameContext context)
    {
        _context = context;
        LetterSClickedCommand = new RelayCommand(LetterSClicked);
        LetterOClickedCommand = new RelayCommand(LetterOClicked);
    }

    public ICommand LetterSClickedCommand { get;}
    public ICommand LetterOClickedCommand { get; }

    private void LetterSClicked()
    {
        ClickedBox.SelectedText = "S";
        ClickedBox.BoxEntity.Letter = 'S';
        ClickedBox.IsEnabled = false;
        IsMenuChooseLetterVisible = false;

        //when u play boolean is return if is SOS 
        if (_context.Play(ClickedBox.BoxEntity) == true)
            Shell.Current.ShowPopup(new WinnerPopUp());
    }

    private void LetterOClicked()
    {
        ClickedBox.SelectedText = "O";
        ClickedBox.BoxEntity.Letter = 'O';
        ClickedBox.IsEnabled = false;
        IsMenuChooseLetterVisible = false;

        //when u play boolean is return if is SOS 
        if (_context.Play(ClickedBox.BoxEntity) == true)
            Shell.Current.GoToAsync($"//{nameof(WinnerPage)}");
    }
}
