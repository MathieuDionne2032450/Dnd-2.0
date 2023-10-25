using Api_DnD.Data;
using Api_DnD.Controllers;
using FluentAssertions;
using Api_DnD.Model;

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
        public void TestGetAll()
        {
            persoController.GetAllPerso("id", null, null, 1).Result.Value.Count().Should().Be(3);
            persoController.GetAllPerso("id", null, null, 1).Result.Value.First().id.Should().Be(1);
        }
    }
}