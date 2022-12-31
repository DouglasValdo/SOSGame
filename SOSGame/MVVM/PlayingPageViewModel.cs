using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SOSGame.Controls.Custom;
using SOSGame.Shared.BusinessLogic;
using System.Windows.Input;

namespace SOSGame.MVVM;

public partial class PlayingPageViewModel : ObservableObject
{
    public SOSGameContext SOSGameContext { get; private set; }
    public List<BoxEntity> BoxesToDraw { get; private set; }
    private Layout _boxContainer;
    readonly IGameConfigurationEntity config;
    private LetterChooser _menuSelectLetter;

    public PlayingPageViewModel(Layout boxContainer, LetterChooser menuSelectLetter)
    {
        _boxContainer       = boxContainer;
        _menuSelectLetter   = menuSelectLetter;

        config = new GameConfigurationEntity { GameNumberOfBoxes = 10};

        PlayCommand         = new RelayCommand<BoxEntity>((box) => ExecutePlay(box));
        HowToPlayCommand    = new RelayCommand(ShowModal);
    }

    public void StartGame()
    {
        SOSGameContext = new SOSGameContext(config);
        CreateBoxRepresentations(config);
        AddBoxesToUI();
    }


    private void CreateBoxRepresentations(IGameConfigurationEntity config)
    {
        BoxesToDraw = new List<BoxEntity>();

        foreach (int item in Enumerable.Range(0, config.GameNumberOfBoxes))
            BoxesToDraw.Add(new BoxEntity { Index = item });
    }

    public ICommand PlayCommand { get; }
    public ICommand HowToPlayCommand { get; }

    private void ExecutePlay(BoxEntity box)
    {
        SOSGameContext.Play(box);
    }

    private void AddBoxesToUI()
    {
        foreach (BoxEntity boxEntity in BoxesToDraw)
        {
            BoxRepresentation bRep = new(new(boxEntity, _menuSelectLetter));
            _boxContainer.Children.Add(bRep);
        }
    }

    private void ShowModal()
    {
        Shell.Current.DisplayAlert("How to Play!", "To win the game click on the box to select a letter 'S' or 'O'" +
            ". If u write 'SOS' you win the game.", "Close");
    }
}
