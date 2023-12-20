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

        public string irljoueur { get; set; }
        public string nom { get; set; }
        public string desc { get; set; }
        public int inspi { get; set; }
        public string persotrait { get; set; }
        public string ideal { get; set; }
        public string bounds { get; set; }
        public string flaws { get; set; }
        public int lvl { get; set; } 

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

        public async void Creerperso(string irljoueur_p, string nom_p, string desc_p, int inspi_p, string persotrait_p, string ideal_p, string bounds_p, string flaws_p, int lvl_p)
        {
            bool rep = await PersoProcessor.CreerPerso(irljoueur_p, nom_p, desc_p, inspi_p, SelectedArmure.Id, SelectedClasse.id, SelectedRace.Id, persotrait_p, ideal_p, bounds_p, flaws_p, lvl_p,  SelectedCampagne.Id);
            if (rep)
            {
                irljoueur = "";
                nom = "";
                desc = "";
                inspi = 0;
                persotrait = "";
                ideal = "";
                bounds = "";
                flaws = "";
                lvl = 0;
            }
            
        }
    }
}
