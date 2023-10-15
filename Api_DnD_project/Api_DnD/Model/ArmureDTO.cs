namespace Api_DnD.Model
{
    public class ArmureDTO
    {
        public string Nom { get; set; }

        public string Type { get; set; }
 
        public Enchantement Enchantement { get; set; }

        public int id { get; set; }

        public static ArmureDTO ArmureToDTO(Armure a)
        {
            return new ArmureDTO { Nom = a.Name, Type = a.Type, Enchantement = a.Enchantement, id = a.Id };
        }
    }
}
