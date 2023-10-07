using System.Security.Claims;
using APIMidway.Data;
using Microsoft.EntityFrameworkCore;


namespace APIMidway.Models
{
    public class Jwt
    {
        public string Key { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;

        public static dynamic ValidarToken(ClaimsIdentity identity)
        {   
            
            try
            {
                if(identity.Claims.Count() == 0)
                {
                    return new
                    {
                        success = false,
                        message = "Verificar si estás enviando un token válido",
                        result = ""
                    };
                }
                

                var UPN = identity.Claims.FirstOrDefault(x => x.Type == "UPN").Value;
                
                using var context = new DataContext(new DbContextOptions<DataContext>());
                var usuario = context.Empleados.FirstOrDefaultAsync(x => x.UPN == UPN);

                return new
                {
                    success = true,
                    message = "Éxito",
                    result = usuario
                };

                
            }
            catch (Exception ex)
            {
                return new
                {
                    success = false,
                    message = "Catch: " + ex.Message,
                    result= ""
                };
            }
        }

    }
}