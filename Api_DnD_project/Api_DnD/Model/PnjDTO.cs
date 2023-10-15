namespace Api_DnD.Model
{
    public class PnjDTO
    {
        public string Nom { get; set; }
        public int[] DescriptionPhysique { get; set; }
        public ICollection<Quete> Quetes { get; set; }

        
        public PnjDTO() {}

        public static PnjDTO PnjToPnjDTO(PNJ? p)
        {
            int[] Physique = new int[] { p.Bouche, p.Nez, p.Barbe, p.Cheveux, p.Sourcil, p.Tete, p.Yeux1, p.Yeux2 };
            return new PnjDTO { Nom = p.Name,DescriptionPhysique = Physique ,Quetes = p.Quetes };
        }
    }
}
