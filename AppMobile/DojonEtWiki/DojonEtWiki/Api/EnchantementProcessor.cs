using AndroidX.ConstraintLayout.Core.Widgets;
using DojonEtWiki.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using GoogleGson;

namespace DojonEtWiki.Api
{
    public class EnchantementProcessor
    {
        public static async Task<List<Enchantement>> GetEnchantement()
        {
            string url = "GetAllArme";

            string test = ApiHelper.apiClient.BaseAddress + url;

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(test);
            httpWebRequest.Method = "GET";

            HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
            
                if (httpWebResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (Stream dataStream = httpWebResponse.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(dataStream))
                        {
                            var also = reader.ReadToEnd();
                        }
                    }
                }
            

            // HttpResponseMessage reponse = await ApiHelper.apiClient.GetAsync(new Uri(ApiHelper.apiClient.BaseAddress + url)).ConfigureAwait(false);

            //if (reponse.IsSuccessStatusCode)
            //{
            //    List<Enchantement> model = await reponse.Content.ReadAsAsync<List<Enchantement>> ();

            //    return model;
            //}
            //else
            //{
            //    throw new Exception(reponse.ReasonPhrase);
            //}

            return null;
            
        }
    }
}
