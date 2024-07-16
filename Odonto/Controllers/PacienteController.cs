using Microsoft.AspNetCore.Mvc;
using Odonto.Data;
using Odonto.Models;

namespace Odonto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacienteController : ControllerBase
    {

        private PacienteContext _context;
        public PacienteController(PacienteContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionaPaciente([FromBody] Paciente paciente)
        {
                _context.Pacientes.Add(paciente);
                _context.SaveChanges();
                return CreatedAtAction(
                    nameof(RetornaParcientePorId), 
                    new {id = paciente.Id}, 
                    paciente);
                
        }

        [HttpGet]
        public IEnumerable<Paciente> RetornaPacientes([FromQuery] int skip = 0,[FromQuery] int take = 10)
        {
            return _context.Pacientes.Skip(skip).Take(take);
        }

        [HttpGet("{id}")]
        public IActionResult? RetornaParcientePorId(int id)
        {
            var paciente = _context.Pacientes.FirstOrDefault(p => p.Id == id);
            if (paciente == null) return NotFound();
            return Ok(paciente);
        }

    }
}
