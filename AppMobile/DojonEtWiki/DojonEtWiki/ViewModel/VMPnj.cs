using DojonEtWiki.Api;
using DojonEtWiki.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojonEtWiki.ViewModel
{
    public class VMPnj
    {
        List<PNJ> pnj;
        static PNJ selectedpnj;

        public List<PNJ> Pnjs { get { return pnj; } set { pnj = value; } }
        public PNJ SelectedPnj { get { return selectedpnj; } set { selectedpnj = value; } }


        public VMPnj()
        {
            Pnjs = PNJProcessor.GetPnjs().Result; 
        }
    }
}
