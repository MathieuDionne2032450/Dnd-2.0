using Api_DnD.Data;
using Api_DnD.Controllers;
using FluentAssertions;
using Api_DnD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;

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
        public async Task TestGetAll()
        {
            var result = await enchantementController.GetEnchantement("nom", null, 1);
            result.Value?.Count().Should().Be(3);

        }

        [TestMethod]
        public async Task TestGetById()
        {
            var result = await enchantementController.GetEnchantementById(2);
            result.Value?.Nom.Should().Be("feu");
        }

        [TestMethod]
        public async Task TestEditEnchantement()
        {
            var result = (await enchantementController.GetEnchantementById(2)).Value;
            await enchantementController.EditEnchantement(2, "feu de camp", null, null, 2);
            await context.Entry(result).ReloadAsync();
            result.Nom.Should().Be("feu de camp");
            result.Description.Should().NotBe(null);
        }

        //[TestMethod]
        //public async void TestCreateEnchantement()
        //{
        //    enchantementController.CreateEnchantement("feu avec du bois", "feu avec des buches", "feu", 2).Result.Value?.Nom.Should().Be("feu avec du bois"); ;

        //    dbHelper.DropTablesEnchantement();
        //}

        [TestCleanup]
        public void Clean()
        {
            dbHelper.DropTablesEnchantement();
        }


    }
}