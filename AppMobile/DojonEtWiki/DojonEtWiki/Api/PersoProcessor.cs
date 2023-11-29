using Android.Content;
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
        public static Perso[] SimulationPersos()
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

            Enchantement enchant = new Enchantement() { Nom = "Salabim", Type = "Enchantement magique", Modif = 1, Description = "waw" };

            Armure armure = new Armure
            {
                Name = "Armure",
                Type = "Forte",
                Ac = 2,
                DexBonus = true,
                MaxDexMod = 2,
                StealthDisadvantage = 2,
                Enchantement = enchant
            };

            Arme arme = new Arme
            {
                BonusJet = 2,
                BonusForce = 2,
                Nom = "Épée",
                Enchantement = enchant,
                Campagne = new List<Campagne> { campagne }
            };

            Race race = new Race() { BonusCharisma = 1, BonusDex = 1, BonusConsti = 1, BonusForce = 1, BonusIntel = 1, BonusPV = 1, BonusWisdom = 1, Nom = "Loup" };
            Classes classe = new Classes() { description = "desc", hitDie = "2d4", name = "Mage", primaryAbility = "boule de feu" };

            Perso perso = new Perso
            {
                IrlJoueur = "Alexandre",
                Nom = "Krados",
                Description = "démon démoniaque",
                Inspiration = 0,
                Armure = armure,
                LesArmes = new List<Arme> { arme },
                Classes = classe,
                Race = race,
                Personalitetrait = "evil",
                Ideal = "Justice",
                Bonds = "Avec Louise",
                Flaws = "Le bruit",
                Niv = 1,
                Campagne = campagne
            };

            Skill skill = new Skill { Descr = "Compétences acérées", Nom = "Skillz", Persos = new List<Perso> { perso } };

            feats feat = new feats { Nom = "Artificier", Descr = "Peut tirer du cannon" };

            Perso[] persos = new Perso[]
            {

                new Perso { IrlJoueur = "Alexandre", Nom = "Dreknethol", Description = "Un beau perso qui est vraiment le plus beau de tous", Inspiration = 0,Armure = armure, LesArmes = new List<Arme>{ arme },
                     Classes = classe, Race = race, Skills = new List<Skill> { skill }, Personalitetrait = "beau",
                    Ideal="beauté",Bonds = "Les gens beau", Flaws = "La laideur", Niv = 15, Campagne=campagne, feats = new List<feats>{ feat } },

                new Perso { IrlJoueur = "Mathieu", Nom = "Bwipo", Description = "un laid", Inspiration = 1,Armure = armure, LesArmes = new List<Arme>{ arme },
                     Classes = classe, Race = race, Skills = new List<Skill>{ skill }, Personalitetrait = "laid",
                    Ideal="laideur",Bonds = "Les gens laid", Flaws = "La beauté", Niv = 5,Campagne=campagne, feats = new List<feats> { feat } },

                new Perso { IrlJoueur = "Louis", Nom = "Louise", Description = "jeune damme cool", Inspiration = 2,Armure = armure, LesArmes = new List<Arme>{ arme },
                    Classes = classe,Race = race, Skills = new List<Skill>{ skill }, Personalitetrait = "beau",
                    Ideal="cool",Bonds = "Les gens cool", Flaws = "Les gens pas cool", Niv = 1,Campagne=campagne, feats = new List<feats> { feat } },
            };

            return persos;
        }
    }
}
