using DojonEtWiki.ViewModel;
using DojonEtWiki.Api;

namespace DojonEtWiki.View;

public partial class InfoEnchantement : ContentPage
{
	VMEnchantement vm;
	public InfoEnchantement(VMEnchantement vm_p)
	{
		vm = vm_p;
		BindingContext = vm;
		InitializeComponent();
	}
}