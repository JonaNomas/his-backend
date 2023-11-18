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


        [HttpGet("[action]")]
        public async Task<IActionResult> ListarPacientes()
        {
            var lista = await _context.Pacientes.Select(x => new {  asdasdsadsa = x.NombrePrimer, uuid = x.PacienteUUID}).ToListAsync();

            return Ok(lista);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ListarCargas()
        {
            var lista = await _context.Cargas.Where(x => x.IdCarga ==1 || x.IdCarga == 2).ToListAsync();
            return Ok(lista);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ListarParentescos()
        {
            var lista = await _context.Parentescos.ToListAsync();
            return Ok(lista);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ListarEspecialidades()
        {
            var lista = await _context.Especialidades.ToListAsync();
            return Ok(lista);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ListarGrupos()
        {
            var lista = await _context.Grupos.ToListAsync();
            return Ok(lista);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ListarUsuarios()
        {
            var lista = await _context.Usuarios.ToListAsync();
            return Ok(lista);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ListarProfesionalesSalud()
        {
            var lista = await _context.ProfesionalesSalud.ToListAsync();
            return Ok(lista);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ListarGrupoUsuarios()
        {
            var lista = await _context.GrupoUsuarios.ToListAsync();
            return Ok(lista);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ListarProfesionalesSaludEspecialidades()
        {
            var lista = await _context.ProfesionalesSaludEspecialidades.ToListAsync();
            return Ok(lista);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ListarBloques()
        {
            var lista = await _context.Bloques.ToListAsync();
            return Ok(lista);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ListarAgendas()
        {
            var lista = await _context.Agendas.ToListAsync();
            return Ok(lista);
        }


    }
}
