using System.ComponentModel.DataAnnotations.Schema;

namespace Api_DnD.Model
{
    public class Monstre
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Size { get; set; }
        public int ArmorClass { get; set; }
        public int HitPoint { get; set; }
        public int Speed { get; set; }
        public int FlySpeed { get; set; }
        public int ClimbSpeed { get; set; }
        public int Str { get; set; }
        public int Dex { get; set; }
        public int Con { get; set; }
        public int Intel { get; set; }
        public int Wis { get; set; }
        public int Cha { get; set; }
        public int DarkVision { get; set; }
        public float Challenge { get; set; }
        public string Lang { get; set; }
        public string? DammageResistance { get; set; }
        public string? DammageImmunities { get; set; }
        public string? ConditionImmunities { get; set; }
        public ICollection<Action> Actions { get; set; }
        public ICollection<Campagne> Campagne { get; set; }

        public Monstre(string nom, string size, int armorClass, int hitPoint, int speed, int flySpeed, int climbSpeed, int str, int dex, int con, int intel, int wis, int cha, int darkVision, float challenge, string lang, string? dammageResistance, string? dammageImmunities, string? conditionImmunities)
        {
            Nom = nom;
            Size = size;
            ArmorClass = armorClass;
            HitPoint = hitPoint;
            Speed = speed;
            FlySpeed = flySpeed;
            ClimbSpeed = climbSpeed;
            Str = str;
            Dex = dex;
            Con = con;
            Intel = intel;
            Wis = wis;
            Cha = cha;
            DarkVision = darkVision;
            Challenge = challenge;
            Lang = lang;
            DammageResistance = dammageResistance;
            DammageImmunities = dammageImmunities;
            ConditionImmunities = conditionImmunities;
        }
    }
}
