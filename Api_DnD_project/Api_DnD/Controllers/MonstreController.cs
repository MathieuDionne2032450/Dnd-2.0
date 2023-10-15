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
        public async Task<ActionResult<Monstre>> EditMonstre(int id, string? nom, string? size, int armorClass, int hitPoint, int speed, int flySpeed, int climbSpeed, int str, int dex, int con, int intel, int wis, int cha, int darkVision, float challenge, string? lang, string? dammageResistance, string? dammageImmunities, string? conditionImmunities)
        {
            Monstre m = await _context.Monstres.FindAsync(id);

            if (string.IsNullOrEmpty(nom))
                nom = m.Nom;

            if (string.IsNullOrEmpty(size))
                size = m.Size;

            if (armorClass == 0)
                armorClass = m.ArmorClass;

            if (hitPoint == 0)
                hitPoint = m.HitPoint;

            if (speed == 0)
                speed = m.Speed;

            if (string.IsNullOrEmpty(lang))
                lang = m.Lang;

            if (string.IsNullOrEmpty(dammageResistance))
                dammageResistance = m.DammageResistance;

            if (string.IsNullOrEmpty(dammageImmunities))
                dammageImmunities = m.DammageImmunities;

            if (string.IsNullOrEmpty(conditionImmunities))
                conditionImmunities = m.ConditionImmunities;
            


            await _context.Monstres.Where(m => m.Id == id).ExecuteUpdateAsync(setters => setters
            .SetProperty(m => m.Nom, nom)
            .SetProperty(m => m.Size, size)
            .SetProperty(m => m.ArmorClass, armorClass)
            .SetProperty(m => m.HitPoint, hitPoint)
            .SetProperty(m => m.Speed, speed)
            .SetProperty(m => m.FlySpeed, flySpeed)
            .SetProperty(m => m.ClimbSpeed, climbSpeed)
            .SetProperty(m => m.Str, str)
            .SetProperty(m => m.Dex, dex)
            .SetProperty(m => m.Con, con)
            .SetProperty(m => m.Intel, intel)
            .SetProperty(m => m.Wis, wis)
            .SetProperty(m => m.Cha, cha)
            .SetProperty(m => m.DarkVision, darkVision)
            .SetProperty(m => m.Challenge, challenge)
            .SetProperty(m => m.Lang, lang)
            .SetProperty(m => m.DammageResistance, dammageResistance)
            .SetProperty(m => m.DammageImmunities, dammageImmunities)
            .SetProperty(m => m.ConditionImmunities, conditionImmunities)
            );
            return NoContent();
        }
        

        [HttpPost("/CreateMonstre")]
        public async Task<ActionResult<Monstre>> CreateMonstre(string nom, string size, int armorClass, int hitPoint, int speed, int flySpeed, int climbSpeed, int str, int dex, int con, int intel, int wis, int cha, int darkVision, float challenge, string lang, string? dammageResistance, string? dammageImmunities, string? conditionImmunities)
        {
            Monstre m = new Monstre(nom, size, armorClass, hitPoint, speed, flySpeed, climbSpeed, str, dex, con, intel, wis, cha, darkVision, challenge, lang, dammageResistance, dammageImmunities, conditionImmunities);

            _context.Monstres.Add(m);
            await _context.SaveChangesAsync();

            return NoContent();
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
