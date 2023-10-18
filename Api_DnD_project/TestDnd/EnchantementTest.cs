using Api_DnD.Data;
using Api_DnD.Controllers;
using FluentAssertions;

namespace TestDnd
{
    [TestClass]
    public class EnchantementTest
    {
        private DNDContext context;
        private EnchantementController enchantementController;
        private DatabaseHelper dbHelper;

        [TestInitialize]
        public void Initialize()
        {
            DatabaseHelper databaseHelper = new DatabaseHelper();
            context = databaseHelper.CreateContext();
            databaseHelper.CreateTablesEnchantement();
            enchantementController = new EnchantementController(context);
        }

        [TestMethod]
        public void TestGetAll()
        {
            enchantementController.GetEnchantement("nom",null,1).Result.Value.Count().Should().Be(3);
            
        }
    }
}