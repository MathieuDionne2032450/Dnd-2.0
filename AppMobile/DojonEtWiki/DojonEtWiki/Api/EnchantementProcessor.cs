
using DojonEtWiki.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;


namespace DojonEtWiki.Api
{
    public static class EnchantementProcessor
    {
        public static async Task<List<Enchantement>> GetEnchantement()
        {
            string url = "Enchantement/AllEnchantement";
            HttpResponseMessage reponse = await ApiHelper.apiClient.GetAsync(new Uri(ApiHelper.apiClient.BaseAddress + url)).ConfigureAwait(false);

            if (reponse.IsSuccessStatusCode)
            {
                List<Enchantement> model = await reponse.Content.ReadAsAsync<List<Enchantement>>();
                return model;
            }
            else
            {
                throw new Exception(reponse.ReasonPhrase);
            }
           
        }
    }
}
