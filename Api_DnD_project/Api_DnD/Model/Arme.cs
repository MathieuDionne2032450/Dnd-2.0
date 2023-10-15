using System.ComponentModel.DataAnnotations.Schema;

namespace Api_DnD.Model
{
    public class Arme
    {
        public int BonusJet { get; set; }

        public int BonusForce { get; set; }

        public string Nom { get; set; }

        public int EnchantementId { get; set; }

        [ForeignKey("EnchantementId")]
        public Enchantement Enchantement { get; set; }


        public ICollection<Campagne> Campagne { get; set; }



        public int id { get; set; }

    }
}
