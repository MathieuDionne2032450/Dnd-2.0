namespace DojonEtWiki.View;

public partial class CampagneList : ContentPage
{

	public CampagneList()
	{
		InitializeComponent();
	}

	private void Details_Clicked(object sender, EventArgs e)
	{

	}

	private async void Delete_Clicked(object sender, EventArgs e)
	{
		bool answer = await DisplayAlert("Confirmation", "Voulez-vous vraiment supprimer cette campagne?", "Oui, supprimer", "Non");

		if (answer)
		{
			// Utilisateur a cliqu� sur Oui
		}
		else
		{
            // Utilisateur a cliqu� sur Non
        }
    }

	private void NouvelleCampagne_Clicked(object sender, EventArgs e)
	{

	}
}