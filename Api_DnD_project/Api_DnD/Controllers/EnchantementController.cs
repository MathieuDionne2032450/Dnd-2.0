using Api_DnD.Data;
using Api_DnD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public async Task<ActionResult<IEnumerable<Enchantement>>> GetEnchantement(string? sortOrder, string? recherche, int page)
        {
            if (!string.IsNullOrEmpty(recherche))
            {
                return await _context.Enchantements.Where(e => e.Nom.Contains(recherche)).ToListAsync();
            }

            if (page <= 0)
                page = 1;

            switch (sortOrder)
            {
                case "nom":
                    return await _context.Enchantements.OrderBy(e => e.Nom).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "id":
                    return await _context.Enchantements.OrderBy(e => e.Id).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "nom_desc":
                    return await _context.Enchantements.OrderByDescending(e => e.Nom).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "id_desc":
                    return await _context.Enchantements.OrderByDescending(e => e.Id).Skip((3 * page) - 3).Take(3).ToListAsync();
                
                case "modif":
                    return await _context.Enchantements.OrderBy(e => e.Modif).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "type":
                    return await _context.Enchantements.OrderBy(e => e.Type).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "modif_desc":
                    return await _context.Enchantements.OrderByDescending(e => e.Modif).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "type_desc":
                    return await _context.Enchantements.OrderByDescending(e => e.Type).Skip((3 * page) - 3).Take(3).ToListAsync();

                default:
                    return await _context.Enchantements.ToListAsync();

            }
        }

        [HttpGet("/GetEnchantement/{id}")]
        public async Task<ActionResult<Enchantement>> GetEnchantementById(int id)
        {
            var test = await _context.Enchantements.FindAsync(id);
            return test;
        }

        [HttpPut("/EditEnchantement")]
        public async Task<ActionResult<Enchantement>> EditEnchantement(int id, string? Nom, string? Description, string? Type, int Modif)
        {
            Enchantement? e = await _context.Enchantements.FindAsync(id);
            if (e != null)
            {
                if (string.IsNullOrEmpty(Nom))
                    Nom = e.Nom;

                if (string.IsNullOrEmpty(Description))
                    Description = e.Description;

                if (string.IsNullOrEmpty(Type))
                    Type = e.Type;

                await _context.Enchantements.Where(e => e.Id == id).ExecuteUpdateAsync(setters => setters
                .SetProperty(e => e.Nom,Nom)
                .SetProperty(e => e.Description, Description)
                .SetProperty(e => e.Type, Type)
                .SetProperty(e => e.Modif, Modif)
                );
                await _context.SaveChangesAsync();

            }

            return NoContent();
        }

        [HttpPost("/CreateEnchantement")]
        public async Task<ActionResult<Enchantement>> CreateEnchantement(string Nom, string Description, string Type, int Modif)
        {
            Enchantement enchantement = new Enchantement { Nom = Nom, Description = Description, Type = Type, Modif = Modif };
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
