using System;
using System.Collections.Generic;
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

        #region Skill

        public void CreateTablesSkill()
        {
            context.Database.EnsureCreated();

            Campagne campagne = new Campagne
            {
                Id = 1,
                Name = "La campagne",
                Desc = "La campagne principale",
                Armes = new List<Arme>(),
                Armures = new List<Armure>(),
                Enchantements = new List<Enchantement>(),
                Monstres = new List<Monstre>(),
                PNJs = new List<PNJ>(),
                Quetes = new List<Quete>(),
                Classes = new List<Classes>(),
                Races = new List<Race>()
            };

            Enchantement enchantement = new Enchantement
            {
                Nom = "Enchantement",
                Description = "Enchantement cool",
                Type = "Enchanté",
                Modif = 1,
                Id = 1
            };

            Perso perso = new Perso { 
                IrlJoueur = "Alexandre", 
                Nom = "Krados", 
                Description = "démon démoniaque", 
                Inspiration = 0, 
                ArmureId = 1, 
                ClasseId = 1, 
                RaceId = 3, 
                Personalitetrait = "evil", 
                Ideal = "Justice", 
                Bonds = "Avec Louise", 
                Flaws = "Le bruit", 
                Niv = 1, 
                CampagneId = 1 };

            List<Perso> persos = new List<Perso> { perso };

            Skill[] skills = new Skill[]
            {
                new Skill { id = 1, Descr = "Compétences acérées", Nom = "Skillz", Persos = persos },
                new Skill { id = 2, Descr = "Force incroyable", Nom = "Gros muscles", Persos = persos },
                new Skill { id = 3, Descr = "Capacité de voler", Nom = "Ailes", Persos = persos }
            };

            foreach(Skill s in skills)
            {
                context.Skill.Add(s);
            }

            context.SaveChanges();
        }

        public void DropTables()
        {
            context.Database.EnsureDeleted();
        }

        #endregion
    }
}
