using Api_DnD.Data;
using Api_DnD.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Api_DnD.Controllers
{
    public class ClassesController : Controller
    {
        private readonly DNDContext _context;

        public ClassesController(DNDContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Classes>>> GetClasses(string? sortOrder, string? recherche, int page)
        {
            if (!string.IsNullOrEmpty(recherche))
            {
                return await _context.Classes.Where(e => e.name.Contains(recherche)).ToListAsync();
            }

            if (page <= 0)
                page = 1;

            switch (sortOrder)
            {
                case "nom":
                    return await _context.Classes.OrderBy(e => e.name).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "id":
                    return await _context.Classes.OrderBy(e => e.id).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "nom_desc":
                    return await _context.Classes.OrderByDescending(e => e.name).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "id_desc":
                    return await _context.Classes.OrderByDescending(e => e.id).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "primaryAbility":
                    return await _context.Classes.OrderBy(e => e.primaryAbility).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "primaryAbility_desc":
                    return await _context.Classes.OrderByDescending(e => e.primaryAbility).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "hitDie":
                    return await _context.Classes.OrderBy(e => e.hitDie).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "hitDie_desc":
                    return await _context.Classes.OrderByDescending(e => e.hitDie).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "description":
                    return await _context.Classes.OrderBy(e => e.description).Skip((3 * page) - 3).Take(3).ToListAsync();

                case "description_desc":
                    return await _context.Classes.OrderByDescending(e => e.description).Skip((3 * page) - 3).Take(3).ToListAsync();

                default:
                    return await _context.Classes.ToListAsync();

            }
        }

        [HttpGet("/GetClasses/{id}")]
        public async Task<ActionResult<Classes>> GetClassesById(int id)
        {
            var test = await _context.Classes.FindAsync(id);
            return test;
        }

        [HttpPut("/EditClasses")]
        public async Task<ActionResult<Classes>> EditClasses(int id, string? Nom, string? Description, string? hitDie, string? primaryAbility)
        {
            Classes? e = await _context.Classes.FindAsync(id);
            if (e != null)
            {
                if (string.IsNullOrEmpty(Nom))
                    Nom = e.name;

                if (string.IsNullOrEmpty(Description))
                    Description = e.description;

                if (string.IsNullOrEmpty(hitDie))
                    hitDie = e.hitDie;

                if (string.IsNullOrEmpty(primaryAbility))
                    primaryAbility = e.primaryAbility;

                await _context.Classes.Where(e => e.id == id).ExecuteUpdateAsync(setters => setters
                .SetProperty(e => e.name, Nom)
                .SetProperty(e => e.description, Description)
                .SetProperty(e => e.hitDie, hitDie)
                .SetProperty(e => e.primaryAbility, primaryAbility)
                );
                await _context.SaveChangesAsync();

            }

            return NoContent();
        }

        [HttpPost("/CreateClasses")]
        public async Task<ActionResult<Classes>> CreateClasses(string? Nom, string? Description, string? hitDie, string? primaryAbility)
        {
            Classes Classes = new Classes { name = Nom, description = Description, hitDie = hitDie, primaryAbility = primaryAbility };
            _context.Classes.Add(Classes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClasses", new { id = Classes.id }, Classes);
        }

        [HttpDelete("/DeleteClasses/{id}")]
        public async Task<bool> DeleteClasses(int id)
        {
            if (await _context.Classes.Where(e => e.id.Equals(id)).ExecuteDeleteAsync() == 1)
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
