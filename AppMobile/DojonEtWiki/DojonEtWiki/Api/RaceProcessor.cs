using DojonEtWiki.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojonEtWiki.Api
{
    public static class RaceProcessor
    {
        public static Race[] SimulationRaces()
        {
            Race[] races = new Race[]
            {
                new Race { Nom = "humain",BonusCharisma = 1, BonusConsti = 2, BonusDex = 3, BonusForce = 4, BonusIntel = 5, BonusPV = 6, BonusWisdom = 7, Campagnes=null},
                new Race { Nom = "Elf", BonusCharisma = 2, BonusConsti = 3, BonusDex = 4, BonusForce = 5, BonusIntel = 6, BonusPV = 7, BonusWisdom = 8, Campagnes=null},
                new Race { Nom = "ogre", BonusCharisma = 3, BonusConsti = 4, BonusDex = 5, BonusForce = 6, BonusIntel = 7, BonusPV = 8, BonusWisdom = 9, Campagnes=null}
            };

            return races;
        }
    }
}
