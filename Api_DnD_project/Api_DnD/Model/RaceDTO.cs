namespace Api_DnD.Model
{
    public class RaceDTO
    {
        public int BonusPV { get; set; }
        public int BonusDex { get; set; }
        public int BonusForce { get; set; }
        public int BonusIntel { get; set; }
        public int BonusWisdom { get; set; }
        public int BonusConsti { get; set; }

        public static RaceDTO RaceToDTO(Race r)
        {
            return new RaceDTO 
            { 
                BonusPV = r.BonusPV,
                BonusDex = r.BonusDex,
                BonusForce = r.BonusForce,
                BonusIntel = r.BonusIntel,
                BonusWisdom = r.BonusWisdom,
                BonusConsti = r.BonusConsti
            };
        }
    }
}
