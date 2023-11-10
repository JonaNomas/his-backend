using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Web.Models.PacienteModel;

namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {

        private readonly DbContextSistema _context;

        public PacienteController(DbContextSistema context)
        {
            _context = context;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> test() {


            return Ok( await _context.Pacientes.ToListAsync());
        }

    
    }
}
