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
    public class ArmureTest
    {
        private DNDContext context;
        private ArmureController armureController;
        private DatabaseHelper dbHelper;

        [TestInitialize]
        public void Initialize()
        {
            dbHelper = new DatabaseHelper();
            context = dbHelper.CreateContext();
            dbHelper.CreateTablesArmure();
            armureController = new ArmureController(context);
        }

        [TestMethod]
        public void TestGetAllArmure()
        {
            var result = armureController.GetArmure("ac_desc",string.Empty, 1).Result.Value?.ToList();
            result.Count().Should().Be(3);
            result[0].Ac.Should().Be(3);
        }

        [TestMethod]
        public void TestGetArmureRecherche()
        {
            var result = armureController.GetArmure("ac_desc","as", 1).Result.Value?.ToList();
            result.Count().Should().Be(2);
            result[0].Name.Should().Be("Plastron");
        }

        [TestMethod]
        public void TestGetById()
        {
            armureController.GetArmureById(2).Result.Value.Name.Should().Be("Bottes");
        }

        [TestMethod]
        public async Task TestEditArmure()
        {
            var result = (await armureController.GetArmureById(2)).Value;
            await armureController.EditArmure(2,"Plastron en diamant", "Minecraft",1,false,4,4,0);
            await context.Entry(result).ReloadAsync();
            result.Name.Should().Be("Plastron en diamant");
            result.EnchantementId.Should().Be(1);
        }

        [TestMethod]
        public async Task TestCreateArmure()
        {
            await armureController.CreateArmure("Jambiere","Minecraft",2,true,2,2,1);
            var result = (await armureController.GetArmureById(4)).Value;
            await context.Entry(result).ReloadAsync();
            result.Name.Should().Be("Jambiere");
            result.Type.Should().Be("Minecraft");

        }

        [TestMethod]
        public async Task TestDeleteArme()
        {
            await armureController.DeleteArmure(3);

            context.SaveChanges();

            armureController.GetArmure(string.Empty, string.Empty, 1).Result.Value?.Count().Should().Be(2);

        }

        [TestCleanup]
        public void DeleteDatabase()
        {
            context.Database.EnsureDeleted();
        }
    }
}
