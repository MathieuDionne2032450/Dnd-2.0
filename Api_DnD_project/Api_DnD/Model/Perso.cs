using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Api_DnD.Model
{
    public class Perso
    {
        public string IrlJoueur { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public int Inspiration { get; set; }
        public int ArmureId { get; set; }
        [ForeignKey("ArmureId")]
        public Armure Armure { get; set; }
        public ICollection<Arme>? LesArmes { get; set; }
        public int ClasseId { get; set; }
        [ForeignKey("ClasseId")]
        public Classes Classes { get; set; }
        public int RaceId { get; set; }
        [ForeignKey("RaceId")]
        public Race Race { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public string Personalitetrait { get; set; }
        public string Ideal { get; set; }
        public string Bonds { get; set; }
        public string Flaws { get; set; }
        public int Niv { get; set; }
        public int id { get; set; }
        public Campagne Campagne { get; set; }

        public static Perso PersoToPerso(Perso p)
        {
            return new Perso
            {
                Nom = p.Nom,
                Description = p.Description,
                Inspiration = p.Inspiration,
                Armure = p.Armure,
                LesArmes = p.LesArmes,
                Classes = p.Classes,
                Race = p.Race,
                Skills = p.Skills,
                Personalitetrait = p.Personalitetrait,
                Ideal = p.Ideal,
                Bonds = p.Bonds,
                Flaws = p.Flaws, 
                Niv = p.Niv,
                id = p.id
            };
        }
        
    }
}
