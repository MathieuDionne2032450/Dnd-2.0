namespace Api_DnD.Model
{
    public class Spell
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DammageType { get; set; }
        public int Dammage { get; set; }
        public int ClassId { get; set; }
        public string Zone { get; set; }

        public Spell()
        {
            
        }
        public Spell(int id, string name, string description, string dammageType, int dammage, int classId, string zone)
        {
            this.id = id;
            Name = name;
            Description = description;
            DammageType = dammageType;
            Dammage = dammage;
            ClassId = classId;
            Zone = zone;
        }
    }
}
