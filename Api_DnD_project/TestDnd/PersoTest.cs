//using Api_DnD.Data;
//using Api_DnD.Controllers;
//using FluentAssertions;
//using Api_DnD.Model;
//using Microsoft.AspNetCore.Mvc;
//using MySqlX.XDevAPI.Common;
//using System.Collections.Generic;

//namespace TestDnd
//{
//    [TestClass]
//    public class PersoTest
//    {
//        private DNDContext context;
//        private PersoController? persoController;
//        private DatabaseHelper dbHelper;

//        [TestInitialize]
//        public void Initialize()
//        {
//            DatabaseHelper databaseHelper = new DatabaseHelper();
//            context = databaseHelper.CreateContext();
//            databaseHelper.CreateTablesPerso();
//            persoController = new PersoController(context);
//        }

//        [TestMethod]
//        public async Task TestGetAll1()
//        {
//            persoController.GetAllPerso("id", null, null, 1).Result.Value.Count().Should().Be(3);
//            dbHelper.DropTablesPerso();
//        }

//        [TestMethod]
//        public async Task TestGetAll2()
//        {
//            persoController.GetAllPerso("id", null, null, 1).Result.Value.First().id.Should().Be(1);
//            dbHelper.DropTablesPerso();
//        }




//        [TestMethod]
//        public async Task TestGetbyid()
//        {
//            persoController.GetPersoById(1).Result.Value.Nom.Should().Be("Dreknethol");
//            persoController.GetPersoById(2).Result.Value.Armure.Type.Should().Be("très lourde");
//            dbHelper.DropTablesPerso();
//        }

//        [TestMethod]
//        public async Task TestEditPerso()
//        {   

//            persoController.GetPersoById(1).Result.Value.Nom.Should().Be("Dreknethol");
//            dbHelper.DropTablesPerso();
//        }


        
//    }
//}