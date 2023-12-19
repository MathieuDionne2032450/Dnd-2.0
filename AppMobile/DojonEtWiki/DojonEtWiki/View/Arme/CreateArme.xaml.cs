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

        Model.Arme arme = new Model.Arme
        {
            BonusJet = bonusJet,
            BonusForce = bonusForce,
            Nom = nom,
            EnchantementId = enchantementId
        };

		string url = "Arme/CreateArme";

    }
}