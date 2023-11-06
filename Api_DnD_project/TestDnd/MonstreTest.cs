using Api_DnD.Controllers;
using Api_DnD.Data;
using Api_DnD.Model;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDnd
{
    [TestClass]
    public class MonstreTest
    {
        private DNDContext context;
        private MonstreController monstreController;
        private DatabaseHelper dbHelper;

        [TestInitialize]
        public void Initialize()
        {
            dbHelper = new DatabaseHelper();
            context = dbHelper.CreateContext();
            dbHelper.CreateTablesMonstre();
            monstreController = new MonstreController(context);
        }

        [TestMethod]
        public async Task TestGetAllMonstre()
        {
            var result = monstreController.GetMonstres("nom", null, 1).Result.Value?.ToList(); ;
            result.Count().Should().Be(3);
            result[0].Challenge.Should().Be(3.33f);
        }

        [TestMethod]
        public async Task TestGetMonstreRecherche()
        {
            var result = monstreController.GetMonstres("nom","bobo", 1).Result.Value?.ToList(); ;
            result.Count().Should().Be(1);
            result[0].Nom.Should().Be("Bobobo");
        }

        [TestMethod]
        public async Task TestGetById()
        {
            var result = await monstreController.GetMonstre(3);
            result.Value?.Nom.Should().Be("Bobobo");
        }

        [TestMethod]
        public async Task TestCreateMonstre()
        {
            await monstreController.CreateMonstre("Nouveau monstre", "Medium rare", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1f, "fr", "air", "air", "air");
            var result = (await monstreController.GetMonstre(5)).Value;
            await context.Entry(result).ReloadAsync();
            result.Nom.Should().Be("Nouveau monstre");
            result.Size.Should().Be("Medium rare");
            result.DammageImmunities.Should().Be("air");
        }

        [TestMethod]
        public async Task TestEditMonstre()
        {
            var result = (await monstreController.GetMonstre(2)).Value;
            await monstreController.EditMonstre(2, "Monstre modifié", "Taille normale", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1f, "fr", "eau", "eau", "eau");
            await context.Entry(result).ReloadAsync();
            result.Nom.Should().Be("Monstre modifié");
            result.Size.Should().Be("Taille normale");
            result.DammageImmunities.Should().Be("eau");
        }

        [TestMethod]
        public async Task TestDeleteMonstre()
        {
            monstreController.DeleteMonstre(2).Result.Should().Be(true);
        }

        [TestCleanup]
        public void Clean()
        {
            context.Database.EnsureDeleted();
        }
    }
}
