using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Api_DnD.Controllers;
using Api_DnD.Data;
using Api_DnD.Model;
using System.Xml.Linq;

namespace TestDnd
{
    [TestClass]
    public class pnjTest
    {
        private DNDContext context;
        private PNJController PnjController;
        private DatabaseHelper dbHelper;

        [TestInitialize]
        public void Initialize()
        {
            dbHelper = new DatabaseHelper();
            context = dbHelper.CreateContext();
            dbHelper.CreateTablesPnj();
            PnjController = new PNJController(context);
        }

        [TestMethod]
        public async Task TestGetAll()
        {
            var result = PnjController.GetAllPNJ("Id", null, 1).Result.Value?.ToList();
            result.Count().Should().Be(3);
            result[0].Nom.Should().Be("Gaspare Boneclaw");
            
        }

        [TestMethod]
        public async Task TestGetById()
        {
            var result = await PnjController.GetPnj(2);
            result.Value?.Name.Should().Be("Roger Steven");
            result.Value?.Yeux1.Should().Be(2);

        }

        [TestMethod]
        public async Task TestEditPnj()
        {
            await PnjController.EditPNJ(2, 4, 4, 4, 4, 4, 4, 4, 4, null, "Bob Bissonette");
            var result = (await PnjController.GetPnj(2)).Value;
            await context.Entry(result).ReloadAsync();
            result.Name.Should().Be("Bob Bissonette");
            result.Yeux1.Should().Be(4);
        }

        [TestMethod]
        public async Task TestCreatePnj()
        {
            
            Campagne campagne = new Campagne() { };
            await PnjController.CreatePNJ(4,1,1,1,1,1,1,1,"Le tannant","Paul Gossant", await context.Campagnes.FindAsync(1));
            var result = (await PnjController.GetPnj(4)).Value;
            await context.Entry(result).ReloadAsync();
            result.Name.Should().Be("Paul Gossant");
            result.Yeux1.Should().Be(1);
        }

        [TestMethod]
        public async Task TestDeletePnj()
        {
            PnjController.DeletePNJ(2).Result.Should().Be(true);
            var result = PnjController.GetAllPNJ(null, null, 1).Result.Value?.ToList();
            result.Count().Should().Be(2);
        }

        [TestCleanup]
        public void Clean()
        {
            dbHelper.DropTablesClasses();
        }
    }
}
