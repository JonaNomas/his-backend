using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Estructura;
using Sistema.Web.Models.AgendaModel;

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

            var agenda = await _context.Agendas
                .Select(x => new AgendaModel
                {
                    idBloque = x.IdBloque,
                    name = x.Usuario.Paciente.NombrePrimer,
                    start = x.Bloque.FechaHora,
                    profesionalSalud = new ProfesionalSaludModel
                    {
                        nombre = x.Bloque.ProfesionalSalud.Usuario.Paciente.NombrePrimer + " " + x.Bloque.ProfesionalSalud.Usuario.Paciente.ApellidoPaterno + " " + x.Bloque.ProfesionalSalud.Usuario.Paciente.ApellidoMaterno,
                        especialidad = "",
                        rut = x.Bloque.ProfesionalSalud.Usuario.Paciente.Run
                    },
                    responsable = new ResponsableModel
                    {
                        nombre = "",
                        rut = ""
                    },
                    fechaCreacion = x.Bloque.FechaCreacion,
                    duracion = x.Bloque.Duracion,
                    Estado = x.Bloque.Estado
                }).ToListAsync();

            var idsAgenda = agenda.Select(a => a.idBloque).ToList();

            var bloque = await _context.Bloques.Where(x => !idsAgenda.Contains(x.IdBloque)).Select(x => new AgendaModel
             {
                idBloque = x.IdBloque,
                name = "Disponible",
                start = x.FechaHora,
                profesionalSalud = new ProfesionalSaludModel
                  {
                    nombre = x.ProfesionalSalud.Usuario.Paciente.NombrePrimer+" "+ x.ProfesionalSalud.Usuario.Paciente.ApellidoPaterno + " " + x.ProfesionalSalud.Usuario.Paciente.ApellidoMaterno,
                    especialidad = "",
                    rut = x.ProfesionalSalud.Usuario.Paciente.Run
                },
                 responsable = new ResponsableModel
                 {
                   nombre = "",
                   rut = ""
                 },
                 fechaCreacion = x.FechaCreacion,
                 duracion = x.Duracion,
                 Estado = x.Estado
                }).ToListAsync();

             agenda.AddRange(bloque);
             return Ok(agenda);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> crearAgenda([FromBody]CrearAgendaModel parametros) {

            if (!parametros.inicio.HasValue || !parametros.fin.HasValue ||
            !parametros.horaInicio.HasValue || !parametros.horaFin.HasValue)
            {
                return BadRequest("Faltan datos"); // Falta información esencial
            }

            DateTime fechaActual = parametros.inicio.Value;
            while (fechaActual <= parametros.fin.Value)
            {
                DateTime horaInicioBloque = fechaActual.Add(parametros.horaInicio.Value);
                DateTime horaFinDelDia = fechaActual.Add(parametros.horaFin.Value);

                while (horaInicioBloque < horaFinDelDia)
                {
                    DateTime horaFinBloque = horaInicioBloque.AddMinutes(parametros.duracion);

                    // Comprobar si el bloque finaliza después de la hora de fin
                    if (horaFinBloque > horaFinDelDia)
                    {
                        break; // No crear un bloque que termine después de la hora de fin
                    }

                    Bloque nuevoBloque = new Bloque
                    {
                        IdProfesionalSalud = parametros.idProfesional,
                        FechaHora = horaInicioBloque,
                        FechaCreacion = DateTime.Now,
                        Duracion = parametros.duracion,
                        Estado = 1 // o el estado por defecto que corresponda
                    };

                    _context.Bloques.Add(nuevoBloque);
                    horaInicioBloque = horaFinBloque; // Preparar para el siguiente bloque
                }

                fechaActual = fechaActual.AddDays(1); // Mover al siguiente día
            }

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
