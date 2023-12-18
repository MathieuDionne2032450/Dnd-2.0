
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

            string test = ApiHelper.apiClient.BaseAddress + url;

            //HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(test);
            //httpWebRequest.Method = "GET";

            //HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
            
            //    if (httpWebResponse.StatusCode == HttpStatusCode.OK)
            //    {
            //        using (Stream dataStream = httpWebResponse.GetResponseStream())
            //        {
            //            using (StreamReader reader = new StreamReader(dataStream))
            //            {
            //                var also = reader.ReadToEnd();
            //            }
            //        }
            //    }


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

            return null;
            
        }

        public static Enchantement[] SimulationEnchantements()
        {
            Enchantement enchantement = new Enchantement { Description = "met les ennemies en feu", Nom = "Feu", Id = 1, Modif = 2,Type="feu" };
            Enchantement enchantement1 = new Enchantement { Description = "tire de l'eau", Nom = "eau", Id = 2, Modif = 3, Type = "eau" };
            Enchantement enchantement2= new Enchantement { Description = "place des bloc de terre", Nom = "terre", Id = 3, Modif = 4, Type = "terre" };
            Enchantement enchantement3 = new Enchantement { Description = "tire de la glace", Nom = "glace", Id = 4, Modif = 5, Type = "glace" };

            return new Enchantement[] { enchantement, enchantement1, enchantement2, enchantement3}; 


        }
    }
}
