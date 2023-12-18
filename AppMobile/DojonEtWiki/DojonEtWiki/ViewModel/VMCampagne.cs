using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DojonEtWiki.Api;
using DojonEtWiki.Model;

namespace DojonEtWiki.ViewModel
{
    public class VMCampagne
    {
        List<Campagne> _listeCampagne;
        public List<Campagne> ListeCampagne
        { 
            get
            {
                return _listeCampagne;
            }
            set 
            {
                _listeCampagne = value;
            } 
        }

        Campagne _campagne;
        public Campagne Campagne
        {
            get
            {
                return _campagne;
            }
            set
            {
                _campagne = value;
            }
        }

        public VMCampagne()
        {
            ListeCampagne = CampagneProcessor.GetAllCampagnes().Result;
        }

    }
}
