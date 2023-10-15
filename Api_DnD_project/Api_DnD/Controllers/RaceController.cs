using Api_DnD.Data;
using Api_DnD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_DnD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceController : ControllerBase
    {
        private readonly DNDContext _context;

        public RaceController(DNDContext context)
        {
            _context = context;
        }

        // GET: api/<RaceController>
        [HttpGet("GetAllRace")]
        public async Task<ActionResult<IEnumerable<Race>>> GetRace()
        {
            return await _context.Races.OrderBy(r => r.Nom).ToListAsync();
        }

        // GET api/<RaceController>/5
        [HttpGet("RaceById")]
        public async Task<ActionResult<Race>> Get(int id)
        {
            return await _context.Races.FindAsync(id);
        }

        // POST api/<RaceController>
        [HttpPut("EditRace")]
        public async Task<ActionResult<Race>> PutRace(int id, string? nom, int? bonusPv, int? bonusDex, int? bonusForce, int? bonusIntel, int? bonusWisdom, int? bonusConsti, int? bonusCharisma,int? campagne)
        {
            Race raceTempo = await _context.Races.FindAsync(id);
            //Campagne camp = await _context.Campagnes.FindAsync(campagneid);
            //raceTempo.Campagnes.Add(camp);
            string? name = nom;
            int? pv = bonusPv;
            int? dex = bonusDex;
            int? force = bonusForce;
            int? intel = bonusIntel;
            int? wisdom = bonusWisdom;
            int? consti = bonusConsti;
            int? charisma = bonusCharisma;

            if (nom == null || nom == "")
            {
                name = raceTempo.Nom;
            }

            if(bonusPv == null)
            {
                pv = raceTempo.BonusPV;
            }

            if(bonusDex == null)
            {
                dex = raceTempo.BonusDex;
            }

            if (bonusForce == null)
            {
                force = raceTempo.BonusForce;
            }

            if (bonusIntel == null)
            {
                intel = raceTempo.BonusIntel;
            }

            if (bonusWisdom == null)
            {
                wisdom = raceTempo.BonusWisdom;
            }

            if(bonusCharisma == null)
            {
                charisma = raceTempo.BonusCharisma;
            }

            if (bonusConsti == null)
            {
                consti = raceTempo.BonusConsti;
            }

            await _context.Races.Where(r => r.Id == id).ExecuteUpdateAsync(setters => setters
            .SetProperty(r => r.Nom, name)
            .SetProperty(r => r.BonusPV, pv)
            .SetProperty(r => r.BonusDex, dex)
            .SetProperty(r => r.BonusForce, force)
            .SetProperty(r => r.BonusIntel, intel)
            .SetProperty(r => r.BonusWisdom, wisdom)
            .SetProperty(r => r.BonusConsti, consti)
            .SetProperty(r => r.BonusCharisma, charisma));

            _context.SaveChanges();

            return NoContent();
            
        }

        // PUT api/<RaceController>/5
        [HttpPut("CreateRace")]
        public void Post(int id, string nom, int bonusPv, int bonusDex, int bonusForce, int bonusIntel, int bonusWisdom, int bonusConsti, int bonusCharisma, int campagne)
        {
            Race race = new Race {Id = id, Nom = nom, BonusPV = bonusPv, BonusDex = bonusDex, BonusIntel = bonusIntel, BonusForce = bonusForce, BonusWisdom = bonusWisdom, BonusConsti = bonusConsti, BonusCharisma = bonusCharisma};

            _context.Races.Add(race);
            _context.SaveChanges();
        }

        // DELETE api/<RaceController>/5
        [HttpDelete("DeleteRace")]
        public void Delete(int id)
        {
        }
    }
}
