using Api_DnD.Controllers;
using Api_DnD.Data;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDnd
{
    [TestClass]
    public class RaceTest
    {
        private DNDContext context;
        private RaceController raceController;
        private DatabaseHelper dbHelper;

        [TestInitialize]
        public void Initialize()
        {
            dbHelper = new DatabaseHelper();
            context = dbHelper.CreateContext();
            dbHelper.CreateTablesRace();
            raceController = new RaceController(context);
        }

        [TestMethod]
        public async Task TestGetAll()
        {
            var result =  raceController.GetRace("bonusPV", null,null,1).Result.Value?.ToList();
            result.Count().Should().Be(3);
            result[0].BonusPV.Should().Be(6);
        }

        [TestMethod]
        public async Task TestGetById()
        {
            var result = await raceController.GetRaceById(2);
            result.Value?.Nom.Should().Be("Elf");
        }

        [TestMethod]
        public async Task TestEditRace()
        {
            var result = (await raceController.GetRaceById(2)).Value;
            await raceController.EditRace(2, "lutin",null,null,null,null,null,null,null,null);
            await context.Entry(result).ReloadAsync();
            result.Nom.Should().Be("lutin");
            result.BonusPV.Should().NotBe(null);
        }

        [TestMethod]
        public async Task TestCreateRace()
        {
            raceController.CreateRace("Gnome", 4, 5, 6, 7, 8, 9, 10, 11);
            var result = (await raceController.GetRaceById(4)).Value;
            await context.Entry(result).ReloadAsync();
            result.Nom.Should().Be("Gnome");
            result.BonusPV.Should().Be(4);
        }

        [TestMethod]
        public async Task TestDeleteRace()
        {
            raceController.DeleteRace(3).Result.Should().Be(true);
            var result = raceController.GetRace("bonusPV", null, null, 1).Result.Value?.ToList();
            result.Count().Should().Be(2);
            
        }

        [TestCleanup]
        public void Clean()
        {
            dbHelper.DropTablesClasses();
        }
    }
}
