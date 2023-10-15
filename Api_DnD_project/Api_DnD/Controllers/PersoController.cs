using Api_DnD.Data;
using Api_DnD.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_DnD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersoController : ControllerBase
    {


        private readonly DNDContext _context;

        public PersoController(DNDContext context)
        {
            _context = context;
        }

        // GET: PersoController/Create
        [HttpGet("/AllPerso")]
        public async Task<ActionResult<IEnumerable<Perso>>> GetAllPerso(string? sortOrder, string? recherche, string? rechercheCampagne, int page)
        {
            if (!string.IsNullOrEmpty(recherche))
            {
                return await _context.Persos.Where(p => p.Nom.Contains(recherche)).ToListAsync();
            }

            if (!string.IsNullOrEmpty(rechercheCampagne))
            {
                List<Perso> listePersos = new List<Perso>();
                foreach (Perso perso in _context.Persos)
                {
                    if (perso.Campagne.Name.Contains(rechercheCampagne))
                        listePersos.Add(perso);
                }
                return listePersos;
            }

            if (page <= 0)
                page = 1;

            switch (sortOrder) 
            {
                case "irlJoueur":
                    return await _context.Persos.OrderBy(p => p.IrlJoueur).Skip((3 * page) - 3).Take(3).ToListAsync();
                case "irlJoueur_desc":
                    return await _context.Persos.OrderBy(p => p.IrlJoueur).Skip((3 * page) - 3).Take(3).ToListAsync();
                case "nom":
                    return await _context.Persos.OrderBy(p => p.Nom).Skip((3 * page) - 3).Take(3).ToListAsync();
                case "nom_desc":
                    return await _context.Persos.OrderByDescending(p => p.Nom).Skip((3 * page) - 3).Take(3).ToListAsync();
                case "niv":
                    return await _context.Persos.OrderBy(p => p.Niv).Skip((3 * page) - 3).Take(3).ToListAsync();
                case "niv_desc":
                    return await _context.Persos.OrderByDescending(p => p.Niv).Skip((3 * page) - 3).Take(3).ToListAsync();
                case "id":
                    return await _context.Persos.OrderBy(p => p.id).Skip((3 * page) - 3).Take(3).ToListAsync();
                case "id_desc":
                    return await _context.Persos.OrderByDescending(p => p.id).Skip((3 * page) - 3).Take(3).ToListAsync();
                default:
                    return await _context.Persos.Skip((3 * page) - 3).Take(3).ToListAsync();
            }
        }

        [HttpGet("/GetPersoById/{id}")]
        public async Task<ActionResult<Perso>> GetPersoById(int id)
        {
            return await _context.Persos.FindAsync(id);
        }

        // GET: PersoController/Create
        [HttpGet ("/BaseInfoPerso/{id}")]
        public async Task<ActionResult<PersoDTO>> GetBaseInfoPerso(int id)
        {
            var perso = await _context.Persos.FindAsync(id);

            if(perso == null)
            {
                return NotFound();
            }

            return PersoDTO.PersoToDTO(perso);
        }

        //[HttpPut("/EditPerso")]
        //public async Task<ActionResult<Perso>> EditPerso(
        //    int id, 
        //    string IrlJoueur,
        //    string Nom,
        //    string Description,
        //    int Inspiration,
        //    int ArmureId,
        //    ICollection<Arme> LesArmes,
        //    int ClasseId,
        //    int RaceId,
        //    ICollection<Skill> Skills,
        //    string Personalitetrait,
        //    string Ideal,
        //    string Bonds,
        //    string Flaws,
        //    int Niv,
        //    Campagne Campagne)
        //{
        //    await _context.Persos.Where(p => p.id == id).ExecuteUpdateAsync(setters => setters
        //    .SetProperty(p => p.IrlJoueur, IrlJoueur)
        //    .SetProperty(p => p.Nom, Nom)
        //    .SetProperty(p => p.Description, Description)
        //    .SetProperty(p => p.Inspiration, Inspiration)
        //    .SetProperty(p => p.ArmureId, ArmureId)
        //    .SetProperty(p => p.LesArmes, LesArmes)
        //    .SetProperty(p => p.ClasseId, ClasseId)
        //    .SetProperty(p => p.RaceId, RaceId)
        //    .SetProperty(p => p.Skills, Skills)
        //    .SetProperty(p => p.Personalitetrait, Personalitetrait)
        //    .SetProperty(p => p.Ideal, Ideal)
        //    .SetProperty(p => p.Bonds, Bonds)
        //    .SetProperty(p => p.Flaws, Flaws)
        //    .SetProperty(p => p.Niv, Niv)
        //    .SetProperty(p => p.Campagne, Campagne)
        //    );

        //    return NoContent();
        //}

        //[HttpPost("/CreatePerso")]
        //public async Task<ActionResult<Perso>> CreatePerso(
        //    string IrlJoueur,
        //    string Nom,
        //    string Description,
        //    int Inspiration,
        //    int ArmureId,
        //    ICollection<Arme> LesArmes,
        //    int ClasseId,
        //    int RaceId,
        //    ICollection<Skill> Skills,
        //    string Personalitetrait,
        //    string Ideal,
        //    string Bonds,
        //    string Flaws,
        //    int Niv,
        //    Campagne Campagne)
        //{
        //    Perso perso = new Perso
        //    {
        //        IrlJoueur = IrlJoueur,
        //        Nom = Nom,
        //        Description = Description,
        //        Inspiration = Inspiration,
        //        ArmureId = ArmureId,
        //        LesArmes = LesArmes,
        //        ClasseId = ClasseId,
        //        RaceId = RaceId,
        //        Skills = Skills,
        //        Personalitetrait = Personalitetrait,
        //        Ideal = Ideal,
        //        Bonds = Bonds,
        //        Flaws = Flaws,
        //        Niv = Niv,
        //        Campagne = Campagne
        //    };

        //    _context.Persos.Add(perso);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPersoById", new { id = perso.id }, perso);
        //}

        [HttpDelete("/DeletePerso/{id}")]
        public async Task<bool> DeletePerso(int id)
        {
            if (await _context.Persos.Where(p => p.id.Equals(id)).ExecuteDeleteAsync() == 1) 
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
