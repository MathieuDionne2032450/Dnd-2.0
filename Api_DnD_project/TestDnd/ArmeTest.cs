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
            armeController.GetArme(2).Result.Value.Nom.Should().Be("épée");
        }

        [TestCleanup]
        public void DeleteDatabase()
        {
            context.Database.EnsureDeleted();
        }
    }
}
