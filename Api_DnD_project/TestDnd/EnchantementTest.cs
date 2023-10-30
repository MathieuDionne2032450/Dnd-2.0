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
            var result = enchantementController.GetEnchantement("type_desc", null, 1).Result.Value?.ToList();
            result.Count().Should().Be(3);
            result[0].Type.Should().Be("terre");

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

        [TestMethod]
        public async Task TestCreateEnchantement()
        {
            await enchantementController.CreateEnchantement("feu avec du bois", "feu avec des buches", "feu", 2);
            var result = (await enchantementController.GetEnchantementById(6)).Value;
            await context.Entry(result).ReloadAsync();
            result.Nom.Should().Be("feu avec du bois");
            result.Description.Should().Be("feu avec des buches");
        }

        [TestMethod]
        public async Task TestDeleteEnchantement()
        {
            enchantementController.DeleteEnchantement(5).Result.Should().Be(true);
        }

        [TestCleanup]
        public void Clean()
        {
            dbHelper.DropTablesEnchantement();
        }


    }
}