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
    public class CampagneTest
    {
        private DNDContext context;
        private CampagneController campagneController;
        private DatabaseHelper dbHelper;

        [TestInitialize]
        public void Initialize()
        {
            dbHelper = new DatabaseHelper();
            context = dbHelper.CreateContext();
            dbHelper.CreateTablesCampagne();
            campagneController = new CampagneController(context);
        }

        [TestMethod]
        public async Task TestGetAllCampagne()
        {
            var result = campagneController.GetCampagne("nom", null, 1).Result.Value?.ToList();
            result.Count().Should().Be(2);
            result[0].Name.Should().Be("L'autre campagne");
        }

        [TestMethod]
        public async Task TestGetCampagneRecherche()
        {
            var result = campagneController.GetCampagne("nom", "autre", 1).Result.Value?.ToList();
            result.Count().Should().Be(1);
            result[0].Name.Should().Be("L'autre campagne");
        }

        [TestMethod]
        public void TestGetById()
        {
            campagneController.GetCampagneById(2).Result.Value.Name.Should().Be("L'autre campagne");
        }

        [TestMethod]
        public async Task TestEditCampagne()
        {
            var result = (await campagneController.GetCampagneById(2)).Value;
            await campagneController.EditCampagne(2, "La belle campagne", "Belle campagne où on s'ouvre une p'tite frette entre chums et on joue ça à la légère tout en étant quand même investi dans l'histoire.");
            await context.Entry(result).ReloadAsync();
            result.Name.Should().Be("La belle campagne");
            result.Desc.Should().Be("Belle campagne où on s'ouvre une p'tite frette entre chums et on joue ça à la légère tout en étant quand même investi dans l'histoire.");
        }

        [TestMethod]
        public async Task TestCreateCampagne()
        {
            await campagneController.CreateCampagne("Campagne poche", "campagne poche");
            var result = (await campagneController.GetCampagneById(3)).Value;
            await context.Entry(result).ReloadAsync();
            result.Name.Should().Be("Campagne poche");
            result.Desc.Should().Be("campagne poche");
        }

        [TestMethod]
        public async Task TestDeleteCampagne()
        {
            campagneController.DeleteCampagne(2).Result.Should().Be(true);
        }

        [TestCleanup]
        public void DeleteDatabase()
        {
            context.Database.EnsureDeleted();
        }
    }
}
