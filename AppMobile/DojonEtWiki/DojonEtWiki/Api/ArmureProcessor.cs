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
        public static Armure[] SimulationArmure()
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

            Armure[] armures = new Armure[]
            {
                new Armure { Name = "Plastron", Type = "Fer", Ac = 1, DexBonus = true, MaxDexMod = 1, StealthDisadvantage = 1, Enchantement = enchantement, Campagne = new List<Campagne> { campagne } },
                new Armure { Name = "Bottes", Type = "Cuir", Ac = 2, DexBonus = false, MaxDexMod = 1, StealthDisadvantage = 1, Enchantement = enchantement, Campagne = new List<Campagne> { campagne } },
                new Armure { Name = "Casque", Type = "Diamant", Ac = 3, DexBonus = true, MaxDexMod = 1, StealthDisadvantage = 1, Enchantement = enchantement, Campagne = new List<Campagne> { campagne } }
            };

            return armures;
        }
    }
}
