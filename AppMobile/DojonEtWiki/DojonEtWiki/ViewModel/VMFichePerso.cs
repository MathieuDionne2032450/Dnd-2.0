using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DojonEtWiki.Model;
using DojonEtWiki.Api;

namespace DojonEtWiki.ViewModel
{
    public class VMFichePerso
    {
        List<Perso> persos;
        static Perso selectedperso;
        Race race;
        Classes calsse;
        Campagne campagne;
        Armure armure;

        public List<Perso> Persos { get { return persos; } set { persos = value; } }
        public Perso SelectedPerso { get { return selectedperso; } set { selectedperso = value; Armure = ArmureProcessor.GetArmure(value.ArmureId).Result; Race = RaceProcessor.GetRace(value.RaceId).Result; Classes = ClassesProcessor.GetClass(value.ClasseId).Result; Campagne = CampagneProcessor.GetCampagne(value.CampagneId).Result; } }
        public Race Race { get { return race; } set { race = value; } }
        public Classes Classes { get { return calsse; } set { calsse = value; } }
        public Campagne Campagne { get { return campagne; } set { campagne = value; } }
        public Armure Armure { get { return armure; } set { armure = value; } }

        public VMFichePerso()
        {
            Persos =  PersoProcessor.Getpersos().Result;
            
        }
    }
}
