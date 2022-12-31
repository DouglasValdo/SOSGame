using SOSGame.MVVM;

namespace SOSGame.Controls.Custom;

public partial class BoxRepresentation : ContentView
{
    public BoxRepresentation(BoxRepresentationViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}