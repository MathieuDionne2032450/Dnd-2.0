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
        public static Arme[] SimulationArmes()
        {
            Campagne campagne = new Campagne
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
            };

            Enchantement enchantement = new Enchantement
            {
                Nom = "Enchantement",
                Description = "Enchantement cool",
                Type = "Enchanté",
                Modif = 1,
                Id = 1
            };

            Arme[] armes = new Arme[]
            {
                new Arme { BonusJet = 1, BonusForce = 1, Nom = "Massue", Enchantement = enchantement, Campagne = new List<Campagne> { campagne } },
                new Arme { BonusJet = 1, BonusForce = 1, Nom = "Epee", Enchantement = enchantement, Campagne = new List<Campagne> { campagne } },
                new Arme { BonusJet = 1, BonusForce = 1, Nom = "Poignard", Enchantement = enchantement, Campagne = new List<Campagne> { campagne } }
            };

            return armes;
        }
    }
}
