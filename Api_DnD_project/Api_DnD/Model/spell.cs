namespace Api_DnD.Model
{
    public class spell
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DammageType { get; set; }
        public int Dammage { get; set; }
        public int ClassId { get; set; }
        public string Zone { get; set; }

        public spell() { }
    }
}
