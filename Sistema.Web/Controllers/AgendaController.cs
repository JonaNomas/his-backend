using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;

namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public AgendaController(DbContextSistema context)
        {
            _context = context;
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> obtenerAgenda() {

            var sql = await _context.Bloques.Select(x => new {
                inicio = x.FechaHora,
                fin = x.FechaHora.AddMinutes(x.Duracion),
                profesional = new {
                    uuid = x.ProfesionalSalud.Usuario.Paciente.PacienteUUID,
                    nombre = x.ProfesionalSalud.Usuario.Paciente.NombrePrimer,
                    especialidades = _context.ProfesionalesSaludEspecialidades.Where(y => y.IdProfesionalSalud == x.IdProfesionalSalud).Select(y => new { 
                        nombre = y.Especialidad.NombreEspecialidad,
                        id = y.Especialidad.IdEspecialidad
                    }).ToList()
                }
            }).ToListAsync();

             return Ok(sql);
        }

    }
}
