using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Api_DnD.Data;
using Api_DnD.Model;
using Microsoft.EntityFrameworkCore;

namespace TestDnd
{
    public class DatabaseHelper
    {
        DNDContext context;

        public DNDContext CreateContext()
        {
            DbContextOptionsBuilder<DNDContext> builder = new DbContextOptionsBuilder<DNDContext>();
            builder.UseMySql("Server=sql.decinfo-cchic.ca;Port=33306;Database=a23_sda_test_mal;Uid=dev-2032450;Pwd=Info2020", new MySqlServerVersion(new Version(8,0,21))).EnableSensitiveDataLogging();
            context = new DNDContext(builder.Options);

            return context;
        }

        #region Enchantement
        public void CreateTablesEnchantement()
        {
            context.Database.EnsureCreated();

            Enchantement[] enchantements = new Enchantement[]
            {
                new Enchantement { Nom = "eau", Description = "eau", Type = "eau", Modif = 2 },
                new Enchantement { Nom = "feu", Description = "feu", Type = "feu", Modif = 2 },
                new Enchantement { Nom = "galce", Description = "glace", Type = "glace", Modif = 2 },
                new Enchantement { Nom = "terre", Description = "terre", Type = "terre", Modif = 2 },
                new Enchantement { Nom = "poison", Description = "poison", Type = "poison", Modif = 2 },
            };

            foreach(Enchantement e in enchantements)
            {
                context.Enchantements.Add(e);
            }

            context.SaveChanges();
        }

        public void DropTablesEnchantement()
        {
            context.Database.EnsureDeleted();
        }

        #endregion endenchantement

        #region Perso
        public void CreateTablesPerso()
        {
            Race race = new Race() { Id = 1, BonusCharisma = 1, BonusDex = 1, BonusConsti = 1, BonusForce = 1, BonusIntel = 1, BonusPV = 1, BonusWisdom = 1, Nom = "Loup" };
            Enchantement enchant = new Enchantement() { Id = 1, Description="waw"};
            Classes classe = new Classes() { id = 1, description = "desc", hitDie = "2d4", name="Mage",primaryAbility="boule de feu"};

        Perso[] persos = new Perso[]
            {
                
                new Perso { IrlJoueur = "Alexandre", Nom = "Dreknethol", Description = "Un beau perso qui est vraiment le plus beau de tous", Inspiration = 0, ArmureId = 1,Armure = new Armure("armure1","lourde",14,false,0,0,1,1,1), LesArmes = new List<Arme>(),
                    ClasseId = 1, Classes = classe, RaceId = 1, Race = race, Skills = new List<Skill>(), Personalitetrait = "beau",
                    Ideal="beauté",Bonds = "Les gens beau", Flaws = "La laideur", Niv = 15, id = 1, CampagneId=1,Campagne=new Campagne(){ Id=1, Desc="campagne plate",Name="plate"}, feats = new List<feats>() },
                
                new Perso { IrlJoueur = "Mathieu", Nom = "Bwipo", Description = "un laid", Inspiration = 0, ArmureId = 2,Armure = new Armure("armure1","lourde",14,false,0,0,1,2,1), LesArmes = new List<Arme>(),
                    ClasseId = 2, Classes = classe, RaceId = 2, Race = race, Skills = new List<Skill>(), Personalitetrait = "laid",
                    Ideal="laideur",Bonds = "Les gens laid", Flaws = "La beauté", Niv = 5, id = 2, CampagneId=2,Campagne=new Campagne(){ Id=2, Desc="campagne Dole",Name="dole"}, feats = new List<feats>() },
                
                new Perso { IrlJoueur = "Louis", Nom = "Louise", Description = "jeune damme cool", Inspiration = 0, ArmureId = 3,Armure = new Armure("armure1","lourde",14,false,0,0,1,3,1), LesArmes = new List<Arme>(),
                    ClasseId = 3, Classes = classe, RaceId = 1, Race = race, Skills = new List<Skill>(), Personalitetrait = "beau",
                    Ideal="cool",Bonds = "Les gens cool", Flaws = "Les gens pas cool", Niv = 1, id = 3, CampagneId=3,Campagne=new Campagne(){ Id=3, Desc="campagne Fun",Name="fun"}, feats = new List<feats>() },


            };

            foreach (Perso p in persos)
            {
                context.Persos.Add(p);
            }

            context.SaveChanges();
        }

        public void DropTablesPerso()
        {
            context.Database.EnsureDeleted();
        }

        #endregion endenchantement
    }
}
