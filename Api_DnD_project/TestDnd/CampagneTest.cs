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
        public void TestGetById()
        {
            campagneController.GetCampagneById(2).Result.Value.Name.Should().Be("L'autre campagne");
        }

        [TestCleanup]
        public void DeleteDatabase()
        {
            context.Database.EnsureDeleted();
        }
    }
}
