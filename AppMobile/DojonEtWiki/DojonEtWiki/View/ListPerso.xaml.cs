using DojonEtWiki.Model;
using DojonEtWiki.ViewModel;

namespace DojonEtWiki.View;

public partial class ListPerso : ContentPage
{
	VMFichePerso vm;
	public ListPerso()
	{
		vm = new VMFichePerso();
		InitializeComponent();

	}

	private async void voir(object sender, EventArgs e)
	{
		vm.SelectedPerso = (Perso)perso.SelectedItem;
		await Navigation.PushAsync(new FichePerso(vm));

    }
}