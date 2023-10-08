using APIMidway.Models;
using APIMidway.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using APIMidway.Controllers;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.Text;


namespace APIMidway.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext _context;
        public IConfiguration _configuration;
        public UsuarioController(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
                
        [HttpPost]
        [Route("login")]
        public async Task<dynamic> Login([FromBody] dynamic login)
        {   try 
            {
                var data = JsonConvert.DeserializeObject<dynamic>(login.ToString());

                string user = data.UPN.ToString();
                string password = data.password.ToString();

                using var context = new DataContext(new DbContextOptions<DataContext>());
                var usuario = await _context.Empleados.FirstOrDefaultAsync(x => x.UPN == user && x.password == password);

                if (usuario == null)
                {
                    return new { success = false, message = "Credenciales inválidas" };
                }

                var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
                var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UPN", usuario.UPN),
                    new Claim("Nombre", usuario.Nombre),
                    new Claim("Apellidos", usuario.Apellidos),
                    
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
                var singIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    jwt.Issuer,
                    jwt.Audience,
                    claims,
                    //expires: DateTime.Now.AddMinutes(120), Descomentar para añadir tiempo de expiración al token a partir de su emisión.
                    signingCredentials: singIn
                );
                return new 
                {   
                    success = true,
                    upn = usuario.UPN,
                    nombre = usuario.Nombre,
                    apellidos = usuario.Apellidos,
                    message = "Exito", 
                    result = new JwtSecurityTokenHandler().WriteToken(token)
                };
            }
            catch (Exception ex)
            {
                return new { success = false, message ="Error: " + ex.Message };
            }
            

           
        }
        
    }
}