using DojonEtWiki.Api;
using DojonEtWiki.Model;

namespace DojonEtWiki.View.Arme;

public partial class CreateArme : ContentPage
{
	public CreateArme()
	{
		InitializeComponent();
	}

	private async void OnCreateArmeClicked(object sender, EventArgs e)
	{
		int bonusJet = Convert.ToInt32(EntreeBonusJet.Text);
		int bonusForce = Convert.ToInt32(EntreeBonusForce.Text);
		string nom = EntreeNom.Text;
		int enchantementId = Convert.ToInt32(EntreeEnchantementId.Text);

		using (HttpClient client = new HttpClient())
		{
			try
			{
				string url = "https://c0fnrbvj-7296.use.devtunnels.ms/CreateArme?bonusJet=" + bonusJet + "&bonusForce=" +
					bonusForce + "&nom=" +
					nom + "&enchantementId=" + enchantementId;
				HttpResponseMessage response = await client.GetAsync(url);

				if (response.IsSuccessStatusCode)
				{
					string responseBody = await response.Content.ReadAsStringAsync();
				}
            }
			catch(Exception ex)
			{

			}
		}

    }
}