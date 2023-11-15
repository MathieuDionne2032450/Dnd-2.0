using System.Data;

namespace DojonEtWiki.Model
{
    public class Classes
    {
        public string? name { get; set; }
        public string? description { get; set; }
        public string? hitDie { get; set; }
        public string? primaryAbility { get; set; }
        public int id { get; set; }
        public ICollection<Campagne>? Campagne { get; set; }
    }
}
