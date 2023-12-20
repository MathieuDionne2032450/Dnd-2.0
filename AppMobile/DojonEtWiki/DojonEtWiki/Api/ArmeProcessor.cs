using DojonEtWiki.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojonEtWiki.Api
{
    public static class ArmeProcessor
    {
        public static async Task<List<Arme>> GetAllArmure()
        {
            string url = "GetAllArme";
            HttpResponseMessage reponse = await ApiHelper.apiClient.GetAsync(new Uri(ApiHelper.apiClient.BaseAddress + url)).ConfigureAwait(false);

            if (reponse.IsSuccessStatusCode)
            {
                List<Arme> model = await reponse.Content.ReadAsAsync<List<Arme>>();
                return model;
            }
            else
            {
                throw new Exception(reponse.ReasonPhrase);
            }

        }

        public static async Task<Arme> GetArme(int id)
        {
            string url = "GetArmureById/" + id;
            HttpResponseMessage reponse = await ApiHelper.apiClient.GetAsync(new Uri(ApiHelper.apiClient.BaseAddress + url)).ConfigureAwait(false);

            if (reponse.IsSuccessStatusCode)
            {
                Arme model = await reponse.Content.ReadAsAsync<Arme>();
                return model;
            }
            else
            {
                throw new Exception(reponse.ReasonPhrase);
            }
        }

        public static async Task<List<Arme>> PutArme(int id, int bonusJet, int bonusForce, string nom,int enchantId)
        {

            string requete = "EditArme?id=" + id + "&bonusJet=" + bonusJet + "&bonusForce=" + bonusForce + "&nom=" + nom + "&enchantementId=" + enchantId;
            HttpResponseMessage reponse = await ApiHelper.apiClient.PutAsync(new Uri(ApiHelper.apiClient.BaseAddress + requete), new StringContent(string.Empty)).ConfigureAwait(false);

            if (reponse.IsSuccessStatusCode)
            {
                List<Arme> model = await reponse.Content.ReadAsAsync<List<Arme>>();
                return model;
            }
            else
            {
                throw new Exception(reponse.ReasonPhrase);
            }
            return null;
        }

        public static async Task<Arme> PostArme(int bonusJet, int bonusForce, string nom, int enchantId)
        {

            string requete = "CreateArme?bonusJet=" + bonusJet + "&bonusForce=" + bonusForce + "&nom=" + nom + "&enchantementId=" + enchantId;
            HttpResponseMessage reponse = await ApiHelper.apiClient.PostAsync(new Uri(ApiHelper.apiClient.BaseAddress + requete), new StringContent(string.Empty)).ConfigureAwait(false);

            if (reponse.IsSuccessStatusCode)
            {
                Arme model = await reponse.Content.ReadAsAsync<Arme>();
                return model;
            }
            else
            {
                throw new Exception(reponse.ReasonPhrase);
            }
            return null;
        }

        public static async Task<bool> DeleteArme(int id)
        {

            string requete = "DeleteArme/" + id;
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

