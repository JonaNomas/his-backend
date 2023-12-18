using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
        public async Task<IActionResult> obtenerAgenda([FromBody] ParametrosAgendaModel model) {

            var paciente = false;
            IQueryable<Agenda> sql = _context.Agendas;
            IQueryable<Bloque> sql2 = _context.Bloques;

            if (model.idProfesional > 0)
            {
                sql = sql.Where(x => x.Bloque.IdProfesionalSalud == model.idProfesional);
                sql2 = sql2.Where(x => x.IdProfesionalSalud == model.idProfesional);
            }
            if (model.idEspecialidad > 0) {
                sql = sql.Where(x => x.Bloque.idEspecialidad == model.idEspecialidad);
                sql2 = sql2.Where(x => x.idEspecialidad == model.idEspecialidad);
            }

            if (!model.rutPaciente.IsNullOrEmpty()) { 
                var p = await _context.Pacientes.Where(x => x.Run == model.rutPaciente).FirstOrDefaultAsync();
                if (p == null) {
                    return BadRequest("El rut no cuenta con horas");
                };
                sql = sql.Where(x => x.Paciente.IdPaciente == p.IdPaciente);
                paciente = true;
            }


            var agenda = await sql
                .Where(x => x.Bloque.FechaHora.Month == model.mes && x.Bloque.FechaHora.Year == model.ano && x.Estado)
                .Select(x => new AgendaModel
                {
                    idBloque = x.IdBloque,
                    name = x.Paciente.NombrePrimer+" "+x.Paciente.ApellidoPaterno+" "+x.Paciente.ApellidoMaterno,
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
                    Estado = x.Bloque.Estado,
                    Especialidad = x.Bloque.especialidad.NombreEspecialidad,
                    IdEspecialidad = x.Bloque.idEspecialidad
                }).ToListAsync();

            var idsAgenda = agenda.Select(a => a.idBloque).ToList();

            if (!paciente) {
                var bloque = await sql2
                .Where(x => !idsAgenda.Contains(x.IdBloque) && x.FechaHora.Month == model.mes && x.FechaHora.Year == model.ano)
                .Select(x => new AgendaModel
                {
                    idBloque = x.IdBloque,
                    name = "Disponible",
                    start = x.FechaHora,
                    profesionalSalud = new ProfesionalSaludModel
                    {
                        nombre = x.ProfesionalSalud.Usuario.Paciente.NombrePrimer + " " + x.ProfesionalSalud.Usuario.Paciente.ApellidoPaterno + " " + x.ProfesionalSalud.Usuario.Paciente.ApellidoMaterno,
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
                    Estado = x.Estado,
                    Especialidad = x.especialidad.NombreEspecialidad,
                    IdEspecialidad = x.idEspecialidad
                }).ToListAsync();

                agenda.AddRange(bloque);
            }
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
                        idEspecialidad = parametros.idEspecialidad,
                        Estado = 1 // o el estado por defecto que corresponda
                    };

                    _context.Bloques.Add(nuevoBloque);
                    horaInicioBloque = horaFinBloque; // Preparar para el siguiente bloque
                }

                fechaActual = fechaActual.AddDays(1); // Mover al siguiente día
            }

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    return BadRequest("No se ha podido guardar al paciente");
                    throw;
                }
            }
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> agendar([FromBody] AgendarModel model) {

            if (!ModelState.IsValid) {
                return BadRequest("Datos invalidos");
            }

            var u = await _context.Usuarios.Where(x => x.Paciente.Run == model.rutUsuario).FirstOrDefaultAsync();
            var p = await _context.Pacientes.Where(x => x.Run == model.rutPaciente).FirstOrDefaultAsync();

            Agenda a = new Agenda { 
            
                IdUsuario = u.IdUsuario,
                IdBloque = model.idBloque,
                IdPaciente = p.IdPaciente,
                Estado = true
            };

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Agendas.Add(a);
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    return BadRequest("No se ha podido guardar al paciente");
                    throw;
                }
            }

            return Ok();
        }
    }
}
