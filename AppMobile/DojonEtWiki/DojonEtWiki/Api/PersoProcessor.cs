using DojonEtWiki.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojonEtWiki.Api
{
    public static class PersoProcessor
    {
        

        public static async Task<List<Perso>> Getpersos()
        {
            string url = "AllPerso";
            HttpResponseMessage reponse = await ApiHelper.apiClient.GetAsync(new Uri(ApiHelper.apiClient.BaseAddress + url)).ConfigureAwait(false);

            if (reponse.IsSuccessStatusCode)
            {
                List<Perso> model = await reponse.Content.ReadAsAsync<List<Perso>>();
                return model;
            }
            else
            {
                throw new Exception(reponse.ReasonPhrase);
            }

        }

       

        public static async Task<bool> CreerPerso(string irljoueur,string nom,string desc, int inspi,int armurid,int classid,int raceid,string persotrait,string ideal,string bounds,string flaws, int lvl,int campid)
        {
            string url = "CreatePerso?IrlJoueur="+irljoueur+"&Nom="+nom+"&Description="+desc+"&Inspiration="+inspi+"&ArmureId="+armurid+"&ClasseId="+classid+"&RaceId="+raceid+"&Personalitetrait="+persotrait+"&Ideal="+ideal+"&Bonds="+bounds+"&Flaws="+flaws+"&Niv="+lvl+"&CampagneId="+campid;
 
            
            
            
            HttpResponseMessage reponse = await ApiHelper.apiClient.PostAsync(new Uri(ApiHelper.apiClient.BaseAddress + url),new StringContent(string.Empty)).ConfigureAwait(false);

            if (reponse.IsSuccessStatusCode)
            {
                
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
