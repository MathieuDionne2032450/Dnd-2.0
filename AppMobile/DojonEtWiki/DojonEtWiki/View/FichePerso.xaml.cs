using DojonEtWiki.ViewModel;

namespace DojonEtWiki.View;

public partial class FichePerso : ContentPage
{
	VMFichePerso vm;
	public FichePerso(VMFichePerso vm_p)
	{
		vm = vm_p;
		InitializeComponent();
	}
}