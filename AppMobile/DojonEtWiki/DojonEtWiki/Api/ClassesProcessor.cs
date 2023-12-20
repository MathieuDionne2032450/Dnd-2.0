using DojonEtWiki.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojonEtWiki.Api
{
    public static class ClassesProcessor
    {
        public static async Task<List<Classes>> GetClasses()
        {
            string url = "Classes";
            HttpResponseMessage reponse = await ApiHelper.apiClient.GetAsync(new Uri(ApiHelper.apiClient.BaseAddress + url)).ConfigureAwait(false);

            if (reponse.IsSuccessStatusCode)
            {
                List<Classes> model = await reponse.Content.ReadAsAsync<List<Classes>>();
                return model;
            }
            else
            {
                throw new Exception(reponse.ReasonPhrase);
            }
            
        }
        public static async Task<Classes> GetClass(int id)
        {
            string url = "GetClasses/"+id;
            HttpResponseMessage reponse = await ApiHelper.apiClient.GetAsync(new Uri(ApiHelper.apiClient.BaseAddress + url)).ConfigureAwait(false);

            if (reponse.IsSuccessStatusCode)
            {
                Classes model = await reponse.Content.ReadAsAsync<Classes>();
                return model;
            }
            else
            {
                throw new Exception(reponse.ReasonPhrase);
            }
            
        }

        
    }
}
