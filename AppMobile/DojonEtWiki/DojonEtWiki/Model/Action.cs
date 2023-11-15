using System.ComponentModel.DataAnnotations.Schema;

namespace DojonEtWiki.Model
{
    public class Action
    {
        public ICollection<Monstre> Monstres { get; set; }
        public string Type { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descr { get; set; }
        public string Dammage { get; set; }
        public string DammageType { get; set; }
        public int Dc { get; set; }
        public string DcType { get; set; }
        public int CampagneId { get; set; }
        [ForeignKey("CampagneId")]
        public Campagne Campagne { get; set; }


    }
}
