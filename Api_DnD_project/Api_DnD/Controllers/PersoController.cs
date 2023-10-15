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
        public async Task<ActionResult<IEnumerable<Perso>>> GetAllPerso()
        {

            return await _context.Persos
                .Include(p => p.LesArmes)
                .ThenInclude(p => p.Enchantement)
                .OrderBy(p => p.Nom)
                .ToListAsync();
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
    }
}
