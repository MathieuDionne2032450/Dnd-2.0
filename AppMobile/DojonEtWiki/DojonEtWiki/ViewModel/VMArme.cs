using DojonEtWiki.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DojonEtWiki.ViewModel
{
    public class VMArme
    {



        static Arme _arme;
        public Arme Arme
        {
            get
            {
                return _arme;
            }
            set
            {
                _arme = value;
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

        public VMArme()
        {
        }

        public void EditArmure()
        {
            //Api.ArmureProcessor.PutArmure(Arme.id, Arme.BonusJet, Arme.BonusForce, Arme.Nom, Arme.EnchantementId);
            Arme = null;
        }

        public void CreateArmure()
        {
           // Api.ArmureProcessor.PostArmure(Arme.BonusJet,Arme.BonusForce,Arme.Nom,Arme.EnchantementId);
            VMCampagne vm = new VMCampagne();

            Arme = null;
        }

        public void DeleteArmure()
        {
            //Api.ArmureProcessor.DeleteArmure(Armure.Id);
            VMCampagne vm = new VMCampagne();

            Arme = null;
        }
    }
}
