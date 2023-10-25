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
        public void TestGetAll()
        {
            armureController.GetArmure(string.Empty, string.Empty, 1).Result.Value?.Count().Should().Be(3);
        }

        [TestMethod]
        public void TestGetById()
        {
            armureController.GetArmureById(2).Result.Value.Name.Should().Be("Bottes");
        }

        [TestCleanup]
        public void DeleteDatabase()
        {
            context.Database.EnsureDeleted();
        }
    }
}
