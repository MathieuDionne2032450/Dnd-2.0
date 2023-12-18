using DojonEtWiki.ViewModel;

namespace DojonEtWiki.View;

public partial class InfoCampagne : ContentPage
{
	public InfoCampagne(VMCampagne vm)
	{
		InitializeComponent();
    }

    private async void listPerso(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InfoPerso());
    }
}