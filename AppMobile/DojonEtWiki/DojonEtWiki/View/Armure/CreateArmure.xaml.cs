using DojonEtWiki.Model;
using DojonEtWiki.ViewModel;
using System.Security;

namespace DojonEtWiki.View.Armure;

public partial class CreateArmure : ContentPage
{
	VMArmure vm;
	public CreateArmure()
	{
		vm = new VMArmure();
		InitializeComponent();
		
	}

	private void OnEditArmureClicked(object sender, EventArgs e)
	{
		vm.EditArmure();
		VMCampagne vMCampagne= new VMCampagne();
        vMCampagne.ListeCampagne = Api.CampagneProcessor.GetAllCampagnes().Result;
        Navigation.RemovePage(this);
    }

    private void OnCreateArmureClicked(object sender, EventArgs e)
    {
		vm.CreateArmure();
        VMCampagne vMCampagne = new VMCampagne();
        vMCampagne.ListeCampagne = Api.CampagneProcessor.GetAllCampagnes().Result;
        
        Navigation.RemovePage(this);
    }

    private void OnDeleteArmureClicked(object sender, EventArgs e)
    {
        vm.DeleteArmure();
        VMCampagne vMCampagne = new VMCampagne();
        vMCampagne.ListeCampagne = Api.CampagneProcessor.GetAllCampagnes().Result;

        Navigation.RemovePage(this);
    }
}