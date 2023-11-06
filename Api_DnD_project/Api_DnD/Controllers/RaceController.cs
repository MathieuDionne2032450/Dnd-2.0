using Api_DnD.Data;
using Api_DnD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_DnD.Controllers
{
    [Route("[controller]")]
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
        public async Task<ActionResult<IEnumerable<Race>>> GetRace(string? sortOrder, string? recherche, string? rechercheCampagne, int page)
        {
            if(!string.IsNullOrEmpty(recherche))
            {
                return await _context.Races.Where(r => r.Nom.Contains(recherche)).ToListAsync();
            }

            // Si le nom d'une campagne est entré, passer à travers toutes les races pour voir si elles font partie de celle-ci
            if(!string.IsNullOrEmpty(rechercheCampagne))
            {
                List<Race> listeRaces = new List<Race>();
                foreach(Race race in _context.Races)
                {
                    foreach(Campagne campagne in race.Campagnes)
                    {
                        // Si le nom de telle campagne de la race actuelle contient les critères de recherche
                        // Ajouter la race à la liste de races à retourner
                        if (campagne.Name.Contains(rechercheCampagne))
                            listeRaces.Add(race);
                    }
                }
                return listeRaces;
            }

            if (page <= 0)
                page = 1;

            switch (sortOrder)
            {
                case "nom":
                    return await _context.Races.OrderBy(r => r.Nom).Skip((3 * page) - 3).Take(3).ToListAsync();
                    break;
                case "nom_desc":
                    return await _context.Races.OrderByDescending(r => r.Nom).Skip((3 * page) - 3).Take(3).ToListAsync();
                    break;
                case "bonusPV":
                    return await _context.Races.OrderBy(r => r.BonusPV).Skip((3 * page) - 3).Take(3).ToListAsync();
                    break;
                case "bonusPV_desc":
                    return await _context.Races.OrderByDescending(r => r.BonusPV).Skip((3 * page) - 3).Take(3).ToListAsync();
                    break;
                case "bonusDex":
                    return await _context.Races.OrderBy(r => r.BonusDex).Skip((3 * page) - 3).Take(3).ToListAsync();
                    break;
                case "bonusDex_desc":
                    return await _context.Races.OrderByDescending(r => r.BonusDex).Skip((3 * page) - 3).Take(3).ToListAsync();
                    break;
                case "bonusForce":
                    return await _context.Races.OrderBy(r => r.BonusForce).Skip((3 * page) - 3).Take(3).ToListAsync();
                    break;
                case "bonusForce_desc":
                    return await _context.Races.OrderByDescending(r => r.BonusForce).Skip((3 * page) - 3).Take(3).ToListAsync();
                    break;
                case "bonusIntel":
                    return await _context.Races.OrderBy(r => r.BonusIntel).Skip((3 * page) - 3).Take(3).ToListAsync();
                    break;
                case "bonusIntel_desc":
                    return await _context.Races.OrderByDescending(r => r.BonusIntel).Skip((3 * page) - 3).Take(3).ToListAsync();
                    break;
                case "bonusWisdom":
                    return await _context.Races.OrderBy(r => r.BonusWisdom).Skip((3 * page) - 3).Take(3).ToListAsync();
                    break;
                case "bonusWisdom_desc":
                    return await _context.Races.OrderByDescending(r => r.BonusWisdom).Skip((3 * page) - 3).Take(3).ToListAsync();
                    break;
                case "bonusConsti":
                    return await _context.Races.OrderBy(r => r.BonusConsti).Skip((3 * page) - 3).Take(3).ToListAsync();
                    break;
                case "bonusConsti_desc":
                    return await _context.Races.OrderByDescending(r => r.BonusConsti).Skip((3 * page) - 3).Take(3).ToListAsync();
                    break;
                case "bonusCharisma":
                    return await _context.Races.OrderBy(r => r.BonusCharisma).Skip((3 * page) - 3).Take(3).ToListAsync();
                    break;
                case "bonusCharisma_desc":
                    return await _context.Races.OrderByDescending(r => r.BonusCharisma).Skip((3 * page) - 3).Take(3).ToListAsync();
                    break;
                case "id":
                    return await _context.Races.OrderBy(r => r.Id).Skip((3 * page) - 3).Take(3).ToListAsync();
                    break;
                case "id_desc":
                    return await _context.Races.OrderByDescending(r => r.Id).Skip((3 * page) - 3).Take(3).ToListAsync();
                    break;
                default:
                    return await _context.Races.Skip((3 * page) - 3).Take(3).ToListAsync();
            }

        }

        // GET api/<RaceController>/5
        [HttpGet("RaceById")]
        public async Task<ActionResult<Race>> GetRaceById(int id)
        {
            return await _context.Races.FindAsync(id);
        }

        // POST api/<RaceController>
        [HttpPut("EditRace")]
        public async Task<ActionResult<Race>> EditRace(int id, string? nom, int? bonusPv, int? bonusDex, int? bonusForce, int? bonusIntel, int? bonusWisdom, int? bonusConsti, int? bonusCharisma,int? campagne)
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
            if (raceTempo != null)
            {
                if (nom == null || nom == "")
                {
                    name = raceTempo.Nom;
                }

                if (bonusPv == null)
                {
                    pv = raceTempo.BonusPV;
                }

                if (bonusDex == null)
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

                if (bonusCharisma == null)
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
            }
            return NoContent();
            
        }

        // PUT api/<RaceController>/5
        [HttpPost("CreateRace")]
        public void CreateRace(string nom, int bonusPv, int bonusDex, int bonusForce, int bonusIntel, int bonusWisdom, int bonusConsti, int bonusCharisma, int campagne)
        {


            Race race = new Race {Nom = nom, BonusPV = bonusPv, BonusDex = bonusDex, BonusIntel = bonusIntel, BonusForce = bonusForce, BonusWisdom = bonusWisdom, BonusConsti = bonusConsti, BonusCharisma = bonusCharisma};

            _context.Races.Add(race);
            _context.SaveChanges();
        }

        // DELETE api/<RaceController>/5
        [HttpDelete("DeleteRace")]
        public async Task<bool> DeleteRace(int id)
        {
            if (await _context.Races.Where(r => r.Id.Equals(id)).ExecuteDeleteAsync() == 1)
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
