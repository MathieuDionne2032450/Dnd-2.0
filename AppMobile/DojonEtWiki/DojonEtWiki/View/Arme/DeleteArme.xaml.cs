using DojonEtWiki.Model;

namespace DojonEtWiki.View.Arme;

public partial class DeleteArme : ContentPage
{
	public DeleteArme()
	{
		InitializeComponent();
	}

	private async void SupprimerClicked(object sender, EventArgs e)
	{
        using (HttpClient client = new HttpClient())
        {
            try
            {
                string url = "https://c0fnrbvj-7296.use.devtunnels.ms/DeleteArme/";
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}