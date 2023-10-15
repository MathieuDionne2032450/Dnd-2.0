namespace Api_DnD.Model
{
    public class ArmeDTO
    {
        public string Nom { get; set; }

        public Enchantement Enchantement { get; set; }

        public int id { get; set; }

        public static ArmeDTO ArmeToDTO(Arme a)
        {
            return new ArmeDTO { Nom = a.Nom, Enchantement = a.Enchantement, id = a.id };
        }
    }
}
