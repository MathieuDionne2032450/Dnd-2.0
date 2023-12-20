using DojonEtWiki.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojonEtWiki.Api
{
    public static class CampagneProcessor
    {
        public async static Task<List<Campagne>> GetAllCampagnes()
        {
            string url = "Campagne";
            HttpResponseMessage reponse = await ApiHelper.apiClient.GetAsync(new Uri(ApiHelper.apiClient.BaseAddress + url)).ConfigureAwait(false);
            if (reponse.IsSuccessStatusCode)
            {
                List<Campagne> model = await reponse.Content.ReadAsAsync<List<Campagne>>();
                return model;
            }
            else
            {
                throw new Exception(reponse.ReasonPhrase);
            }
        }

        public async static Task<Campagne> GetCampagne(int id)
        {
            string url = "GetCampagneById/" + id;
            HttpResponseMessage reponse = await ApiHelper.apiClient.GetAsync(new Uri(ApiHelper.apiClient.BaseAddress + url)).ConfigureAwait(false);
            if (reponse.IsSuccessStatusCode)
            {
                Campagne model = await reponse.Content.ReadAsAsync<Campagne>();
                return model;
            }
            else
            {
                throw new Exception(reponse.ReasonPhrase);
            }
        }
    }
}   