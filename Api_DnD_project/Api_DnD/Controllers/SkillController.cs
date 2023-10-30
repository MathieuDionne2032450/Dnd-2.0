using Api_DnD.Data;
using Api_DnD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace Api_DnD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SkillController
    {
        private readonly DNDContext _context;
        public SkillController(DNDContext context)
        {
            _context = context;
        }

        [HttpGet("/GetAllSkill")]
        public async Task<ActionResult<IEnumerable<Skill>>> GetSkill(string? sortOrder, string? recherche, int page)
        {
            if (!string.IsNullOrEmpty(recherche))
            {
                return await _context.Skill.Where(s => s.Nom.Contains(recherche)).ToListAsync();
            }

            if (page <= 0)
                page = 1;

            switch (sortOrder)
            {
                case "nom":
                    return await _context.Skill.OrderBy(s => s.Nom).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "id":
                    return await _context.Skill.OrderBy(s => s.id).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "nom_desc":
                    return await _context.Skill.OrderByDescending(s => s.Nom).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "id_desc":
                    return await _context.Skill.OrderByDescending(s => s.id).Skip((3 * page) - 3).Take(3).ToListAsync();

                default:
                    return await _context.Skill.ToListAsync();
            }
        }

        [HttpGet("/GetSkill/{id}")]
        public async Task<ActionResult<Skill>> GetSkill(int id)
        {
            return await _context.Skill.FindAsync(id);
        }

        [HttpPut("/EditSkill")]
        public async Task<ActionResult<Skill>> EditSkill(int id, string nom, string description)
        {
            Skill s = await _context.Skill.FindAsync(id);
            if (s != null)
            {
                if (string.IsNullOrEmpty(nom))
                    nom = s.Nom;

                if (string.IsNullOrEmpty(description))
                    description = s.Descr;

                await _context.Skill.Where(m => m.id == id).ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Nom, nom)
                    .SetProperty(m => m.Descr, description)
                    );

                _context.SaveChanges();

            }
            return null;
        }

        [HttpPost("/CreateSkill")]
        public async Task<ActionResult<Skill>> CreateSkill(string nom, string description)
        {
            Skill SkillCree = new Skill { Nom = nom, Descr = description};

            _context.Skill.Add(SkillCree);
            await _context.SaveChangesAsync();

            return null;
        }

        // POST: ArmeController/Delete/5
        // Si une entrée est trouvée et supprimée, la valeur true est retournée, sinon c'est la valeur false
        [HttpDelete("/DeleteSkill/{id}")]
        public async Task<bool> DeleteSkill(int id)
        {
            if (await _context.Skill.Where(s => s.id.Equals(id)).ExecuteDeleteAsync() == 1)
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
