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
        
    }
}
