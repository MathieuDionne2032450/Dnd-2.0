namespace DojonEtWiki.View;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }

    private async void Connection_Clicked(object sender, EventArgs e)
    {
        if(password.Text=="admin" && username.Text == "admin")
        {
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