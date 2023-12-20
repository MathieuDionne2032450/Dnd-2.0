using DojonEtWiki.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojonEtWiki.Api
{
    public static class PNJProcessor
    {
        public static async Task<List<PNJ>> GetPnjs()
        {
            string url = "GetAllPNJ";
            HttpResponseMessage reponse = await ApiHelper.apiClient.GetAsync(new Uri(ApiHelper.apiClient.BaseAddress + url)).ConfigureAwait(false);

            if (reponse.IsSuccessStatusCode)
            {
                List<PNJ> model = await reponse.Content.ReadAsAsync<List<PNJ>>();
                return model;
            }
            else
            {
                throw new Exception(reponse.ReasonPhrase);
            }

        }
        public static async Task<PNJ> GetPnj( int id)
        {
            string url = "GetPNJById/"+id;
            HttpResponseMessage reponse = await ApiHelper.apiClient.GetAsync(new Uri(ApiHelper.apiClient.BaseAddress + url)).ConfigureAwait(false);

            if (reponse.IsSuccessStatusCode)
            {
                PNJ model = await reponse.Content.ReadAsAsync<PNJ>();
                return model;
            }
            else
            {
                throw new Exception(reponse.ReasonPhrase);
            }

        }
    }
}
