using DojonEtWiki.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojonEtWiki.Api
{
    public static class ArmureProcessor
    {
        public static async Task<List<Armure>> GetAllArmure()
        {
            string url = "GetAllArmure";
            HttpResponseMessage reponse = await ApiHelper.apiClient.GetAsync(new Uri(ApiHelper.apiClient.BaseAddress + url)).ConfigureAwait(false);

            if (reponse.IsSuccessStatusCode)
            {
                List<Armure> model = await reponse.Content.ReadAsAsync<List<Armure>>();
                return model;
            }
            else
            {
                throw new Exception(reponse.ReasonPhrase);
            }
            
        }

        public static async Task<Armure> GetArmure(int id)
        {
            string url = "GetArmureById/"+id;
            HttpResponseMessage reponse = await ApiHelper.apiClient.GetAsync(new Uri(ApiHelper.apiClient.BaseAddress + url)).ConfigureAwait(false);

            if (reponse.IsSuccessStatusCode)
            {
                Armure model = await reponse.Content.ReadAsAsync<Armure>();
                return model;
            }
            else
            {
                throw new Exception(reponse.ReasonPhrase);
            }

        }
        
    }
}
