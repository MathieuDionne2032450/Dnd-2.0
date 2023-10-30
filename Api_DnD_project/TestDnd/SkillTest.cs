using Api_DnD.Controllers;
using Api_DnD.Data;
using Api_DnD.Model;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDnd
{
    [TestClass]
    public class SkillTest
    {
        private DNDContext context;
        private SkillController skillController;
        private DatabaseHelper dbHelper;

        [TestInitialize]
        public void Initialize()
        {
            DatabaseHelper databaseHelper = new DatabaseHelper();
            context = databaseHelper.CreateContext();
            databaseHelper.CreateTablesSkill();
            skillController = new SkillController(context);
        }

        [TestMethod]
        public void TestGetAllSkills()
        {
            var result = skillController.GetSkill("nom_desc", "", 0).Result.Value?.ToList();
            result.Count().Should().Be(3);
            result[0].Nom.Should().Be("Force incroyable");
        }

        [TestMethod]
        public void TestGetSkill()
        {
            skillController.GetSkill(1).Result.Value.Nom.Should().Be("Skillz");
        }

        [TestMethod]
        public async Task TestEditSkill()
        {
            var result = (await skillController.GetSkill(3)).Value;
            await skillController.EditSkill(3, "Urticaire", "Atchoum");
            await context.Entry(result).ReloadAsync();
            result.Nom.Should().Be("Urticaire");
            result.Descr.Should().Be("Atchoum");
        }

        [TestMethod]
        public void TestCreateSkill()
        {
            skillController.CreateSkill("Intelligence effrayante", "Des excellentes capacités mentales");

            skillController.GetSkill(4).Result.Value.Nom.Should().Be("Intelligence effrayante");
        }

        [TestMethod]
        public void TestDeleteSkill()
        {
            skillController.DeleteSkill(3).Result.Should().Be(true);
        }

        [TestCleanup]
        public void DeleteDatabase()
        {
            context.Database.EnsureDeleted();
        }
    }
}
