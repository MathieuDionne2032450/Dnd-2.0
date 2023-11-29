using DojonEtWiki.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = DojonEtWiki.Model.Action;

namespace DojonEtWiki.Api
{
    public static class MonstreProcessor
    {
        public static Monstre[] SimulationMonstres()
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

            // Il faut une liste de monstres pour pouvoir créer une Action, donc voici un qui servira juste à remplir la liste
            Monstre monstrePourAction = new Monstre("Remplisseur de liste", "Très grand", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1f, "fr", "feu", "feu", "feu");

            Action action = new Action
            {
                Monstres = new List<Monstre> { monstrePourAction },
                Type = "Je sais pas c'est quoi une Action",
                Name = "Action",
                Descr = "Action",
                Dammage = "Beaucoup",
                DammageType = "Psychologique",
                Dc = 1,
                DcType = "Detective Comics",
                Campagne = campagne
            };

            Monstre[] monstres = new Monstre[]
            {
                new Monstre
                {
                    Nom = "Bolimbo",
                    Size = "Très grand",
                    ArmorClass = 1,
                    HitPoint = 1,
                    Speed = 1,
                    FlySpeed = 1,
                    ClimbSpeed = 1,
                    Str = 1,
                    Dex = 1,
                    Con = 1,
                    Intel = 1,
                    Wis = 1,
                    Cha = 1,
                    DarkVision = 1,
                    Challenge = 1.33f,
                    Lang = "fr",
                    DammageResistance = "Feu",
                    DammageImmunities = "Nécromancie",
                    ConditionImmunities = "Fromage Boivin",
                    Actions = new List<Action> { action },
                    Campagne = new List<Campagne>{campagne}
                },
                new Monstre
                {
                    Nom = "Bobobo",
                    Size = "Très petit",
                    ArmorClass = 1,
                    HitPoint = 1,
                    Speed = 1,
                    FlySpeed = 1,
                    ClimbSpeed = 1,
                    Str = 1,
                    Dex = 1,
                    Con = 1,
                    Intel = 1,
                    Wis = 1,
                    Cha = 1,
                    DarkVision = 1,
                    Challenge = 3.33f,
                    Lang = "fr",
                    DammageResistance = "Feu",
                    DammageImmunities = "Nécromancie",
                    ConditionImmunities = "Fromage Boivin",
                    Actions = new List<Action> { action },
                    Campagne = new List<Campagne>{campagne}
                },
                new Monstre
                {
                    Nom = "Bofadfbnl",
                    Size = "Très moyen",
                    ArmorClass = 1,
                    HitPoint = 1,
                    Speed = 1,
                    FlySpeed = 1,
                    ClimbSpeed = 1,
                    Str = 1,
                    Dex = 1,
                    Con = 1,
                    Intel = 1,
                    Wis = 1,
                    Cha = 1,
                    DarkVision = 1,
                    Challenge = 2.33f,
                    Lang = "fr",
                    DammageResistance = "Feu",
                    DammageImmunities = "Nécromancie",
                    ConditionImmunities = "Fromage Boivin",
                    Actions = new List<Action> { action },
                    Campagne = new List<Campagne>{campagne}
                },
            };

            return monstres;
        }
    }
}
