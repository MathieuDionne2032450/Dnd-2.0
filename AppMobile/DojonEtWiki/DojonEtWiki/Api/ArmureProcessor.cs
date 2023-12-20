using Android.Renderscripts;
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

        public static async Task<List<Armure>> PutArmure(int id,string name,string type,int ac,bool dexBonus,int maxDexBonus,int stealth, int enchantId)
        {
            
            string requete = "EditArmure?id="+id+ "&name="+name+ "&type="+type+ "&ac="+ac+ "&dexBonus="+dexBonus+ "&maxDexBonus="+maxDexBonus+ "&stealthDisadvantage="+stealth+"&enchantementId="+ enchantId;
            HttpResponseMessage reponse = await ApiHelper.apiClient.PutAsync(new Uri(ApiHelper.apiClient.BaseAddress +requete),new StringContent(string.Empty)).ConfigureAwait(false);

            if (reponse.IsSuccessStatusCode)
            {
                List<Armure> model = await reponse.Content.ReadAsAsync<List<Armure>>();
                return model;
            }
            else
            {
                throw new Exception(reponse.ReasonPhrase);
            }
            return null;
        }

        public static async Task<Armure> PostArmure(string name, string type, int ac, bool dexBonus, int maxDexBonus, int stealth, int enchantId)
        {

            string requete = "CreateArmures?name=" + name + "&type=" + type + "&ac=" + ac + "&dexBonus=" + dexBonus + "&maxDexBonus=" + maxDexBonus + "&stealthDisadvantage=" + stealth + "&enchantementId=" + enchantId;
            HttpResponseMessage reponse = await ApiHelper.apiClient.PostAsync(new Uri(ApiHelper.apiClient.BaseAddress + requete), new StringContent(string.Empty)).ConfigureAwait(false);

            if (reponse.IsSuccessStatusCode)
            {
                Armure model = await reponse.Content.ReadAsAsync<Armure>();
                return model;
            }
            else
            {
                throw new Exception(reponse.ReasonPhrase);
            }
            return null;
        }

        public static async Task<bool> DeleteArmure(int id)
        {

            string requete = "DeleteArmure/" + id;
            HttpResponseMessage reponse = await ApiHelper.apiClient.DeleteAsync(new Uri(ApiHelper.apiClient.BaseAddress + requete)).ConfigureAwait(false);

            if (reponse.IsSuccessStatusCode)
            {
                bool model = await reponse.Content.ReadAsAsync<bool>();
                return model;
            }
            else
            {
                throw new Exception(reponse.ReasonPhrase);
            }
            return false;
            }

        }
        
    }
}
