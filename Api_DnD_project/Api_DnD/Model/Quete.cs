using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Api_DnD.Model
{
    public class Quete
    {
        public int Id { get; set; }

        public PNJ Pnj { get; set; }

        public string DescriptionQuete { get; set; }

        public string reward { get; set; }

        public ICollection<Campagne> Campagne { get; set; }

    }
}
