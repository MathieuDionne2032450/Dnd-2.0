using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DojonEtWiki.Api;
using DojonEtWiki.Model;

namespace DojonEtWiki.ViewModel
{
    public class VMCampagne:INotifyPropertyChanged
    {

        #region INotifyPropertyChange
        public event PropertyChangedEventHandler PropertyChanged;


        //Fonction qui gère le lancement de l'événément PropertyChanged
        protected virtual void ValeurChangee(string nomPropriete)
        {
            //Vérifie si il y a au moins 1 abonné
            if (this.PropertyChanged != null)
            {
                //Lance l'événement -> tous les abonnés seront notifiés
                this.PropertyChanged(this, new PropertyChangedEventArgs(nomPropriete));
            }
        }
        #endregion

        static List<Campagne> _listeCampagne;
        public List<Campagne> ListeCampagne
        { 
            get
            {
                return _listeCampagne;
            }
            set 
            {
                _listeCampagne = value;
                ValeurChangee("ListeCampagne");
            } 
        }

        static Campagne _campagne;
        public Campagne Campagne
        {
            get
            {
                return _campagne;
            }
            set
            {
                _campagne = value;
                ValeurChangee("Campagne");
            }
        }



        public VMCampagne()
        {
            ListeCampagne = CampagneProcessor.GetAllCampagnes().Result;
            
        }

    }
}
