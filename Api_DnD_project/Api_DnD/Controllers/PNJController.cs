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
        public async Task<ActionResult<IEnumerable<PnjDTO>>> GetAllPNJ(string? sortOrder, string? recherche, int page)
        {
            List<PnjDTO> listePNJDTO = new List<PnjDTO>();
            PnjDTO pnjConverti;
            if (!string.IsNullOrEmpty(recherche))
            {
                foreach(PNJ pnj in _context.PNJ)
                {
                    if(pnj.Name.Contains(recherche))
                    {
                        // Comme on retourne des PNJDTO, il faut convertir les PNJ
                        pnjConverti = PnjDTO.PnjToPnjDTO(pnj);
                        listePNJDTO.Add(pnjConverti);
                    }
                }
                return listePNJDTO;
            }

            if (page <= 0)
                page = 1;
            foreach (PNJ pnj in _context.PNJ)
            {
                pnjConverti = PnjDTO.PnjToPnjDTO(pnj);
                listePNJDTO.Add(pnjConverti);
            }
            switch (sortOrder)
            {
                case "nom":
                    listePNJDTO.OrderBy(r => r.Nom).Skip((3 * page) - 3).Take(3);
                    return listePNJDTO;
                case "nom_desc":
                    listePNJDTO.OrderByDescending(r => r.Nom).Skip((3 * page) - 3).Take(3);
                    return listePNJDTO;
                default:
                    listePNJDTO.Skip((3 * page) - 3).Take(3);
                    return listePNJDTO;
            }
        }

        [HttpGet("/GetPNJById/{id}")]
        public async Task<ActionResult<PNJ>> GetPersoById(int id)
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
        public async Task<ActionResult<PNJ>> EditPNJ(
            int Id, 
            int Bouche, 
            int Nez, 
            int Barbe, 
            int Cheveux, 
            int Sourcil,
            int Tete,
            int Yeux1,
            int Yeux2,
            string Description,
            string Name)
        {
            await _context.PNJ.Where(p => p.Id == Id).ExecuteUpdateAsync(setters => setters
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
            string Name)
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
                Name = Name
            };

            _context.PNJ.Add(pnj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPNJById", new { id = pnj.Id }, pnj);
        }

        [HttpDelete("/DeletePNJ/{id}")]
        public async Task<bool> DeletePNJ(int id)
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
