namespace Api_DnD.Model
{
    public class feats
    {
        public int id { get; set; }
        public string? Nom { get; set; }
        public string? Descr { get; set; }
        public ICollection<Perso> Persos { get; set; }

        public feats() { }
    }
}
