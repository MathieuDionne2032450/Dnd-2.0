using DojonEtWiki.ViewModel;

namespace DojonEtWiki.View;

public partial class VoirPnj : ContentPage
{
	VMPnj vm;
	public VoirPnj(VMPnj vm_p)
	{
		vm = vm_p;
		InitializeComponent();
	}
}