using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Sistema.Datos;
using Sistema.Web.Models.UsuarioModel;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly DbContextSistema _context;
        private readonly IConfiguration _config;

        // Constructor unificado
        public UsuarioController(DbContextSistema context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginModel model) {

            LoginRespuesta resp = new LoginRespuesta
            {

                login = false,
                token = ""
            };

            string passwordTemp = "admin";

            var sql = await _context.Usuarios.Where(x => x.Paciente.Run == model.rut).Select(x => new { 
            
                    nombre = x.Paciente.NombrePrimer+" "+x.Paciente.ApellidoPaterno+" "+x.Paciente.ApellidoMaterno,
                    correo = x.Correo,
                    idUsuario = x.IdUsuario,
                    Uuid = x.Paciente.PacienteUUID.ToString(),

            }).FirstOrDefaultAsync();

            var grupos = await _context.GrupoUsuarios.Where(y => y.IdUsuario == sql.idUsuario).Select(y => new
            {
                nombre = y.Grupo.Nombre,
                id = y.IdUsuario

            }).ToListAsync();


            if (sql == null) {
                return Ok(resp);
            }

            var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Name, sql.nombre),
                    new Claim(JwtRegisteredClaimNames.NameId, sql.Uuid),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            foreach (var g in grupos) {

                claims.Add(new Claim(ClaimTypes.Role, g.nombre));
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

            resp.token = token;
            resp.login = true;

            return Ok(resp);
        }


    }
}
