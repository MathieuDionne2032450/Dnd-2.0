using DojonEtWiki.Api;
using DojonEtWiki.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DojonEtWiki.Api;

namespace DojonEtWiki.ViewModel
{
    public class VMArmure
    {

    
    static Armure _armure;
        public Armure Armure
        {
            get
            {
                return _armure;
            }
            set
            {
                _armure = value;
            }
        }

        static bool _verifCreate;
        public bool VerifCreate
        {
            get
            {
                return _verifCreate;
            }
            set
            {
                _verifCreate = value;
            }
        }

        static bool _verifEdit;
        public bool VerifEdit
        {
            get
            {
                return _verifEdit;
            }
            set
            {
                _verifEdit = value;
            }
        }

        public VMArmure()
        {
        }

        public void EditArmure()
        {
            Api.ArmureProcessor.PutArmure(Armure.Id, Armure.Name, Armure.Type, Armure.Ac, Armure.DexBonus, Armure.MaxDexMod, Armure.StealthDisadvantage, Armure.EnchantementId);
            Armure = null;
        }

        public void CreateArmure()
        {
            Api.ArmureProcessor.PostArmure(Armure.Name, Armure.Type, Armure.Ac, Armure.DexBonus, Armure.MaxDexMod, Armure.StealthDisadvantage, Armure.EnchantementId);
            VMCampagne vm = new VMCampagne();
            
            Armure = null;
        }

        public void DeleteArmure()
        {
            Api.ArmureProcessor.DeleteArmure(Armure.Id);
            VMCampagne vm = new VMCampagne();

            Armure = null;
        }
    }
}
