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
                Sexo = model.Sexo,
            };

            _context.Pacientes.Add(p);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) {

                return BadRequest(ex);
            }

            return Ok();
        
        }

    }
}
