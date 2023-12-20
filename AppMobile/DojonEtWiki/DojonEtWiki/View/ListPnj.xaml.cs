using DojonEtWiki.Model;
using DojonEtWiki.ViewModel;

namespace DojonEtWiki.View;

public partial class ListPnj : ContentPage
{
    VMPnj vm;
	public ListPnj()
	{
        vm = new VMPnj();
		InitializeComponent();
	}

    private async void voir(object sender, EventArgs e)
    {
        vm.SelectedPnj = (PNJ)pnj.SelectedItem;
        vm.SetPNJImage();
        await Navigation.PushAsync(new VoirPnj(vm));
    }
}