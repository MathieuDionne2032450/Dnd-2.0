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
    public class ClassesTest
    {
        private DNDContext context;
        private ClassesController classesController;
        private DatabaseHelper dbHelper;

        [TestInitialize]
        public void Initialize()
        {
            dbHelper = new DatabaseHelper();
            context = dbHelper.CreateContext();
            dbHelper.CreateTablesClasses();
            classesController = new ClassesController(context);
        }

        [TestMethod]
        public async Task TestGetAll()
        {
            var result = await classesController.GetClasses("nom", null, 1);
            result.Value?.Count().Should().Be(3);

        }

        [TestMethod]
        public async Task TestGetById()
        {
            var result = await classesController.GetClassesById(2);
            result.Value?.name.Should().Be("Elf");
        }

        [TestMethod]
        public async Task TestEditClasses()
        {
            var result = (await classesController.GetClassesById(2)).Value;
            await classesController.EditClasses(2,"lutin","esclave du pere noel",null,"Connait le pere noel");
            await context.Entry(result).ReloadAsync();
            result.name.Should().Be("lutin");
            result.hitDie.Should().NotBe(null);
        }

        [TestMethod]
        public async Task TestCreateClasses()
        {
            await classesController.CreateClasses("Orc","monstre","test4","mechant dans seigneur des anneaux");
            var result = (await classesController.GetClassesById(4)).Value;
            await context.Entry(result).ReloadAsync();
            result.name.Should().Be("Orc");
            result.description.Should().Be("monstre");
        }

        [TestMethod]
        public async Task TestDeleteClasses()
        {
            classesController.DeleteClasses(3).Result.Should().Be(true);
        }

        [TestCleanup]
        public void Clean()
        {
            dbHelper.DropTablesClasses();
        }
    }
}
