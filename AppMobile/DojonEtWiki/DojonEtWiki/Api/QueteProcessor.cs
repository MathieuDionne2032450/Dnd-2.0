using DojonEtWiki.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojonEtWiki.Api
{
    public static class QueteProcessor
    {
        public static Quete[] SimulationQuetes()
        {
            Campagne campagne = new Campagne
            {
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


            PNJ[] pnjs = new PNJ[]
            {
                new PNJ {Id = 1, Bouche = 1, Nez = 1, Barbe = 1, Cheveux = 1, Sourcil = 1, Tete = 1, Yeux1 = 1, Yeux2 = 1, Description = "Le medecin de l'ile des pauvres", Name = "Gaspare Boneclaw", Campagne = campagne},
                new PNJ {Id = 3, Bouche = 3, Nez = 3, Barbe = 3, Cheveux = 3, Sourcil = 3, Tete = 3, Yeux1 = 3, Yeux2 = 3, Description = "Le pauvre de l'ile des pauvres", Name = "Gilles Boneclaw", Campagne = campagne},
                new PNJ {Id = 2, Bouche = 2, Nez = 2, Barbe = 2, Cheveux = 2, Sourcil = 2, Tete = 2, Yeux1 = 2, Yeux2 = 2, Description = "L'homme qui nous a donner des carottes", Name = "Roger Steven", Campagne = campagne},
            };

            List<Campagne> listeCampagnes = new List<Campagne> { campagne };

            Quete[] quetes = new Quete[]
            {
                new Quete { Id= 1, Pnj = pnjs[0], DescriptionQuete = "Apporter le sous-marin au port", reward = "Un sous-marin", Campagne = listeCampagnes },
                new Quete { Id= 2, Pnj = pnjs[0], DescriptionQuete = "Détruire la base secrète", reward = "Une épée", Campagne = listeCampagnes },
                new Quete { Id= 3, Pnj = pnjs[0], DescriptionQuete = "Manigancer", reward = "Des manigances", Campagne = listeCampagnes },
            };

            return quetes;
        }
    }
}
