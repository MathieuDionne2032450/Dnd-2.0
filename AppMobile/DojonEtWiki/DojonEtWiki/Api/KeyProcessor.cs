using DojonEtWiki.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojonEtWiki.Api
{
    public static class KeyProcessor
    {
        public static async Task<string> GetKey()
        {
            string url = "GenererUniqueKey";
            HttpResponseMessage reponse = await ApiHelper.apiClient.GetAsync(new Uri(ApiHelper.apiClient.BaseAddress + url)).ConfigureAwait(false);

            if (reponse.IsSuccessStatusCode)
            {
                string key = await reponse.Content.ReadAsAsync<string>();
                return key;
            }
            else
            {
                throw new Exception(reponse.ReasonPhrase);
            }
            return null;
        }

        public static async Task<bool> CheckKey(string key)
        {
            string url = "VerifKey/"+key;
            HttpResponseMessage reponse = await ApiHelper.apiClient.GetAsync(new Uri(ApiHelper.apiClient.BaseAddress + url)).ConfigureAwait(false);

            if (reponse.IsSuccessStatusCode)
            {
                string role = await reponse.Content.ReadAsAsync<string>();
                if (role=="USER_ROLE")
                {
                    return true;
                }
            }
            else
            {
                throw new Exception(reponse.ReasonPhrase);
            }
            return false;
        }
    }
}

