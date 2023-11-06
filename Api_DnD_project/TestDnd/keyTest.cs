using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api_DnD.Controllers;
using Api_DnD.Data;
using FluentAssertions;

namespace TestDnd
{
    [TestClass]
    public class keyTest
    {
        private DNDContext context;
        private KeyGenerator KeyController;
        private DatabaseHelper dbHelper;

        [TestInitialize]
        public void Initialize()
        {
            dbHelper = new DatabaseHelper();
            context = dbHelper.CreateContext();
            dbHelper.CreateTablesKey();
            KeyController = new KeyGenerator(context);
        }

        [TestMethod]
        public async Task TestGenerate()
        {
            var result = KeyController.GenererUniqueKey().Result;
            result.ApiKey.Length.Should().Be(32);
            result.Role.Should().Be("USER_ROLE");
        }

        [TestMethod]
        public async Task TestVerif()
        {
            KeyController.VerifKey("l7HSOFQWbyj35OCjmbR8FgF59z3WKGgq").Result.Should().Be("USER_ROLE");

        }

        [TestCleanup]
        public void DeleteDatabase()
        {
            context.Database.EnsureDeleted();
        }
    }
}
