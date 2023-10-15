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
    }
}
