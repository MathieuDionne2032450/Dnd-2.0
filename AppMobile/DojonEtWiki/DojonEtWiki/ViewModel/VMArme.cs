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

        public void EditArme()
        {
            Api.ArmeProcessor.PutArme(Arme.id, Arme.BonusJet, Arme.BonusForce, Arme.Nom, Arme.EnchantementId);
            Arme = null;
        }

        public void CreateArme()
        {
           Api.ArmeProcessor.PostArme(Arme.BonusJet,Arme.BonusForce,Arme.Nom,Arme.EnchantementId);
            VMCampagne vm = new VMCampagne();

            Arme = null;
        }

        public void DeleteArme()
        {
            Api.ArmeProcessor.DeleteArme(Arme.id);
            VMCampagne vm = new VMCampagne();

            Arme = null;
        }
    }
}
