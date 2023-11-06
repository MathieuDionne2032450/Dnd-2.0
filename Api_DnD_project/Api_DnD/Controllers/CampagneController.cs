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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Campagne>>> GetCampagne(string? sortOrder, string? recherche, int page)
        {
            if (!string.IsNullOrEmpty(recherche))
            {
                return await _context.Campagnes.Where(e => e.Name.Contains(recherche)).ToListAsync();
            }

            if (page <= 0)
                page = 1;

            switch(sortOrder)
            {
                case "nom":
                    return await _context.Campagnes.OrderBy(e => e.Name).Skip((3 * page) - 3).Take(3).ToListAsync();
                case "nom_desc":
                    return await _context.Campagnes.OrderByDescending(e => e.Name).Skip((3 * page) - 3).Take(3).ToListAsync();
                case "id":
                    return await _context.Campagnes.OrderBy(e => e.Id).Skip((3 * page) - 3).Take(3).ToListAsync();
                case "id_desc":
                    return await _context.Campagnes.OrderByDescending(e => e.Id).Skip((3 * page) - 3).Take(3).ToListAsync();
                default:
                    return await _context.Campagnes.ToListAsync();
            }
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




        [HttpPost("/CampagneArme/")]
        public async Task<ActionResult<Campagne>> CampagneArme(int idCampagne,int idArme)
        {
            var campagne = _context.Campagnes
                 .Include(c => c.Armes)
                 .FirstOrDefault(c => c.Id == idCampagne);

            if (campagne != null)
            {
                campagne.Armes.Add(await _context.Armes.FindAsync(idArme));

                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetCampagneById", new { id = campagne.Id }, campagne);
        }

        [HttpPost("/CampagneArmure/")]
        public async Task<ActionResult<Campagne>> CampagneArmure(int idCampagne, int idArmure)
        {
            var campagne = _context.Campagnes
                 .Include(c => c.Armures)
                 .FirstOrDefault(c => c.Id == idCampagne);

            if (campagne != null)
            {
                campagne.Armures.Add(await _context.Armures.FindAsync(idArmure));

                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetCampagneById", new { id = campagne.Id }, campagne);
        }

        [HttpPost("/CampagneEnchantement/")]
        public async Task<ActionResult<Campagne>> CampagneEnchantement(int idCampagne, int idEnchantement)
        {
            var campagne = _context.Campagnes
                 .Include(c => c.Enchantements)
                 .FirstOrDefault(c => c.Id == idCampagne);

            if (campagne != null)
            {
                campagne.Enchantements.Add(await _context.Enchantements.FindAsync(idEnchantement));

                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetCampagneById", new { id = campagne.Id }, campagne);
        }

        [HttpPost("/CampagneMonstres/")]
        public async Task<ActionResult<Campagne>> CampagneMonstres(int idCampagne, int idMonstre)
        {
            var campagne = _context.Campagnes
                 .Include(c => c.Monstres)
                 .FirstOrDefault(c => c.Id == idCampagne);

            if (campagne != null)
            {
                campagne.Monstres.Add(await _context.Monstres.FindAsync(idMonstre));

                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetCampagneById", new { id = campagne.Id }, campagne);
        }

        [HttpPost("/CampagnePNJs/")]
        public async Task<ActionResult<Campagne>> CampagnePNJs(int idCampagne, int idpnj)
        {
            var campagne = _context.Campagnes
                 .Include(c => c.PNJs)
                 .FirstOrDefault(c => c.Id == idCampagne);

            if (campagne != null)
            {
                campagne.PNJs.Add(await _context.PNJ.FindAsync(idpnj));

                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetCampagneById", new { id = campagne.Id }, campagne);
        }

        [HttpPost("/CampagneQuetes/")]
        public async Task<ActionResult<Campagne>> CampagneQuetes(int idCampagne, int idpnj)
        {
            var campagne = _context.Campagnes
                 .Include(c => c.Quetes)
                 .FirstOrDefault(c => c.Id == idCampagne);

            if (campagne != null)
            {
                campagne.Quetes.Add(await _context.Quetes.FindAsync(idpnj));

                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetCampagneById", new { id = campagne.Id }, campagne);
        }

        [HttpPost("/CampagneClasses/")]
        public async Task<ActionResult<Campagne>> CampagneClasses(int idCampagne, int idpnj)
        {
            var campagne = _context.Campagnes
                 .Include(c => c.Classes)
                 .FirstOrDefault(c => c.Id == idCampagne);

            if (campagne != null)
            {
                campagne.Classes.Add(await _context.Classes.FindAsync(idpnj));

                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetCampagneById", new { id = campagne.Id }, campagne);
        }

        [HttpPost("/CampagneRaces/")]
        public async Task<ActionResult<Campagne>> CampagneRaces(int idCampagne, int idpnj)
        {
            var campagne = _context.Campagnes
                 .Include(c => c.Races)
                 .FirstOrDefault(c => c.Id == idCampagne);

            if (campagne != null)
            {
                campagne.Races.Add(await _context.Races.FindAsync(idpnj));

                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetCampagneById", new { id = campagne.Id }, campagne);
        }
    }
}
