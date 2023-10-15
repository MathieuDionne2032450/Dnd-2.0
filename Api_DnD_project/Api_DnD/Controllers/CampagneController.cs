using Api_DnD.Data;
using Api_DnD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_DnD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CampagneController : Controller
    {

        private readonly DNDContext _context;

        public CampagneController(DNDContext context)
        {
            _context = context;
        }


        [HttpGet("/GetCampagneById/{id}")]
        public async Task<ActionResult<Campagne>> GetCampagneById(int id)
        {
            return await _context.Campagnes.FindAsync(id);
        }

        [HttpPost("/CreateCampagne/")]
        public async Task<ActionResult<Arme>> CreateCampagne(string Name, string Desc)
        {
            Campagne CampagneCree = new Campagne { Name= Name, Desc= Desc };

            _context.Campagnes.Add(CampagneCree);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCampagneById", new { id = CampagneCree.Id }, CampagneCree);
        }

        [HttpPut("/EditCampagne")]
        public async Task<ActionResult<Campagne>> EditCampagne(int Id, string Name, string Desc)
        {
            await _context.Campagnes.Where(c => c.Id == Id).ExecuteUpdateAsync(setters => setters
            .SetProperty(c => c.Name, Name)
            .SetProperty(c => c.Desc, Desc));

            return NoContent();
        }

        // POST: ArmeController/Delete/5
        // Si une entrée est trouvée et supprimée, la valeur true est retournée, sinon c'est la valeur false
        [HttpDelete("/DeleteCampagne/{id}")]
        public async Task<bool> DeleteCampagne(int id)
        {
            await DeletePersos(id);

            var campagne = _context.Campagnes
                .Include(c => c.Armes)
                .Include(c => c.PNJs)
                .Include(c => c.Armures)
                .Include(c => c.Monstres)
                .Include(c => c.Classes)
                .Include(c => c.Races)
                .Include(c => c.Enchantements)
                .Include(c => c.Quetes)
                .FirstOrDefault(c => c.Id == id);

            if (campagne != null)
            {
                campagne.Armes.Clear();
                campagne.PNJs.Clear();
                campagne.Armures.Clear();
                campagne.Monstres.Clear();
                campagne.Classes.Clear();
                campagne.Races.Clear();
                campagne.Enchantements.Clear();
                campagne.Quetes.Clear();

                


                _context.Campagnes.Remove(campagne);

                _context.SaveChanges();
                return true;
            }

            
            
            return false;
            
        }


        async Task<bool> DeletePersos(int id)
        {
            var persos = _context.Persos
                   .Include(p => p.Campagne)
                   .Include(p => p.LesArmes)
                   .Include(p => p.feats)
                   .Include(p => p.Skills)
                   .Where(p => p.Campagne.Id == id);

            foreach (var p in persos)
            {
                p.Skills.Clear();
                p.feats.Clear();
                p.LesArmes.Clear();
                _context.Persos.Remove(p);
            }
            _context.SaveChanges();
            return true;
        }
    }
}
