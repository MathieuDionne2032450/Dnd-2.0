using DojonEtWiki.Api;
using DojonEtWiki.Model;
using DojonEtWiki.ViewModel;


namespace DojonEtWiki.View;

public partial class Creerperso : ContentPage
{
	VMCreerPerso vm;
	public Creerperso()
	{
		vm = new VMCreerPerso();
		BindingContext = vm;
		InitializeComponent();
	}
    private void creer(object sender, EventArgs e)
	{
		vm.Creerperso(NameJoueur.Text, NamePerso.Text, desc.Text, Convert.ToInt32(inspi.Text),  trait.Text,  ideal.Text,  Bond.Text,  Flaws.Text, Convert.ToInt32(lvl.Text)); 
	}
}