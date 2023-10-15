using Api_DnD.Data;
using Api_DnD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;

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
        public async Task<ActionResult<IEnumerable<Monstre>>> GetMonstres(string? sortOrder, string? recherche, int page)
        {
            if (!string.IsNullOrEmpty(recherche))
            {
                return await _context.Monstres.Where(m => m.Nom.Contains(recherche)).ToListAsync();
            }

            if (page <= 0)
                page = 1;

            switch (sortOrder)
            {
                case "nom":
                    return await _context.Monstres.OrderBy(m => m.Nom).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "id":
                    return await _context.Monstres.OrderBy(m => m.Id).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "nom_desc":
                    return await _context.Monstres.OrderByDescending(m => m.Nom).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "id_desc":
                    return await _context.Monstres.OrderByDescending(m => m.Id).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "amure":
                    return await _context.Monstres.OrderBy(m => m.ArmorClass).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "challenge":
                    return await _context.Monstres.OrderBy(m => m.Challenge).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "armure_desc":
                    return await _context.Monstres.OrderByDescending(m => m.ArmorClass).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "challenge_desc":
                    return await _context.Monstres.OrderByDescending(m => m.Challenge).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "wisdom":
                    return await _context.Monstres.OrderBy(m => m.Wis).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "charisma":
                    return await _context.Monstres.OrderBy(m => m.Cha).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "wisdom_desc":
                    return await _context.Monstres.OrderByDescending(m => m.Wis).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "charisma_desc":
                    return await _context.Monstres.OrderByDescending(m => m.Cha).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "dammageResistance":
                    return await _context.Monstres.OrderBy(m => m.DammageResistance).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "dex":
                    return await _context.Monstres.OrderBy(m => m.Dex).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "dammageResistance_desc":
                    return await _context.Monstres.OrderByDescending(m => m.DammageResistance).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "dex_desc":
                    return await _context.Monstres.OrderByDescending(m => m.Dex).Skip((3 * page) - 3).Take(3).ToListAsync();
                case "flySpeed":
                    return await _context.Monstres.OrderBy(m => m.FlySpeed).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "hitPoint":
                    return await _context.Monstres.OrderBy(m => m.HitPoint).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "flySpeed_desc":
                    return await _context.Monstres.OrderByDescending(m => m.FlySpeed).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "hitPoint_desc":
                    return await _context.Monstres.OrderByDescending(m => m.HitPoint).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "speed":
                    return await _context.Monstres.OrderBy(m => m.Speed).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "strenght":
                    return await _context.Monstres.OrderBy(m => m.Str).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "speed_desc":
                    return await _context.Monstres.OrderByDescending(m => m.Speed).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "strenght_desc":
                    return await _context.Monstres.OrderByDescending(m => m.Str).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "size":
                    return await _context.Monstres.OrderBy(m => m.Size).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "intelligence":
                    return await _context.Monstres.OrderBy(m => m.Intel).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "size_desc":
                    return await _context.Monstres.OrderByDescending(m => m.Speed).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "intelligence_desc":
                    return await _context.Monstres.OrderByDescending(m => m.Intel).Skip((3 * page) - 3).Take(3).ToListAsync();
                default:
                    return await _context.Monstres.ToListAsync();
            }
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
