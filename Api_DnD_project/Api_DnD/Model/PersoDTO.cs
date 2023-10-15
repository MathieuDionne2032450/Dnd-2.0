namespace Api_DnD.Model
{
    public class PersoDTO
    {
        public string Nom { get; set; }
        public int Niv { get; set; }
        public int id { get; set; }
        

        public PersoDTO() { }

        public static PersoDTO PersoToDTO(Perso p)
        {
            return new PersoDTO { Nom = p.Nom, id = p.id, Niv = p.Niv };
        }
    }
}