using Api_DnD.Controllers;
using Api_DnD.Data;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDnd
{
    [TestClass]
    public class ArmeTest
    {
        private DNDContext context;
        private ArmeController armeController;
        private DatabaseHelper dbHelper;

        [TestInitialize]
        public void Initialize()
        {
            dbHelper = new DatabaseHelper();
            context = dbHelper.CreateContext();
            dbHelper.CreateTablesArme();
            armeController = new ArmeController(context);
        }

        [TestMethod]
        public void TestGetAll()
        {
            armeController.GetArme(string.Empty, string.Empty, 1).Result.Value?.Count().Should().Be(3);
        }

        [TestMethod]
        public void TestGetById()
        {
            armeController.GetArme(2).Result.Value.Nom.Should().Be("Épée");
        }

        [TestMethod]
        public async Task TestEditArme()
        {
            var result = (await armeController.GetArme(2)).Value;
            await armeController.EditArme(2, 1, 1, "Hache de guerre", 1);
            await context.Entry(result).ReloadAsync();
            result.Nom.Should().Be("Hache de guerre");
            result.BonusForce.Should().NotBe(null);
        }

        [TestMethod]
        public async Task TestCreateArme()
        {
            await armeController.CreateArme(1, 1, "Arbalète", 1);
            var result = (await armeController.GetArme(4)).Value;
            await context.Entry(result).ReloadAsync();
            result.Nom.Should().Be("Arbalète");
        }

        [TestCleanup]
        public void DeleteDatabase()
        {
            context.Database.EnsureDeleted();
        }
    }
}
