using APIMidway.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIMidway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        public dynamic Login([FromBody] Object login)
        {
            var data = JsonConvert.DeserializeObject<dynamic>(login.ToString());
            
            string user = data.UPN.ToString();
            string password = data.password.ToString();

            Empleado 
        }
    }
}