namespace DojonEtWiki.View;
using Api;
using DojonEtWiki.Model;
using DojonEtWiki.ViewModel;
using System.Web.Http;

public partial class MainPage : ContentPage
{
    MainPageVM vm;
    public MainPage()
    {
        InitializeComponent();
        ApiHelper.InitializeClient();
        vm = new MainPageVM();
    }

    private async void Connection_Clicked(object sender, EventArgs e)
    {
        if(vm.CheckKey(password.Text))
        {
            Application.Current.MainPage = new AppShell();
            await Navigation.PushAsync(new WikiList());
        }
        else
        {
            error.IsVisible = true;
        }
        
    }

    private async void Inscription_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new inscription());
    }
}