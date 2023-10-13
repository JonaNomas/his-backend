using Microsoft.AspNetCore.Mvc;
using Sistema.Datos;
using Sistema.Entidades.Usuario;
using Sistema.Web.Models.Users;
using Sistema.Web.Models.UsuarioModel;

namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly DbContextSistema _context;

        public UserController(DbContextSistema context)
        {
            _context = context;
        }
        // POST: api/<UserController>
        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginModel model )
        {      

            return Ok(_context.Usuarios.ToList());
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Registro([FromBody] UsuarioRegistroModel model) {


            Usuario user = new Usuario {
            
                nombre = model.nombre,
                primer_apellido = model.primer_apellido,
                segundo_apellido = model.segundo_apellido,
            };

            _context.Usuarios.Add(user);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) { 
            
                return BadRequest(ex.Message);
            }

            return Ok(model);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Listar()
        {

            return Ok(_context.Usuarios.ToList());

        }


        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Listar([FromRoute]int id) {

            return Ok(_context.Usuarios.Where(x => x.id == id).FirstOrDefault());
        
        }
    
    }
}
