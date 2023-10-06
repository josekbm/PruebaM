using Microsoft.EntityFrameworkCore;
using APIMidway.Models;

namespace APIMidway.Data
{
    public class DataContext : DbContext //Cuidado al escribir ":"
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {            
        }
        public DbSet<Empleado> Empleados { get; set; }
    }
}