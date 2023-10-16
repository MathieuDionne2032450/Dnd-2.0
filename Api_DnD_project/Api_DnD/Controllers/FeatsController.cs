using Api_DnD.Data;
using Api_DnD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_DnD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatsController : Controller
    {

        private readonly DNDContext _context;
        public FeatsController(DNDContext context)
        {
            _context = context;
        }

        [HttpGet("/GetAllFeats")]
        public async Task<ActionResult<IEnumerable<feats>>> GetArme(string? sortOrder, string? recherche, int page)
        {
            if (!string.IsNullOrEmpty(recherche))
            {
                return await _context.Feats.Where(f => f.Nom.Contains(recherche)).ToListAsync();
            }

            if (page <= 0)
                page = 1;

            switch (sortOrder)
            {
                case "nom":
                    return await _context.Feats.OrderBy(f => f.Nom).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "id":
                    return await _context.Feats.OrderBy(f => f.id).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "nom_desc":
                    return await _context.Feats.OrderByDescending(f => f.Nom).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "id_desc":
                    return await _context.Feats.OrderByDescending(f => f.id).Skip((3 * page) - 3).Take(3).ToListAsync();

                default:
                    return await _context.Feats.ToListAsync();
            }
        }

        [HttpGet("/GetFeat/{id}")]
        public async Task<ActionResult<feats>> GetArme(int id)
        {
            return await _context.Feats.FindAsync(id);
        }

        [HttpPut("/EditFeat")]
        public async Task<ActionResult<feats>> EditArme(int id,string name, string description)
        {
            feats f = await _context.Feats.FindAsync(id);

            if (string.IsNullOrEmpty(name))
                name = f.Nom;

            if (string.IsNullOrEmpty(description))
                description = f.Descr;

            await _context.Feats.Where(f => f.id == id).ExecuteUpdateAsync(setters => setters
            .SetProperty(f => f.Nom, name)
            .SetProperty(f => f.Descr, description));
            return NoContent();
        }

        [HttpPost("/CreateFeat")]
        public async Task<ActionResult<feats>> CreateArme(string name)
        {
            feats featCree = new feats { Nom = name };

            _context.Feats.Add(featCree);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: ArmeController/Delete/5
        // Si une entrée est trouvée et supprimée, la valeur true est retournée, sinon c'est la valeur false
        [HttpDelete("/DeleteFeat/{id}")]
        public async Task<bool> DeleteArme(int id)
        {
            if (await _context.Feats.Where(f => f.id.Equals(id)).ExecuteDeleteAsync() == 1)
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
