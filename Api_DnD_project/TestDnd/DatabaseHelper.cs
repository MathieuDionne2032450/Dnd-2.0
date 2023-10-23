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
            builder.UseMySql("Server=localhost;Port=3306;Database=dndtest;Uid=root;Pwd=azimcone1", new MySqlServerVersion(new Version(8,0,21))).EnableSensitiveDataLogging();
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

            Armure armure = new Armure
            {
                Name = "Armure",
                Type = "Forte",
                Ac = 2,
                DexBonus = true,
                MaxDexMod = 2,
                StealthDisadvantage = 2,
                EnchantementId = 1
            };

            Arme arme = new Arme
            {
                BonusJet = 2,
                BonusForce = 2,
                Nom = "Épée",
                EnchantementId = 1,
                Campagne = new List<Campagne> { campagne }
            };

            Classes classes = new Classes
            {
                name = "Classe",
                description = "Description de la classe",
                hitDie = "8d6",
                primaryAbility = "Habileté primaire",
                id = 1,
                Campagne = new List<Campagne> { campagne }
            };

            Race race = new Race
            {
                Nom = "Orque",
                BonusPV = 1,
                BonusDex = 1,
                BonusForce = 1,
                BonusIntel = 1,
                BonusWisdom = 1,
                BonusConsti = 1,
                BonusCharisma = 1,
                Id = 1,
                Campagnes = new List<Campagne> { campagne }
            };

            Perso perso = new Perso { 
                IrlJoueur = "Alexandre", 
                Nom = "Krados", 
                Description = "démon démoniaque", 
                Inspiration = 0, 
                ArmureId = 1,
                LesArmes = new List<Arme> { arme },
                ClasseId = 1, 
                RaceId = 1, 
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

            context.Campagnes.Add(campagne);
            context.Enchantements.Add(enchantement);
            context.Armures.Add(armure);
            context.Armes.Add(arme);
            context.Classes.Add(classes);
            context.Races.Add(race);
            context.Persos.Add(perso);

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
