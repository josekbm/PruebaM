using System.ComponentModel.DataAnnotations;

namespace APIMidway.Models
{
    public class Empleado
    {
        [Key]
        public string UPN { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public string Responsable { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
    }
}