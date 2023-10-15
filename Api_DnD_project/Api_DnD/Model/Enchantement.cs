namespace Api_DnD.Model
{
    public class Enchantement
    {
        public string Nom { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Modif { get; set; }
        public int Id { get; set; }
        public ICollection<Campagne> Campagne { get; set; }
    }
}
