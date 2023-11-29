using DojonEtWiki.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojonEtWiki.Api
{
    public static class SpellProcessor
    {
        public static Spell[] SimulationSpells()
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

            Armure armure = new Armure
            {
                Name = "Armure",
                Type = "Forte",
                Ac = 2,
                DexBonus = true,
                MaxDexMod = 2,
                StealthDisadvantage = 2,
                EnchantementId = 1
            };

            Arme arme = new Arme
            {
                BonusJet = 2,
                BonusForce = 2,
                Nom = "Épée",
                EnchantementId = 1,
                Campagne = new List<Campagne> { campagne }
            };

            Classes classes = new Classes
            {
                name = "Classe",
                description = "Description de la classe",
                hitDie = "8d6",
                primaryAbility = "Habileté primaire",
                id = 1,
                Campagne = new List<Campagne> { campagne }
            };

            Race race = new Race
            {
                Nom = "Orque",
                BonusPV = 1,
                BonusDex = 1,
                BonusForce = 1,
                BonusIntel = 1,
                BonusWisdom = 1,
                BonusConsti = 1,
                BonusCharisma = 1,
                Id = 1,
                Campagnes = new List<Campagne> { campagne }
            };

            Perso perso = new Perso
            {
                IrlJoueur = "Alexandre",
                Nom = "Krados",
                Description = "démon démoniaque",
                Inspiration = 0,
                ArmureId = 1,
                LesArmes = new List<Arme> { arme },
                ClasseId = 1,
                RaceId = 1,
                Personalitetrait = "evil",
                Ideal = "Justice",
                Bonds = "Avec Louise",
                Flaws = "Le bruit",
                Niv = 1,
                CampagneId = 1
            };

            List<Perso> persos = new List<Perso> { perso };

            Spell[] Spelllist = new Spell[]
            {
                new Spell() { id = 1, Name = "Lazer de feu", Description = "tire un lazer de feu sur 1 énemi",DammageType="Feu",Dammage=20,ClassId=1,Zone="Cible" },
                new Spell() { id = 2, Name = "Foudre des dieux", Description = "Fait tomber la foudre sur un cible avec un rayon de 20ft",DammageType="Foudre",Dammage=75,ClassId=1,Zone="20ft" },

            };

            return Spelllist;
        }
    }
}
