using DojonEtWiki.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojonEtWiki.Api
{
    public static class RaceProcessor
    {
        public static async Task<List<Race>> GetRaces()
        {
            string url = "Race/GetAllRace";
            HttpResponseMessage reponse = await ApiHelper.apiClient.GetAsync(new Uri(ApiHelper.apiClient.BaseAddress + url)).ConfigureAwait(false);

            if (reponse.IsSuccessStatusCode)
            {
                List<Race> model = await reponse.Content.ReadAsAsync<List<Race>>();
                return model;
            }
            else
            {
                throw new Exception(reponse.ReasonPhrase);
            }
            return null;
        }
    }
}
