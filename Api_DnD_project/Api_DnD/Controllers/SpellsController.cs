using Api_DnD.Data;
using Api_DnD.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_DnD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpellsController : ControllerBase
    {
        private readonly DNDContext _context;
        public SpellsController(DNDContext context)
        {
            _context = context;
        }

        [HttpGet("/GetAllSpells")]
        public async Task<ActionResult<IEnumerable<Spell>>> GetArme(string? sortOrder, string? recherche, int page)
        {
            if (!string.IsNullOrEmpty(recherche))
            {
                return await _context.Spells.Where(s => s.Name.Contains(recherche)).ToListAsync();
            }

            if (page <= 0)
                page = 1;

            switch (sortOrder)
            {
                case "nom":
                    return await _context.Spells.OrderBy(s => s.Name).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "id":
                    return await _context.Spells.OrderBy(s => s.id).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "nom_desc":
                    return await _context.Spells.OrderByDescending(s => s.Name).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "id_desc":
                    return await _context.Spells.OrderByDescending(s => s.id).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "dammage":
                    return await _context.Spells.OrderBy(s => s.Dammage).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "dammageType":
                    return await _context.Spells.OrderBy(s => s.DammageType).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "dammage_desc":
                    return await _context.Spells.OrderByDescending(s => s.Dammage).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "damageType_desc":
                    return await _context.Spells.OrderByDescending(s => s.DammageType).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "zone":
                    return await _context.Spells.OrderBy(s => s.Zone).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "zone_desc":
                    return await _context.Spells.OrderByDescending(s => s.Zone).Skip((3 * page) - 3).Take(3).ToListAsync();

                default:
                    return await _context.Spells.ToListAsync();
            }
        }

        [HttpGet("/GetSpell/{id}")]
        public async Task<ActionResult<Spell>> GetArme(int id)
        {
            return await _context.Spells.FindAsync(id);
        }

        [HttpPut("/EditSpell")]
        public async Task<ActionResult<Spell>> EditArme(int id, string name, string description, string dammageType, int dammage,int classId, string zone)
        {
            Spell s = await _context.Spells.FindAsync(id);
            if (s != null)
            {
                if (string.IsNullOrEmpty(name))
                    name = s.Name;

                if (string.IsNullOrEmpty(description))
                    description = s.Description;

                if (string.IsNullOrEmpty(dammageType))
                    dammageType = s.DammageType;

                if (string.IsNullOrEmpty(zone))
                    zone = s.Zone;

                if (classId == 0)
                    classId = s.ClassId;

                await _context.Spells.Where(s => s.id == id).ExecuteUpdateAsync(setters => setters
                .SetProperty(s => s.Name, name)
                .SetProperty(s => s.Description, description)
                .SetProperty(s => s.DammageType, dammageType)
                .SetProperty(s => s.Dammage, dammage)
                .SetProperty(s => s.ClassId, classId)
                .SetProperty(s => s.Zone, zone));
                _context.SaveChanges();
            }
            return NoContent();
        }

        [HttpPost("/CreateSpell")]
        public async Task<ActionResult<Arme>> CreateArme(int id, string name, string description, string dammageType, int dammage, int classId, string zone)
        {
            Spell spellCree = new Spell(id,name,description,dammageType,dammage,classId,zone);

            _context.Spells.Add(spellCree);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: ArmeController/Delete/5
        // Si une entrée est trouvée et supprimée, la valeur true est retournée, sinon c'est la valeur false
        [HttpDelete("/DeleteSpell/{id}")]
        public async Task<bool> DeleteArme(int id)
        {
            if (await _context.Spells.Where(s => s.id.Equals(id)).ExecuteDeleteAsync() == 1)
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
