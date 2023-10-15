namespace Api_DnD.Model
{
    public class Race
    {
        public string Nom { get; set; }
        public int BonusPV { get; set; }
        public int BonusDex { get; set; }
        public int BonusForce { get; set; }
        public int BonusIntel { get; set; }
        public int BonusWisdom { get; set; }
        public int BonusConsti { get; set; }
        public int BonusCharisma {get;set;}
        public int Id { get; set; }
        public ICollection<Campagne> Campagnes { get; set; }

        public Race(string nom, int bonusPV, int bonusDex, int bonusForce, int bonusIntel, int bonusWisdom, int bonusConsti, int bonusCharisma, int id)
        {
            Nom = nom;
            BonusPV = bonusPV;
            BonusDex = bonusDex;
            BonusForce = bonusForce;
            BonusIntel = bonusIntel;
            BonusWisdom = bonusWisdom;
            BonusConsti = bonusConsti;
            BonusCharisma = bonusCharisma;
            Id = id;
        }

        public Race()
        {

        }
    }
}
