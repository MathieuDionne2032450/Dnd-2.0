using DojonEtWiki.ViewModel;
using DojonEtWiki.Model;
namespace DojonEtWiki.View;

public partial class InfoCampagne : ContentPage
{
    VMCampagne vm;
	public InfoCampagne()
	{
		InitializeComponent();
        vm = new VMCampagne();
    }

    private async void Campagne_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InfoPerso());
    }

    private async void Armure_Clicked(object sender, EventArgs e)
    {
        VMArmure vmArmure = new VMArmure();
        Button b = sender as Button;
        vmArmure.Armure = vm.Campagne.Armures.ToList().Find(a => a.Name == b.Text);
        vmArmure.VerifEdit = true;
        vmArmure.VerifCreate = false;
        await Navigation.PushAsync(new View.Armure.CreateArmure());
    }

    

    private async void Armure_Ajout_Clicked(object sender, EventArgs e)
    {
        VMArmure vmArmure = new VMArmure();
        vmArmure.Armure = new Model.Armure();
        vmArmure.VerifEdit = false;
        vmArmure.VerifCreate = true;

        await Navigation.PushAsync(new View.Armure.CreateArmure());
    }
    private async void Arme_Clicked(object sender, EventArgs e)
    {
        //VMArmure vmArme = new VMArme();
        Button b = sender as Button;
        //vmArme.Armure = vm.Campagne.Armures.ToList().Find(a => a.Name == b.Text);
        //vmArme.VerifEdit = true;
        //vmArme.VerifCreate = false;

        await Navigation.PushAsync(new InfoPerso());
    }
}