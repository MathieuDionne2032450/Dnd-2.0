using Api_DnD.Data;
using Api_DnD.Model;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<IEnumerable<PnjDTO>>> GetAllPNJ()
        {
            return  _context.PNJ.Select(x => PnjDTO.PnjToPnjDTO(x)).OrderBy(p => p.Nom).ToList();
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
