using Api_DnD.Data;
using Api_DnD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Api_DnD.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public class MonstreController : Controller
    {
        
        private readonly DNDContext _context;

        public MonstreController(DNDContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Monstre>>> GetMonstres()
        {
            return await _context.Monstres
                .Include(m => m.Campagne)
                .Include(m => m.Actions)
                .OrderBy(m => m.Nom)
                .ToListAsync();
        }

        [HttpGet("/GetMonstreById/{id}")]
        public async Task<ActionResult<Monstre?>> GetMonstre(int id)
        {
            return await _context.Monstres.FindAsync(id);
        }

        
        [HttpPut("/EditMonstre")] 
        public async Task<ActionResult<Monstre>> EditMonstre(int id, Monstre monstre)
        {
            await _context.Monstres.Where(m => m.Id == id).ExecuteUpdateAsync(setters => setters
            .SetProperty(m => m.Nom, monstre.Nom)
            .SetProperty(m => m.Size, monstre.Size)
            .SetProperty(m => m.ArmorClass, monstre.ArmorClass)
            .SetProperty(m => m.HitPoint, monstre.HitPoint)
            .SetProperty(m => m.Speed, monstre.Speed)
            .SetProperty(m => m.FlySpeed, monstre.FlySpeed)
            .SetProperty(m => m.ClimbSpeed, monstre.ClimbSpeed)
            .SetProperty(m => m.Str, monstre.Str)
            .SetProperty(m => m.Dex, monstre.Dex)
            .SetProperty(m => m.Con, monstre.Con)
            .SetProperty(m => m.Intel, monstre.Intel)
            .SetProperty(m => m.Wis, monstre.Wis)
            .SetProperty(m => m.Cha, monstre.Cha)
            .SetProperty(m => m.DarkVision, monstre.DarkVision)
            .SetProperty(m => m.Challenge, monstre.Challenge)
            .SetProperty(m => m.Lang, monstre.Lang)
            .SetProperty(m => m.DammageResistance, monstre.DammageResistance)
            .SetProperty(m => m.DammageImmunities, monstre.DammageImmunities)
            .SetProperty(m => m.Actions, monstre.Actions)
            .SetProperty(m => m.Campagne, monstre.Campagne)
            );

            return NoContent();
        }
        

        [HttpPost("/CreateMonstre")]
        public async Task<ActionResult<Monstre>> CreateMonstre(Monstre monstre)
        {
            _context.Monstres.Add(monstre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMonstre", new { id = monstre.Id }, monstre);
        }

        [HttpDelete("/DeleteMonstre/{id}")]
        public async Task<bool> DeleteMonstre(int id)
        {
            if(await _context.Monstres.Where(m => m.Id.Equals(id)).ExecuteDeleteAsync() == 1)
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
