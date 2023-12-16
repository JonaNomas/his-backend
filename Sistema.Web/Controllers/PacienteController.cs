using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Estructura;
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


        [HttpPost("[action]")]
        public async Task<IActionResult> obtenerPaciente([FromBody] PacienteVerificarModel model)
        {
            var sql = await _context.Pacientes.Where(x => x.Run == model.rut).FirstOrDefaultAsync();

            return Ok(sql);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> crearPaciente([FromBody] PacienteRegistroModel model) {

            var sql = await _context.Pacientes.Where(x => x.Run == model.rut).FirstOrDefaultAsync();

            if (sql != null) { 
                return BadRequest("El paciente ya existe");
            }

            Paciente p = new Paciente{ 
                PacienteUUID = Guid.NewGuid(),
                Run = model.rut,
                NombrePrimer = model.NombrePrimer,
                NombreSegundo = model.NombreSegundo,
                ApellidoMaterno = model.ApellidoMaterno,
                ApellidoPaterno = model.ApellidoPaterno,
                ContactoEmergencia = model.ContactoEmergencia,
                Correo = model.Correo,
                Donador = model.Donador,
                Direccion  = model.Direccion,
                Telefono = model.Telefono,
                Prevision = model.Prevision,
                FechaNacimiento = model.FechaNacimiento,
                IdParentesco = 6,
                Sexo = model.Sexo.ToString(),
                TelefonoEmergencia = model.TelefonoEmergencia,
                GrupoSanguineo = model.GrupoSanguineo,
                EstadoCivil = model.EstadoCivil,
                NombreSocial = model.NombreSocial,
            };

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // Código que modifica el contexto
                    await _context.Pacientes.AddAsync(p);
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch
                {
                    // Si hay una excepción, el rollback se realiza aquí
                    transaction.Rollback();
                    return BadRequest("No se ha podido guardar al paciente");
                    throw;
                }
            }

            return Ok("Paciente creado");
        
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ActualizarPaciente([FromBody] PacienteRegistroModel model) {

            var sql = await _context.Pacientes.Where(x => x.Run == model.rut).FirstOrDefaultAsync();

            sql.NombrePrimer = model.NombrePrimer;
            sql.NombreSegundo = model.NombreSegundo;
            sql.Correo = model.Correo;
            sql.Sexo = model.Sexo.ToString();
            sql.ApellidoMaterno = model.ApellidoMaterno;
            sql.ApellidoPaterno = model.ApellidoPaterno;
            sql.Telefono = model.Telefono;
            sql.Prevision = model.Prevision;
            sql.TelefonoEmergencia = model.TelefonoEmergencia;
            sql.ContactoEmergencia = model.ContactoEmergencia;
            sql.Direccion = model.Direccion;
            sql.NombreSocial = model.NombreSocial;
            sql.Donador = model.Donador;
            sql.Correo = model.Correo;

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // Código que modifica el contexto
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch
                {
                    // Si hay una excepción, el rollback se realiza aquí
                    transaction.Rollback();
                    return BadRequest("No se ha podido actualizar al paciente");
                    throw;
                }
            }

            return Ok();
        }

    }
}
