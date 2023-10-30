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
        public async Task TestGetAllClasses()
        {
            var result = classesController.GetClasses("nom", null, 1).Result.Value?.ToList();
            result.Count().Should().Be(3);
            result[0].name.Should().Be("Archer");

        }

        [TestMethod]
        public async Task TestGetClassesRecherche()
        {
            var result = classesController.GetClasses("nom", "mag", 1).Result.Value?.ToList();
            result.Count().Should().Be(1);
            result[0].name.Should().Be("magicien");

        }

        [TestMethod]
        public async Task TestGetById()
        {
            var result = await classesController.GetClassesById(2);
            result.Value?.name.Should().Be("Archer");
        }

        [TestMethod]
        public async Task TestEditClasses()
        {
            var result = (await classesController.GetClassesById(2)).Value;
            await classesController.EditClasses(2,"Ninja","discret",null,"discret");
            await context.Entry(result).ReloadAsync();
            result.name.Should().Be("Ninja");
            result.hitDie.Should().NotBe(null);
        }

        [TestMethod]
        public async Task TestCreateClasses()
        {
            await classesController.CreateClasses("Guerrier dragon","Panda","test4","Pas besoin de primary ability");
            var result = (await classesController.GetClassesById(4)).Value;
            await context.Entry(result).ReloadAsync();
            result.name.Should().Be("Guerrier dragon");
            result.description.Should().Be("Panda");
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
