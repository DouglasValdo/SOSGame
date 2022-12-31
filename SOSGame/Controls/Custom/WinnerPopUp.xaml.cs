using CommunityToolkit.Maui.Views;
using SOSGame.MVVM;

namespace SOSGame.Controls.Custom;

public partial class WinnerPopUp : Popup
{
	public WinnerPopUp()
	{
		InitializeComponent();
		BindingContext = new WinnerPopUpViewModel(this);
		
	}
}