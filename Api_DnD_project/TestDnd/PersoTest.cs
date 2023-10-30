using Api_DnD.Data;
using Api_DnD.Controllers;
using FluentAssertions;
using Api_DnD.Model;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using System.Collections.Generic;

namespace TestDnd
{
    [TestClass]
    public class PersoTest
    {
        private DNDContext context;
        private PersoController? persoController;
        private DatabaseHelper dbHelper;

        [TestInitialize]
        public void Initialize()
        {
            DatabaseHelper databaseHelper = new DatabaseHelper();
            context = databaseHelper.CreateContext();
            databaseHelper.CreateTablesPerso();
            persoController = new PersoController(context);
        }

        [TestMethod]
        public async Task TestGetAll1()
        {
            var result = persoController.GetAllPerso("irlJoueur_desc", null, null, 1).Result.Value?.ToList();
            result.Count().Should().Be(3);
            result[0].IrlJoueur.Should().Be("Mathieu");
        }

        [TestMethod]
        public async Task TestGetPersoRecherche()
        {
            var result = persoController.GetAllPerso("irlJoueur_desc", "Dreknethol",null, 1).Result.Value?.ToList();
            result.Count().Should().Be(1);
            result[0].Nom.Should().Be("Dreknethol");
        }

        [TestMethod]
        public async Task TestGetPersoRechercheCampagne()
        {
            var result = persoController.GetAllPerso("inspiration_desc", null, "La campagne", 1).Result.Value?.ToList();
            result.Count().Should().Be(4);
            result[0].Nom.Should().Be("Krados");
        }

        [TestMethod]
        public async Task TestGetAll2()
        {
            persoController.GetAllPerso("id", null, null, 1).Result.Value.First().id.Should().Be(1);
        }




        [TestMethod]
        public async Task TestGetbyid()
        {
            persoController.GetPersoById(2).Result.Value.Nom.Should().Be("Dreknethol");
            persoController.GetPersoById(2).Result.Value.Armure.Type.Should().Be("Forte");
        }

        [TestMethod]
        public async Task TestEditPerso()
        {
            var result = (await persoController.GetPersoById(2)).Value;
            await persoController.EditPerso(
                2,
                "Damn Daniel",
                "Daniel",
                "Vans blanches",
                1,
                1,
                1,
                1,
                "Damn Daniel",
                "Daaaamn",
                "Daaamn",
                "Daaamn",
                1,
                1);
            await context.Entry(result).ReloadAsync();
            result.Nom.Should().Be("Daniel");
            result.Description.Should().Be("Vans blanches");
        }

        [TestMethod]
        public async Task TestCreatePerso()
        {
            await persoController.CreatePerso("Balzac","Ballsack","Écrivain français",1,1,1,1,"Écrit beaucoup","Écrire un roman","Gustave Flaubert","Gros",1,1);
            
            
            var result = persoController.GetPersoById(5).Result.Value;
            await context.Entry(result).ReloadAsync();
            result.Nom.Should().Be("Ballsack");
        }

        [TestCleanup]
        public void DeleteDatabase()
        {
            context.Database.EnsureDeleted();
        }

    }
}