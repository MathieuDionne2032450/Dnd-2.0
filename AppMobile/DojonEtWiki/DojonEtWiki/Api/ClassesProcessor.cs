using DojonEtWiki.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojonEtWiki.Api
{
    public static class ClassesProcessor
    {
        public static Classes[] SimulationClasses()
        {
            Classes[] classes = new Classes[]
            {
                new Classes {name = "Guerrier", description = "combattant", hitDie="test1", primaryAbility ="Courrir" },
                new Classes {name = "Archer", description = "tres precis", hitDie="test2", primaryAbility ="tirer des fleche" },
                new Classes {name = "magicien", description = "ressemble a gandalf", hitDie="test3", primaryAbility ="magie"  }
            };

            return classes;
        }
    }
}
