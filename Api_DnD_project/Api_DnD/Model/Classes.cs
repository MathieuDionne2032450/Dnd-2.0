using System.Data;

namespace Api_DnD.Model
{
    public class Classes
    {
        public string name { get; set; }
        public string description { get; set; }
        public string hitDie { get; set; }
        public string primaryAbility { get; set; }
        public int id { get; set; }
        public ICollection<Campagne> Campagne { get; set; }



        public Classes GetClassesById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Classes> GetListClassesByAbility(string ability)
        {
            throw new NotImplementedException();
        }
        public List<Classes> GetAllClasses()
        {
            throw new NotImplementedException();
        }

        public void PostClasses(string name, string description, string hitDie, string ability)
        {
            throw new NotImplementedException();
        }

        public void PutClasses(string name, string description, string hitDie, string ability)
        {
            throw new NotImplementedException();
        }

        public void DeleteClasses(string name)
        {
            throw new NotImplementedException();
        }
    }
}
