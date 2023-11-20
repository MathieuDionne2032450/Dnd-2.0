namespace DojonEtWiki.View;

public partial class inscription : ContentPage
{
	public inscription()
	{
		InitializeComponent();
	}


    private async void Inscription_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
    
}