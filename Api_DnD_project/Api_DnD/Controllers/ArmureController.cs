using Api_DnD.Data;
using Api_DnD.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Api_DnD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArmureController : Controller
    {
        private readonly DNDContext _context;

        public ArmureController(DNDContext context)
        {
            _context = context;
        }

        [HttpGet("/GetAllArmure")]
        public async Task<ActionResult<IEnumerable<Armure>>> GetArmure(string? sortOrder,string? recherche, int page)
        {
            if (!string.IsNullOrEmpty(recherche))
            {
                return await _context.Armures.Where(a => a.Name.Contains(recherche)).ToListAsync();
            }

            if (page <= 0)
                page = 1;

            switch (sortOrder)
            {
                case "nom":
                    return await _context.Armures.OrderBy(a => a.Name).Skip((3 * page) - 3).Take(3).ToListAsync();
                case "id":
                    return await _context.Armures.OrderBy(a => a.Id).Skip((3 * page) - 3).Take(3).ToListAsync();
                case "nom_desc":
                    return await _context.Armures.OrderByDescending(a => a.Name).Skip((3 * page) - 3).Take(3).ToListAsync();
                case "id_desc":
                    return await _context.Armures.OrderByDescending(a => a.Id).Skip((3 * page) - 3).Take(3).ToListAsync();
                case "dex":
                    return await _context.Armures.OrderBy(a => a.DexBonus).Skip((3 * page) - 3).Take(3).ToListAsync();
                case "ac":
                    return await _context.Armures.OrderBy(a => a.Ac).Skip((3 * page) - 3).Take(3).ToListAsync();
                case "dex_desc":
                    return await _context.Armures.OrderByDescending(a => a.DexBonus).Skip((3 * page) - 3).Take(3).ToListAsync();
                case "ac_desc":
                    return await _context.Armures.OrderByDescending(a => a.Ac).Skip((3 * page) - 3).Take(3).ToListAsync();
                default:
                    return await _context.Armures.ToListAsync();
            }
        }

        [HttpGet("/GetArmureById/{id}")]
        public async Task<ActionResult<Armure>> GetArmureById(int id)
        {
            return await _context.Armures.FindAsync(id);
        }

        [HttpPost("/CreateArmures/")]
        public async Task<ActionResult<Arme>> CreateArme(string name, string type, int ac, bool dexBonus, int maxDexBonus, int stealthDisadvantage, int EnchantementId)
        {
            Armure armureCree = new Armure { Name = name, Type = type, Ac = ac, DexBonus = dexBonus, MaxDexMod = maxDexBonus, StealthDisadvantage = stealthDisadvantage, EnchantementId = EnchantementId };

            _context.Armures.Add(armureCree);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArmureById", new { id = armureCree.Id }, armureCree);
        }

        [HttpPut("/EditArmure")]
        public async Task<ActionResult<Armure>> EditArmure(int Id, string name, string type, int ac, bool dexBonus, int maxDexBonus, int stealthDisadvantage, int EnchantementId)
        {
            await _context.Armures.Where(a => a.Id == Id).ExecuteUpdateAsync(setters => setters
            .SetProperty(a => a.Name, name)
            .SetProperty(a => a.Type, type)
            .SetProperty(a => a.Ac, ac)
            .SetProperty(a => a.DexBonus,dexBonus)
            .SetProperty(a => a.MaxDexMod,maxDexBonus)
            .SetProperty(a => a.StealthDisadvantage,stealthDisadvantage)
            .SetProperty(a => a.EnchantementId, EnchantementId));

            return NoContent();

        }

        // POST: ArmeController/Delete/5
        // Si une entrée est trouvée et supprimée, la valeur true est retournée, sinon c'est la valeur false
        [HttpDelete("/DeleteArmure/{id}")]
        public async Task<bool> DeleteArmure(int id)
        {
            if (await _context.Armures.Where(a => a.Id.Equals(id)).ExecuteDeleteAsync() == 1)
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
