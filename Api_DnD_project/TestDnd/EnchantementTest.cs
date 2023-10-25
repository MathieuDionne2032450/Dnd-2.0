using Api_DnD.Data;
using Api_DnD.Controllers;
using FluentAssertions;
using Api_DnD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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
            dbHelper = new DatabaseHelper();
            context = dbHelper.CreateContext();
            dbHelper.CreateTablesEnchantement();
            enchantementController = new EnchantementController(context);
        }

        [TestMethod]
        public void TestGetAll()
        {
            enchantementController.GetEnchantement("nom", null, 1).Result.Value?.Count().Should().Be(3);

        }

        [TestMethod]
        public void TestGetById()
        {
            enchantementController.GetEnchantementById(2).Result.Value?.Nom.Should().Be("feu");
        }


        public async void TestEditEnchantement()
        {
            await enchantementController.EditEnchantement(2, "feu de camp", null, null, 2);
            enchantementController.GetEnchantementById(2).Result.Value?.Nom.Should().Be("feu de camp");
            enchantementController.GetEnchantementById(2).Result.Value?.Description.Should().NotBe(null);
            dbHelper.DropTablesEnchantement();
        }

        [TestMethod]
        public void testEdit()
        {
            //TestEditEnchantement().Should().Be(true);

        }

        [TestMethod]
        public async void TestCreateEnchantement()
        {
            enchantementController.CreateEnchantement("feu avec du bois", "feu avec des buches", "feu", 2).Result.Value?.Nom.Should().Be("feu avec du bois"); ;

            dbHelper.DropTablesEnchantement();
        }


    }
}