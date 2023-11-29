namespace DojonEtWiki.View;

public partial class Creation : ContentPage
{
	public Creation()
	{
		InitializeComponent();
	}

    private async void creer_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreerCampagne());

    }
}