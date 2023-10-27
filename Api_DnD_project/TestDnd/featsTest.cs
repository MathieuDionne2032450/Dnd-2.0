using Api_DnD.Controllers;
using Api_DnD.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace TestDnd
{
    [TestClass]
    public class featsTest
    {
        private DNDContext context;
        private FeatsController featsController;
        private DatabaseHelper dbHelper;

        [TestInitialize]
        public void Initialize()
        {
            dbHelper = new DatabaseHelper();
            context = dbHelper.CreateContext();
            dbHelper.CreateTablesFeats();
            featsController = new FeatsController(context);
        }

        [TestMethod]
        public void TestGetAll()
        {
            featsController.GetFeats(string.Empty, string.Empty, 1).Result.Value?.Count().Should().Be(3);
        }

        [TestMethod]
        public void TestGetById()
        {
            featsController.GetFeat(3).Result.Value.Nom.Should().Be("Main leste");
        }

        [TestMethod]
        public async Task TestEditFeat()
        {
            var result = (await featsController.GetFeat(2)).Value;
            await featsController.EditFeat(result.id, result.Nom, "N'a pas besoin de recharger");
            await context.Entry(result).ReloadAsync();
            result.Descr.Should().Be("N'a pas besoin de recharger");
            result.id.Should().NotBe(null);
        }

        [TestMethod]
        public async Task TestCreateFeat()
        {
            await featsController.CreateFeat("L'homme de la mer", "Peut respirer sous l'eau");
            var result = (await featsController.GetFeat(4)).Value;
            await context.Entry(result).ReloadAsync();
            result.Nom.Should().Be("L'homme de la mer");
            result.Descr.Should().Be("Peut respirer sous l'eau");
            result.id.Should().NotBe(null);
        }

        [TestMethod]
        public async Task TestDeleteFeat()
        {
            await featsController.DeleteFeat(3);

            context.SaveChanges();

            featsController.GetFeats(string.Empty, string.Empty, 1).Result.Value?.Count().Should().Be(2);

        }

        [TestCleanup]
        public void DeleteDatabase()
        {
            context.Database.EnsureDeleted();
        }

    }
}
