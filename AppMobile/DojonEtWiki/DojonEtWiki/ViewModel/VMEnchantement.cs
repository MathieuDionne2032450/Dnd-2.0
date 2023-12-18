using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DojonEtWiki.Model;
using DojonEtWiki.Api;

namespace DojonEtWiki.ViewModel
{
    public class VMEnchantement
    {
        //Enchantement selectionne
        Enchantement _enchantementSelectionne = null;
        public Enchantement EnchantementSelectionne { get { return _enchantementSelectionne; } set { _enchantementSelectionne = value; } }

        //liste des enchantements
        List<Enchantement> _lesEnchantements = null;
        public List<Enchantement> lesEnchantements { get { return _lesEnchantements; } set { _lesEnchantements = value; } }

        //constructeur
        public VMEnchantement()
        {
            lesEnchantements = EnchantementProcessor.GetEnchantement().Result;
            _enchantementSelectionne = lesEnchantements[0];
        }
    }
}
