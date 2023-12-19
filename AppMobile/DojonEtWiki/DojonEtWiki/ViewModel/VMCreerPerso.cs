using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DojonEtWiki.Model;
using DojonEtWiki.Api;
using DojonEtWiki.View;

namespace DojonEtWiki.ViewModel
{
    public class VMCreerPerso
    {
        List<Race> races;
        Race selectedRace;

        List<Classes> classes;
        Classes selectedclasse;

        List<Armure> armures;
        Armure selectedarmure;

        List<Campagne> campagnes;
        Campagne selectedcampagne;

        public List<Race> Races { get { return races; }set { races = value; } }
        public Race SelectedRace { get { return selectedRace; } set { selectedRace = value; } }

        public List<Classes> Classes { get { return classes; } set { classes = value; } }
        public Classes SelectedClasse { get { return selectedclasse; } set { selectedclasse = value; } }

        public List<Armure> Armures { get { return armures; } set { armures = value; } }
        public Armure SelectedArmure { get { return selectedarmure; } set { selectedarmure = value; } }

        public List<Campagne> Campagnes { get { return campagnes; } set { campagnes = value; } }
        public Campagne SelectedCampagne { get { return selectedcampagne; } set { selectedcampagne = value; } }


        public VMCreerPerso()
        {
            Races = RaceProcessor.GetRaces().Result;
            SelectedRace = Races[0];

            Classes = ClassesProcessor.GetClasses().Result;
            SelectedClasse = Classes[0];

            Armures = ArmureProcessor.GetAllArmure().Result;
            SelectedArmure = Armures[0];

            Campagnes = CampagneProcessor.GetAllCampagnes().Result;
            SelectedCampagne = Campagnes[0];
        }

        public async void Creerperso(string irljoueur, string nom, string desc, int inspi, string persotrait, string ideal, string bounds, string flaws, int lvl)
        {
            bool rep = await PersoProcessor.CreerPerso( irljoueur,  nom,  desc,  inspi, SelectedArmure.Id, SelectedClasse.id, SelectedRace.Id,  persotrait,  ideal,  bounds,  flaws,  lvl,  SelectedCampagne.Id);
            if (rep)
            {
                Console.WriteLine("oui");

            }
            else
            {
                Console.WriteLine("non");
            }
        }
    }
}
