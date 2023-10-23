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
            skillController.GetSkill("nom", string.Empty, 3).Result.Value.Count().Should().Be(3);
        }

        [TestMethod]
        public void TestGetSkill()
        {
            skillController.GetSkill(1).Result.Value.Nom.Should().Be("Skillz");
        }

        [TestMethod]
        public void TestEditSkill()
        {
            skillController.EditSkill(1, "Urticaire", "Atchoum");

            skillController.GetSkill(1).Result.Value.Nom.Should().Be("Urticaire");

            dbHelper.DropTables();
        }

        [TestMethod]
        public void TestCreateSkill()
        {
            skillController.CreateSkill("Intelligence effrayante", "Des excellentes capacités mentales");

            skillController.GetSkill(4).Result.Value.Nom.Should().Be("Intelligence effrayante");

            skillController.DeleteSkill(4);
        }

        [TestMethod]
        public void TestDeleteSkill()
        {
            skillController.CreateSkill("Intelligence effrayante", "Des excellentes capacités mentales");

            skillController.DeleteSkill(4);

            skillController.GetSkill(4).Result.Value.Should().Be(null);
        }
    }
}
