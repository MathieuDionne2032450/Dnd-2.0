using Api_DnD.Data;
using Api_DnD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_DnD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CampagneController : Controller
    {

        private readonly DNDContext _context;

        public CampagneController(DNDContext context)
        {
            _context = context;
        }


        //[HttpGet("/GetCampagneById/{id}")]
        //public async Task<ActionResult<Armure>> GetCampagneById(int id)
        //{
        //    return await _context.Armures.FindAsync(id);
        //}

        //[HttpPost("/CreateCampagne/")]
        //public async Task<ActionResult<Arme>> CreateCampagne(string name, string type, int ac, bool dexBonus, int maxDexBonus, int stealthDisadvantage, int EnchantementId)
        //{
        //    Armure armureCree = new Armure { Name = name, Type = type, Ac = ac, DexBonus = dexBonus, MaxDexMod = maxDexBonus, StealthDisadvantage = stealthDisadvantage, EnchantementId = EnchantementId };

        //    _context.Armures.Add(armureCree);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetArmureById", new { id = armureCree.Id }, armureCree);
        //}

        [HttpPut("/EditCampagne")]
        public async Task<ActionResult<Campagne>> EditCampagne(int Id, string Name, string Desc)
        {

            await _context.Campagnes.Where(c => c.Id == Id).ExecuteUpdateAsync(setters => setters
            .SetProperty(c => c.Name, Name)
            .SetProperty(c => c.Desc, Desc));

            return NoContent();

        }

        // POST: ArmeController/Delete/5
        // Si une entrée est trouvée et supprimée, la valeur true est retournée, sinon c'est la valeur false
        [HttpDelete("/DeleteCampagne/{id}")]
        public async Task<bool> DeleteCampagne(int id)
        {
            if (await _context.Campagnes.Where(c => c.Id.Equals(id)).ExecuteDeleteAsync() == 1)
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
