using Api_DnD.Data;
using Api_DnD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_DnD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnchantementController : Controller
    {
        private readonly DNDContext _context;

        public EnchantementController(DNDContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enchantement>>> GetEnchantement()
        {
            return await _context.Enchantements.Include(e => e.Campagne)
                .OrderBy(e => e.Nom)
                .ToListAsync();
        }

        [HttpGet("/GetEnchantement/{id}")]
        public async Task<ActionResult<Enchantement>> GetArme(int id)
        {
            return await _context.Enchantements.FindAsync(id);
        }

        [HttpPut("/EditEnchantement")]
        public async Task<ActionResult<Enchantement>> EditEnchantement(int id, Enchantement enchantement)
        {
            await _context.Enchantements.Where(e => e.Id == id).ExecuteUpdateAsync(setters => setters
            .SetProperty(e => e.Nom, enchantement.Nom)
            .SetProperty(e => e.Description, enchantement.Description)
            .SetProperty(e => e.Type, enchantement.Type)
            .SetProperty(e => e.Modif, enchantement.Modif)
            .SetProperty(e => e.Campagne, enchantement.Campagne)
            );

            return NoContent();
        }

        [HttpPost("/CreateEnchantement")]
        public async Task<ActionResult<Enchantement>> CreateEnchantement(Enchantement enchantement)
        {
            _context.Enchantements.Add(enchantement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnchantement", new { id = enchantement.Id }, enchantement);
        }

        [HttpDelete("/DeleteEnchantement/{id}")]
        public async Task<bool> DeleteEnchantement(int id)
        {
            if(await _context.Enchantements.Where(e => e.Id.Equals(id)).ExecuteDeleteAsync() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
