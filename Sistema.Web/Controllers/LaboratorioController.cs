using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Estructura;
using Sistema.Web.Models.LaboratorioModel;

namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaboratorioController : ControllerBase
    {
        private readonly DbContextSistema _context;
        private readonly IConfiguration _config;

        // Constructor unificado
        public LaboratorioController(DbContextSistema context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> obtenerTipoExamenLaboratorio() {

            var sql = await _context.TipoExamenLaboratorios
                .Select(x => new obtenerTipoExamenLaboratorioModel
                {
                    nombre = x.nombre,
                    idTipoExamenLaboratorio = x.idTipoExamenLaboratorio
                }).ToArrayAsync();

            return Ok(sql);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> obtenerExamenLaboratorio() {

            var sql = await  _context.ExamenLaboratorios
                .Select(x => new ExamenLaboratorioModel { 
                    Codigo = x.Codigo,
                    IdExamenLaboratorio = x.IdExamenLaboratorio,
                    IdTipoExamenLaboratorio = x.IdTipoExamenLaboratorio,
                    NombreTipoExamenLaboratorio = x.TipoExamenLaboratorio.nombre,
                    Nombre = x.Nombre,
                    ValorMaximo = x.ValorMaximo,
                    ValorMinimo = x.ValorMinimo
                }).ToListAsync();

            return Ok(sql);
        }

        [HttpGet("[action]/{idLaboratorio}")]
        public async Task<IActionResult> obtenerResultadosExamenes([FromRoute] int idLaboratorio) {

            var sql = await _context.ResultadosExamenes.Where(x => x.IdLaboratotio == idLaboratorio)
                .Select(x => new obtenerResultadosExamenesModel{ 
                    IdExamenLaboratorio = x.IdExamenLaboratorio,
                    IdLaboratotio = x.IdLaboratotio,
                    IdResultadosExamenes = x.IdResultadosExamenes,
                    Resulatdo = x.Resulatdo
            }).ToListAsync();

            return Ok(sql);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> obtenerLaboratioPorRut([FromBody] ObtenerLaboratorioPorRutModel model) {

            var sql = await _context.Laboratorios.Where(x => x.Paciente.Run == model.rut).ToListAsync();

            return Ok(sql);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> crearLaboratioPorRut([FromBody] CrearLaboratorioModel model)
        {
            var u = await _context.Usuarios.Where(x => x.Paciente.Run == model.rutUsuario).FirstOrDefaultAsync();
            var p = await _context.Pacientes.Where(x => x.Run == model.rutPaciente).FirstOrDefaultAsync();

            Laboratorio l = new Laboratorio {
                IdPaciente = p.IdPaciente,
                IdUsuario = u.IdUsuario,
                FechaHora = DateTime.Now
            };

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // Código que modifica el contexto
                    await _context.Laboratorios.AddAsync(l);
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch
                {
                    // Si hay una excepción, el rollback se realiza aquí
                    transaction.Rollback();
                    return BadRequest("No se ha podido guardar el laboratorio");
                    throw;
                }
            }

            return Ok();
        }

    }
}
