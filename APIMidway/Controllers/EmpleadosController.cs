using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using APIMidway.Data;
using APIMidway.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;




namespace APIMidway.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    
    public class EmpleadosController : ControllerBase
    {
        private readonly ILogger<EmpleadosController> _logger;
        private readonly DataContext _context;
        public EmpleadosController(ILogger<EmpleadosController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }
        //implementar métodos httpget
        [HttpGet(Name = "GetEmpleados")]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleados()
        {
            return await _context.Empleados.ToListAsync();
        }
        //implementar httpget("{upn}", Name = "GetEmpleado")
        [HttpGet("{UPN}", Name = "GetEmpleado")]
        public async Task<ActionResult<Empleado>> GetEmpleado(string UPN)
        {
            var empleado = await _context.Empleados.FindAsync(UPN);
            if (empleado == null)
            {
                return NotFound($"Empleado con UPN '{UPN}' no encontrado en la base de datos.");
            }
            return empleado;                
            
        }
        
        //implementar httppost
        [HttpPost]
        public async Task<ActionResult<Empleado>> Post(string password, Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetEmpleado", new { UPN = empleado.UPN }, empleado);
        }
        
        //implementar httpput("{UPN}") 
        [HttpPut("{UPN}")]
        public async Task<ActionResult> Put(string UPN, string password, Empleado empleado)
        {
            if (UPN != empleado.UPN)
            {
                return BadRequest();
            }
           
            _context.Entry(empleado).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok("User updated successfully");
        }
        //implementar httpdelete("{UPN}")
        [HttpDelete("{UPN}")]
        public async Task<ActionResult<Empleado>> Delete(string UPN)
        {
                      
            var empleado = await _context.Empleados.FindAsync(UPN);
            if (empleado == null)
            {
                return NotFound();
            }

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();

            return Ok("User deleted successfully");
        }
    }
}