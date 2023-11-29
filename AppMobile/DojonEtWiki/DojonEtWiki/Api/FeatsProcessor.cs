using DojonEtWiki.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojonEtWiki.Api
{
    public static class FeatsProcessor
    {
        public static feats[] SimulationFeats()
        {
            feats[] featslist = new feats[]
            {
                new feats { id = 1, Nom = "Artificier", Descr = "Peut tirer du cannon" },
                new feats { id = 2, Nom = "Homme du feu", Descr = "Est resistant au dégat de feu" },
                new feats { id = 3, Nom = "Main leste", Descr = "peut utliser une bonus action pour recharger" },

            };
            return featslist;
        }
    }
}
