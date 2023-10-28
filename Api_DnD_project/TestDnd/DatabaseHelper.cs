using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Api_DnD.Data;
using Api_DnD.Model;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace TestDnd
{
    public class DatabaseHelper
    {
        DNDContext context;

        public DNDContext CreateContext()
        {
            DbContextOptionsBuilder<DNDContext> builder = new DbContextOptionsBuilder<DNDContext>();
            builder.UseMySql("Server=localhost;Port=3306;Database=dndtest;Uid=admin;Pwd=Popomoka8934", new MySqlServerVersion(new Version(8,0,21))).EnableSensitiveDataLogging();
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

        #region Classes
        public void CreateTablesClasses()
        {
            context.Database.EnsureCreated();

            Classes[] classes = new Classes[]
            {
                new Classes {name = "homme", description = "humain normal", hitDie="test1", primaryAbility ="Courrir" },
                new Classes {name = "Elf", description = "oreille pointu", hitDie="test2", primaryAbility ="parler la langue elfique" },
                new Classes {name = "ogre", description = "shrek", hitDie="test3", primaryAbility ="vit dans un marecage"  }
            };

            foreach (Classes c in classes)
            {
                context.Classes.Add(c);
            }

            context.SaveChanges();
        }

        public void DropTablesClasses()
        {
            context.Database.EnsureDeleted();
        }

        #endregion Classes

        #region Perso
        public void CreateTablesPerso()
        {
            context.Database.EnsureCreated();

            Campagne campagne = new Campagne
            {
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

            Enchantement enchant = new Enchantement() { Nom = "Salabim", Type = "Enchantement magique", Modif = 1, Description = "waw" };

            Armure armure = new Armure
            {
                Name = "Armure",
                Type = "Forte",
                Ac = 2,
                DexBonus = true,
                MaxDexMod = 2,
                StealthDisadvantage = 2,
                Enchantement = enchant
            };

            Arme arme = new Arme
            {
                BonusJet = 2,
                BonusForce = 2,
                Nom = "Épée",
                Enchantement = enchant,
                Campagne = new List<Campagne> { campagne }
            };

            Race race = new Race() { BonusCharisma = 1, BonusDex = 1, BonusConsti = 1, BonusForce = 1, BonusIntel = 1, BonusPV = 1, BonusWisdom = 1, Nom = "Loup" };
            Classes classe = new Classes() { description = "desc", hitDie = "2d4", name="Mage",primaryAbility="boule de feu"};

            Perso perso = new Perso
            {
                IrlJoueur = "Alexandre",
                Nom = "Krados",
                Description = "démon démoniaque",
                Inspiration = 0,
                Armure = armure,
                LesArmes = new List<Arme> { arme },
                Classes = classe,
                Race = race,
                Personalitetrait = "evil",
                Ideal = "Justice",
                Bonds = "Avec Louise",
                Flaws = "Le bruit",
                Niv = 1,
                Campagne = campagne
            };

            Skill skill = new Skill { Descr = "Compétences acérées", Nom = "Skillz", Persos = new List<Perso> { perso } };

            feats feat = new feats { Nom = "Artificier", Descr = "Peut tirer du cannon" };

            context.Campagnes.Add(campagne);
            context.Enchantements.Add(enchant);
            context.Armures.Add(armure);
            context.Armes.Add(arme);
            context.Races.Add(race);
            context.Classes.Add(classe);
            context.Persos.Add(perso);
            context.Skill.Add(skill);
            context.Feats.Add(feat);

            Perso[] persos = new Perso[]
            {
                
                new Perso { IrlJoueur = "Alexandre", Nom = "Dreknethol", Description = "Un beau perso qui est vraiment le plus beau de tous", Inspiration = 0,Armure = armure, LesArmes = new List<Arme>{ arme },
                     Classes = classe, Race = race, Skills = new List<Skill> { skill }, Personalitetrait = "beau",
                    Ideal="beauté",Bonds = "Les gens beau", Flaws = "La laideur", Niv = 15, Campagne=campagne, feats = new List<feats>{ feat } },
                
                new Perso { IrlJoueur = "Mathieu", Nom = "Bwipo", Description = "un laid", Inspiration = 0,Armure = armure, LesArmes = new List<Arme>{ arme },
                     Classes = classe, Race = race, Skills = new List<Skill>{ skill }, Personalitetrait = "laid",
                    Ideal="laideur",Bonds = "Les gens laid", Flaws = "La beauté", Niv = 5,Campagne=campagne, feats = new List<feats> { feat } },
                
                new Perso { IrlJoueur = "Louis", Nom = "Louise", Description = "jeune damme cool", Inspiration = 0,Armure = armure, LesArmes = new List<Arme>{ arme },
                    Classes = classe,Race = race, Skills = new List<Skill>{ skill }, Personalitetrait = "beau",
                    Ideal="cool",Bonds = "Les gens cool", Flaws = "Les gens pas cool", Niv = 1,Campagne=campagne, feats = new List<feats> { feat } },
            };

            foreach (Perso p in persos)
            {
                context.Persos.Add(p);
            }

            context.SaveChanges();
            
        }

        public async Task DropTablesPerso()
        {
            context.Database.EnsureDeleted();
        }

        #endregion Perso

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

            foreach (Skill s in skills)
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

        #region Arme

        public void CreateTablesArme()
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

            Arme[] armes = new Arme[]
            {
                new Arme { BonusJet = 1, BonusForce = 1, Nom = "Massue", Enchantement = enchantement, Campagne = new List<Campagne> { campagne } },
                new Arme { BonusJet = 1, BonusForce = 1, Nom = "Épée", Enchantement = enchantement, Campagne = new List<Campagne> { campagne } },
                new Arme { BonusJet = 1, BonusForce = 1, Nom = "Poignard", Enchantement = enchantement, Campagne = new List<Campagne> { campagne } }
            };

            context.Campagnes.Add(campagne);
            context.Enchantements.Add(enchantement);
            
            foreach(Arme arme in armes)
            {
                context.Armes.Add(arme);
            }

            context.SaveChanges();
        }

        #endregion

        #region Feats

        public void CreateTablesFeats()
        {
            context.Database.EnsureCreated();





            feats[] featslist = new feats[]
            {
                new feats { id = 1, Nom = "Artificier", Descr = "Peut tirer du cannon" },
                new feats { id = 2, Nom = "Homme du feu", Descr = "Est resistant au dégat de feu" },
                new feats { id = 3, Nom = "Main leste", Descr = "peut utliser une bonus action pour recharger" },

            };

            
            foreach (feats feats in featslist)
            {
                context.Feats.Add(feats);
            }

            context.SaveChanges();
        }

        #endregion

        #region Spell

        public void CreateTablesSpell()
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

            Perso perso = new Perso
            {
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
                CampagneId = 1
            };

            List<Perso> persos = new List<Perso> { perso };

            Spell[] Spelllist = new Spell[]
            {
                new Spell() { id = 1, Name = "Lazer de feu", Description = "tire un lazer de feu sur 1 énemi",DammageType="Feu",Dammage=20,ClassId=1,Zone="Cible" },
                new Spell() { id = 2, Name = "Foudre des dieux", Description = "Fait tomber la foudre sur un cible avec un rayon de 20ft",DammageType="Foudre",Dammage=75,ClassId=1,Zone="20ft" },

            };

            context.Campagnes.Add(campagne);
            context.Enchantements.Add(enchantement);
            context.Armures.Add(armure);
            context.Armes.Add(arme);
            context.Classes.Add(classes);
            context.Races.Add(race);
            context.Persos.Add(perso);

            foreach (Spell s in Spelllist)
            {
                context.Spells.Add(s);
            }

            context.SaveChanges();
        }

        #endregion

        #region Armure

        public void CreateTablesArmure()
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

            Armure[] armures = new Armure[]
            {
                new Armure { Name = "Plastron", Type = "Fer", Ac = 1, DexBonus = true, MaxDexMod = 1, StealthDisadvantage = 1, Enchantement = enchantement, Campagne = new List<Campagne> { campagne } },
                new Armure { Name = "Bottes", Type = "Cuir", Ac = 1, DexBonus = false, MaxDexMod = 1, StealthDisadvantage = 1, Enchantement = enchantement, Campagne = new List<Campagne> { campagne } },
                new Armure { Name = "Casque", Type = "Diamant", Ac = 1, DexBonus = true, MaxDexMod = 1, StealthDisadvantage = 1, Enchantement = enchantement, Campagne = new List<Campagne> { campagne } }
            };

            context.Campagnes.Add(campagne);
            context.Enchantements.Add(enchantement);
            foreach (Armure armure in armures)
            {
                context.Add(armure);
            }

            context.SaveChanges();
        }

        #endregion

        #region Campagne

        public void CreateTablesCampagne()
        {
            context.Database.EnsureCreated();

            Campagne[] campagnes = new Campagne[]
            {
            new Campagne
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
                },
            new Campagne
                {
                    Id = 2,
                    Name = "L'autre campagne",
                    Desc = "La campagne secondaire",
                    Armes = new List<Arme>(),
                    Armures = new List<Armure>(),
                    Enchantements = new List<Enchantement>(),
                    Monstres = new List<Monstre>(),
                    PNJs = new List<PNJ>(),
                    Quetes = new List<Quete>(),
                    Classes = new List<Classes>(),
                    Races = new List<Race>()
                },
            };

            foreach(Campagne campagne in campagnes)
            {
                context.Campagnes.Add(campagne);
            }

            context.SaveChanges();
        }

        #endregion

        #region Monstre

        public void CreateTablesMonstre()
        {
            context.Database.EnsureCreated();

            Campagne campagne = new Campagne
            {
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

            // Il faut une liste de monstres pour pouvoir créer une Action, donc voici un qui servira juste à remplir la liste
            Monstre monstrePourAction = new Monstre("Remplisseur de liste", "Très grand", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1f, "fr", "feu", "feu", "feu");

            Api_DnD.Model.Action action = new Api_DnD.Model.Action
            {
                Monstres = new List<Monstre> { monstrePourAction },
                Type = "Je sais pas c'est quoi une Action",
                Name = "Action",
                Descr = "Action",
                Dammage = "Beaucoup",
                DammageType = "Psychologique",
                Dc = 1,
                DcType = "Detective Comics",
                Campagne = campagne
            };

            Monstre[] monstres = new Monstre[]
            {
                new Monstre
                {
                    Nom = "Bolimbo",
                    Size = "Très grand",
                    ArmorClass = 1,
                    HitPoint = 1,
                    Speed = 1,
                    FlySpeed = 1,
                    ClimbSpeed = 1,
                    Str = 1,
                    Dex = 1,
                    Con = 1,
                    Intel = 1,
                    Wis = 1,
                    Cha = 1,
                    DarkVision = 1,
                    Challenge = 1.33f,
                    Lang = "fr",
                    DammageResistance = "Feu",
                    DammageImmunities = "Nécromancie",
                    ConditionImmunities = "Fromage Boivin",
                    Actions = new List<Api_DnD.Model.Action> { action },
                    Campagne = new List<Campagne>{campagne}
                },
                new Monstre
                {
                    Nom = "Bobobo",
                    Size = "Très petit",
                    ArmorClass = 1,
                    HitPoint = 1,
                    Speed = 1,
                    FlySpeed = 1,
                    ClimbSpeed = 1,
                    Str = 1,
                    Dex = 1,
                    Con = 1,
                    Intel = 1,
                    Wis = 1,
                    Cha = 1,
                    DarkVision = 1,
                    Challenge = 1.33f,
                    Lang = "fr",
                    DammageResistance = "Feu",
                    DammageImmunities = "Nécromancie",
                    ConditionImmunities = "Fromage Boivin",
                    Actions = new List<Api_DnD.Model.Action> { action },
                    Campagne = new List<Campagne>{campagne}
                },
                new Monstre
                {
                    Nom = "Bofadfbnl",
                    Size = "Très moyen",
                    ArmorClass = 1,
                    HitPoint = 1,
                    Speed = 1,
                    FlySpeed = 1,
                    ClimbSpeed = 1,
                    Str = 1,
                    Dex = 1,
                    Con = 1,
                    Intel = 1,
                    Wis = 1,
                    Cha = 1,
                    DarkVision = 1,
                    Challenge = 1.33f,
                    Lang = "fr",
                    DammageResistance = "Feu",
                    DammageImmunities = "Nécromancie",
                    ConditionImmunities = "Fromage Boivin",
                    Actions = new List<Api_DnD.Model.Action> { action },
                    Campagne = new List<Campagne>{campagne}
                },
            };

            foreach(Monstre monstre in monstres)
            {
                context.Monstres.Add(monstre);
            }

            context.SaveChanges();
        }

        #endregion

    }
}
