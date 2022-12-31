using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SOSGame.Controls.Custom;
using SOSGame.Shared.BusinessLogic;
using System.Windows.Input;

namespace SOSGame.MVVM;

public partial class BoxRepresentationViewModel : ObservableObject
{
    [ObservableProperty]
    private BoxEntity boxEntity;
    [ObservableProperty]
    private bool isEnabled = true;
    [ObservableProperty]
    private string selectedText;

    private readonly LetterChooser _letterChooserViewModel;

    public BoxRepresentationViewModel(BoxEntity box, LetterChooser letterChooserControl)
    {
        _letterChooserViewModel = letterChooserControl;
        boxEntity = box;
        BoxButtonCommand = new RelayCommand(BoxButtonClick);
    }

    public ICommand BoxButtonCommand { get; set; }

    private void BoxButtonClick()
    {
        LetterChooserViewModel viewModel = (LetterChooserViewModel)_letterChooserViewModel.BindingContext;

        viewModel.IsMenuChooseLetterVisible = !viewModel.IsMenuChooseLetterVisible;

        viewModel.ClickedBox = this;
    }
}
