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
        public static Campagne[] SimulationCampagne()
        {
            Campagne[] campagnes = new Campagne[]
            {
            new Campagne
                {
                    Id = 1,
                    Name = "La campagne",
                    Desc = "La campagne principale",
                    Armes = new List<Arme>(),
                    Armures = new List<Armure>(),
                    Enchantements = new List<Enchantement>(),
                    Monstres = new List<Monstre>(),
                    PNJs = new List<PNJ>(),
                    Quetes = new List<Quete>(),
                    Classes = new List<Classes>(),
                    Races = new List<Race>()
                },
            new Campagne
                {
                    Id = 2,
                    Name = "L'autre campagne",
                    Desc = "La campagne secondaire",
                    Armes = new List<Arme>(),
                    Armures = new List<Armure>(),
                    Enchantements = new List<Enchantement>(),
                    Monstres = new List<Monstre>(),
                    PNJs = new List<PNJ>(),
                    Quetes = new List<Quete>(),
                    Classes = new List<Classes>(),
                    Races = new List<Race>()
                },
            };
            return campagnes;
        }
    }
}
