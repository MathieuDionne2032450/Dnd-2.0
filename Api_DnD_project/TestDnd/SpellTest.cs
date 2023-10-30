using Api_DnD.Controllers;
using Api_DnD.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Api_DnD.Model;
using System.Security.Policy;
using System.Xml.Linq;

namespace TestDnd
{
    [TestClass]
    public class SpellTest
    {
        private DNDContext context;
        private SpellsController spellsController;
        private DatabaseHelper dbHelper;

        [TestInitialize]
        public void Initialize()
        {
            DatabaseHelper databaseHelper = new DatabaseHelper();
            context = databaseHelper.CreateContext();
            databaseHelper.CreateTablesSpell();
            spellsController = new SpellsController(context);
        }

        [TestMethod]
        public void TestGetAllSpells()
        {
            var result = spellsController.GetSpells("dammage", "", 0).Result.Value?.ToList();
            result.Count().Should().Be(2);
            result[0].Dammage.Should().Be(20);
        }

        [TestMethod]
        public void TestGetSpellsRecherche()
        {
            var result = spellsController.GetSpells("dammage", "de feu", 0).Result.Value?.ToList();
            result.Count().Should().Be(1);
            result[0].Name.Should().Be("Lazer de feu");
        }

        [TestMethod]
        public void TestGetSpell()
        {
            spellsController.GetSpell(1).Result.Value.Name.Should().Be("Lazer de feu");
        }

        [TestMethod]
        public async Task TestEditSpell()
        {
            var result = (await spellsController.GetSpell(1)).Value;
            await spellsController.EditSpell(1, "Boule de feu", "lance une boule de feu qui crée une explosion de 20ft de rayon dans une zone visible par le joueur", "Feu", 48, 1, "rayon de 20ft");
            await context.Entry(result).ReloadAsync();
            result.Name.Should().Be("Boule de feu");
            result.Dammage.Should().Be(48);
            result.Zone.Should().Be("rayon de 20ft");

        }

        [TestMethod]
        public void TestCreateSpell()
        {
            spellsController.CreateSpell(3, "Wish", "Le joueur fait un voeux qui se réalisera", "-", 0, 1, "-");

            spellsController.GetSpell(3).Result.Value.Name.Should().Be("Wish");
            spellsController.GetSpell(3).Result.Value.DammageType.Should().Be("-");
            spellsController.GetSpell(3).Result.Value.ClassId.Should().Be(1);
        }

        [TestMethod]
        public void TestDeleteSpell()
        {
            spellsController.DeleteSpell(4);

            spellsController.GetSpell(4).Result.Value.Should().Be(null);
        }

        [TestCleanup]
        public void DeleteDatabase()
        {
            context.Database.EnsureDeleted();
        }
    }
}
