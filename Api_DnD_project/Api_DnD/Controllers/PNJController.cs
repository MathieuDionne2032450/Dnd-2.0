using Api_DnD.Data;
using Api_DnD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Api_DnD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PNJController : Controller
    {
        private readonly DNDContext _context;

        public PNJController(DNDContext context)
        {
            _context = context;
        }

        //GET: PersoControllerCreate
        [HttpGet("/GetAllPNJ")]
        public async Task<ActionResult<IEnumerable<PNJ>>> GetAllPNJ(string? sortOrder, string? recherche, int page)
        {
            List<PNJ> listePNJ = new List<PNJ>();
            
            if (!string.IsNullOrEmpty(recherche))
            {
                foreach(PNJ pnj in _context.PNJ)
                {
                    if(pnj.Name.Contains(recherche))
                    {
                        // Comme on retourne des PNJDTO, il faut convertir les PNJ

                        listePNJ.Add(pnj);
                    }
                }
                return listePNJ;
            }

            if (page <= 0)
                page = 1;
            foreach (PNJ pnj in _context.PNJ)
            { 
                listePNJ.Add(pnj);
            }
            switch (sortOrder)
            {
                case "nom":
                    listePNJ.OrderBy(r => r.Name).Skip((3 * page) - 3).Take(3);
                    return listePNJ;
                case "nom_desc":
                    listePNJ.OrderByDescending(r => r.Name).Skip((3 * page) - 3).Take(3);
                    return listePNJ;
                default:
                    listePNJ.Skip((3 * page) - 3).Take(3);
                    return listePNJ;
            }
        }

        [HttpGet("/GetPNJById/{id}")]
        public async Task<ActionResult<PNJ>> GetPnj(int id)
        {
            return await _context.PNJ.FindAsync(id);
        }

        [HttpGet("GetPNJByCampagne")]
        public async Task<ActionResult<ICollection<PNJ>>> GetPNJByCampagne(int campagneId)
        {
            Campagne campagne = await _context.Campagnes
                .Include(c => c.PNJs)
                .ThenInclude(p => p.Quetes)
                .FirstOrDefaultAsync(c => c.Id == campagneId);

            if(campagne == null)
            {
                return NotFound();
            }
            return Ok(campagne.PNJs.OrderBy(p=>p.Name));
        }

        //GET: PersoControllerCreate
        [HttpGet("/GetPNJQuete")]
        public async Task<ActionResult<PnjDTO>> GetPNJQuete(int x)
        {
            PNJ? pnj = await _context.PNJ.FindAsync(x);
            return PnjDTO.PnjToPnjDTO(pnj);
        }

        [HttpPut("/EditPNJ")]
        public async Task<ActionResult<PNJ>> EditPNJ(int id,  int Bouche,  int Nez,  int Barbe,  int Cheveux, int Sourcil,int Tete,int Yeux1,int Yeux2,string? Description,string? Name)
        {
            PNJ p = await _context.PNJ.FindAsync(id);

            if (p != null)
            {
                if (string.IsNullOrEmpty(Description))
                    Description = p.Description;

                if (string.IsNullOrEmpty(Name))
                    Name = p.Name;

                await _context.PNJ.Where(p => p.Id == id).ExecuteUpdateAsync(setters => setters
                .SetProperty(p => p.Bouche, Bouche)
                .SetProperty(p => p.Nez, Nez)
                .SetProperty(p => p.Barbe, Barbe)
                .SetProperty(p => p.Cheveux, Cheveux)
                .SetProperty(p => p.Sourcil, Sourcil)
                .SetProperty(p => p.Tete, Tete)
                .SetProperty(p => p.Yeux1, Yeux1)
                .SetProperty(p => p.Yeux2, Yeux2)
                .SetProperty(p => p.Description, Description)
                .SetProperty(p => p.Name, Name)
                );
                _context.SaveChanges();
            }
            return NoContent();
        }

        [HttpPost("/CreatePNJ")]
        public async Task<ActionResult<PNJ>> CreatePNJ(
            int Bouche,
            int Nez,
            int Barbe,
            int Cheveux,
            int Sourcil,
            int Tete,
            int Yeux1,
            int Yeux2,
            string Description,
            string Name,
            Campagne campagne)
        {
            PNJ pnj = new PNJ
            {
                Bouche = Bouche,
                Nez = Nez,
                Barbe = Barbe,
                Cheveux = Cheveux,
                Sourcil = Sourcil,
                Tete = Tete,
                Yeux1 = Yeux1,
                Yeux2 = Yeux2,
                Description = Description,
                Name = Name,
                Campagne = campagne
            };

            _context.PNJ.Add(pnj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPNJById", new { id = pnj.Id }, pnj);
        }

        [HttpDelete("/DeletePNJ/{id}")]
        public async Task<bool> DeletePNJ(int id)
        {
            if (await _context.PNJ.Where(p => p.Id.Equals(id)).ExecuteDeleteAsync() == 1)
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
