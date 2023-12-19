using DojonEtWiki.Model;
using DojonEtWiki.ViewModel;

namespace DojonEtWiki.View;

public partial class Creation : ContentPage
{
    VMCampagne vm;
	public Creation()
	{
		InitializeComponent();
        vm = new VMCampagne();
	}

    private async void creer_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreerCampagne());
    }

    private async void Campagne_Clicked(object sender, EventArgs e)
    {
        Button b= sender as Button;
        string s = b.Text;
        vm.Campagne = vm.ListeCampagne.Find(c => c.Name == s);
        await Navigation.PushAsync(new InfoCampagne());

    }
}