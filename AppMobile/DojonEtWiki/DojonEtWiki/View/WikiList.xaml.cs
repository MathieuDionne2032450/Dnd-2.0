namespace DojonEtWiki.View;
using DojonEtWiki.Api;
using DojonEtWiki.ViewModel;

public partial class WikiList
{
	
	public WikiList()
	{
		InitializeComponent();
	}

	private async void Campagne_Clicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new WikiCampagne());
    }

	private async void Perso_Clicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new WikiPerso());
    }

	private async void Monstre_Clicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new InfoMonstre());
    }

	private async void Arme_Clicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new InfoArmes());
    }

	private async void Armure_Clicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new InfoArmures());
    }

	private async void Classes_Clicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new InfoClasse());
    }

	private async void Enchantement_Clicked(object sender, EventArgs e)
	{
		VMEnchantement vm = new VMEnchantement();
        await Navigation.PushAsync(new InfoEnchantement(vm));
    }

	private async void PNJ_Clicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new WikiPNJ());
    }

	private async void Race_Clicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new WikiRace());
    }
}