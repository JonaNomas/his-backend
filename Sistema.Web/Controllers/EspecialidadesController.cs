using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Sistema.Datos;
using Sistema.Entidades.Estructura;
using Sistema.Web.Models.EspecialidadModel;

namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadesController : ControllerBase
    {

        private readonly DbContextSistema _context;
        private readonly IConfiguration _config;

        // Constructor unificado
        public EspecialidadesController(DbContextSistema context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> obtenerEspecialidades() {

            var sql = await _context.Especialidades.Select(x => new EspecialidadModel { 
                id = x.IdEspecialidad,
                nombre = x.NombreEspecialidad,
            }).ToListAsync();

            return Ok(sql);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> crearEspecialidad([FromBody] CrearEspecialidadModel model) {

            var sql = await _context.Especialidades.Where(x => x.NombreEspecialidad.ToUpper() == model.nombre.ToUpper()).AnyAsync();

            if (sql) {
                return BadRequest("Ya existe una especialidad con ese nombre");
            }

            Especialidad e = new Especialidad {
                NombreEspecialidad = model.nombre
            };

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // Código que modifica el contexto
                    await _context.Especialidades.AddAsync(e);
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch
                {
                    // Si hay una excepción, el rollback se realiza aquí
                    transaction.Rollback();
                    return BadRequest("No se ha podido guardar la especialidad");
                    throw;
                }
            }

            return Ok();
        
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> obtenerEspecialidadesPorId([FromRoute] int id)
        {

            var sql = await _context.Especialidades.Where(x => x.IdEspecialidad == id).Select(x => new EspecialidadModel
            {
                id = x.IdEspecialidad,
                nombre = x.NombreEspecialidad,
            }).FirstOrDefaultAsync();

            return Ok(sql);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ActualizarEspecialidad([FromBody] EspecialidadModel model) {

            if (model.nombre == " " || model.nombre.IsNullOrEmpty()) {
                return BadRequest("El nombre no puede estar vacio");
            }

            var sql = await _context.Especialidades.Where(x => x.IdEspecialidad == model.id).FirstOrDefaultAsync();

            sql.NombreEspecialidad = model.nombre;

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
                    return BadRequest("No se ha podido actualizar la especialidad");
                    throw;
                }
            }

            return Ok();
        }

    }
}
