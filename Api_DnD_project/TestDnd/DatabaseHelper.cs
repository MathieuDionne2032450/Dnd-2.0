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
    }
}
