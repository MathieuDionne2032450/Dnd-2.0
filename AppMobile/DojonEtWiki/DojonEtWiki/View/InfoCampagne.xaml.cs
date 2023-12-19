using DojonEtWiki.ViewModel;

namespace DojonEtWiki.View;

public partial class InfoCampagne : ContentPage
{
	public InfoCampagne()
	{
		InitializeComponent();
    }

    private async void Campagne_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InfoPerso());
    }
}