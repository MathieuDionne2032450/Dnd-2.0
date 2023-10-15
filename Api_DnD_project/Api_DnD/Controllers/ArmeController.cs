using Api_DnD.Data;
using Api_DnD.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_DnD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArmeController : Controller
    {

        private readonly DNDContext _context;

        public ArmeController(DNDContext context)
        {
            _context = context;
        }

        [HttpGet("/GetAllArme")]
        public async Task<ActionResult<IEnumerable<Arme>>> GetArme(string sortOrder)
        {
            switch (sortOrder)
            {
                case "nom":
                   return await _context.Armes.OrderBy(a => a.Nom).ToListAsync();
                    break;
                case "id":
                    return await _context.Armes.OrderBy(a => a.id).ToListAsync();
                    break;
                case "nom_desc":
                    return await _context.Armes.OrderByDescending(a => a.Nom).ToListAsync();
                    break;
                case "id_desc":
                    return await _context.Armes.OrderByDescending(a => a.id).ToListAsync();
                    break;
                case "jet":
                    return await _context.Armes.OrderBy(a => a.BonusJet).ToListAsync();
                    break;
                case "force":
                    return await _context.Armes.OrderBy(a => a.BonusForce).ToListAsync();
                    break;
                case "jet_desc":
                    return await _context.Armes.OrderByDescending(a => a.BonusJet).ToListAsync();
                    break;
                case "force_desc":
                    return await _context.Armes.OrderByDescending(a => a.BonusForce).ToListAsync();
                    break;
                default:
                    return await _context.Armes.ToListAsync();
            }
        }

        [HttpGet("/GetArme/{id}")]
        public async Task<ActionResult<Arme>> GetArme(int id)
        {
            return await _context.Armes.FindAsync(id);
        }

        [HttpGet("/BaseArme/{id}")]
        public async Task<ActionResult<ArmeDTO>> GetBaseInfoArme(int id)
        {
            var arme = await _context.Armes.FindAsync(id);

            if(arme == null)
            {
                return NotFound();
            }

            return ArmeDTO.ArmeToDTO(arme);
        }

        [HttpPut("/EditArme")]
        public async Task<ActionResult<Arme>> EditArme(int Id, int bonusJet, int bonusForce, string nom, int enchantementId)
        {
            await _context.Armes.Where(a => a.id == Id).ExecuteUpdateAsync(setters => setters
            .SetProperty(a => a.BonusJet, bonusJet)
            .SetProperty(a => a.BonusForce, bonusForce)
            .SetProperty(a => a.Nom, nom)
            .SetProperty(a => a.EnchantementId, enchantementId));

            return NoContent();
        }

        [HttpPost("/CreateArme")]
        public async Task<ActionResult<Arme>> CreateArme(int bonusJet, int bonusForce, string nom, int enchantementId)
        {
            Arme armeCree = new Arme { BonusJet = bonusJet, BonusForce = bonusForce, Nom = nom, EnchantementId = enchantementId};

            _context.Armes.Add(armeCree);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArme", new {id = armeCree.id}, armeCree);
        }

        // POST: ArmeController/Delete/5
        // Si une entrée est trouvée et supprimée, la valeur true est retournée, sinon c'est la valeur false
        [HttpDelete("/DeleteArme/{id}")]
        public async Task<bool> DeleteArme(int id)
        {
            if (await _context.Armes.Where(a => a.id.Equals(id)).ExecuteDeleteAsync() == 1)
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
