namespace DojonEtWiki.View;

public partial class WikiList : ContentPage
{
	public WikiList()
	{
		InitializeComponent();
	}

	private async void Campagne_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new InfoCampagne());
			
	}

	private async void Perso_Clicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new InfoPerso());
    }

	private async void Monstre_Clicked(object sender, EventArgs e)
	{

	}

	private async void Arme_Clicked(object sender, EventArgs e)
	{

	}

	private async void Armure_Clicked(object sender, EventArgs e)
	{

	}

	private async void Classes_Clicked(object sender, EventArgs e)
	{

	}

	private async void Enchantement_Clicked(object sender, EventArgs e)
	{

	}

	private async void PNJ_Clicked(object sender, EventArgs e)
	{

	}

	private async void Race_Clicked(object sender, EventArgs e)
	{

	}
}