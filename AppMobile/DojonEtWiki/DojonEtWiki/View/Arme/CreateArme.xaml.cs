using DojonEtWiki.Api;
using DojonEtWiki.Model;
using DojonEtWiki.ViewModel;

namespace DojonEtWiki.View.Arme;

public partial class CreateArme : ContentPage
{
    VMArme vm;
	public CreateArme()
	{
        vm = new VMArme();
		InitializeComponent();
	}

	
        private void OnEditArmeClicked(object sender, EventArgs e)
        {
            vm.EditArme();
            VMCampagne vMCampagne = new VMCampagne();
            vMCampagne.ListeCampagne = Api.CampagneProcessor.GetAllCampagnes().Result;
            Navigation.RemovePage(this);
        }

        private void OnCreateArmeClicked(object sender, EventArgs e)
        {
            vm.CreateArme();
            VMCampagne vMCampagne = new VMCampagne();
            vMCampagne.ListeCampagne = Api.CampagneProcessor.GetAllCampagnes().Result;

            Navigation.RemovePage(this);
        }

        private void OnDeleteArmeClicked(object sender, EventArgs e)
        {
            vm.DeleteArme();
            VMCampagne vMCampagne = new VMCampagne();
            vMCampagne.ListeCampagne = Api.CampagneProcessor.GetAllCampagnes().Result;

            Navigation.RemovePage(this);
        }
}