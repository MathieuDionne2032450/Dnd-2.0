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
            skillController.GetSkill("", "", 0).Result.Value.Count().Should().Be(3);
        }

        public void TestGetSkill()
        {
            skillController.GetSkill(1).Result.Value.Nom.Should().Be("Skillz");
        }
        public async Task<bool> AsyncEditSkill()
        {
            await skillController.EditSkill(1, "Urticaire", "Atchoum");

            return skillController.GetSkill(1).Result.Value.Nom.Equals("Urticaire");
        }

        [TestMethod]
        public void TestEditSkill()
        {
            AsyncEditSkill().Result.Should().Be(true);
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
            skillController.DeleteSkill(4);

            skillController.GetSkill(4).Result.Value.Should().Be(null);
        }

        [TestCleanup]
        public void DeleteDatabase()
        {
            context.Database.EnsureDeleted();
        }
    }
}
