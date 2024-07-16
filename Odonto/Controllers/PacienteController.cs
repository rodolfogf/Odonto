using Microsoft.AspNetCore.Mvc;
using Odonto.Models;

namespace Odonto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacienteController : ControllerBase
    {
        private static List<Paciente> pacientes = new List<Paciente>();
        private static int id = 0;
        [HttpPost]
        public IActionResult AdicionaPaciente([FromBody] Paciente paciente)
        {
            paciente.Id = id++;
            pacientes.Add(paciente);
            return CreatedAtAction(nameof(RetornaParcientePorId), 
                new {id = paciente.Id}, 
                paciente);
        }

        [HttpGet]
        public IEnumerable<Paciente> RetornaPacientes([FromQuery] int skip = 0,[FromQuery] int take = 10)
        {
            return pacientes.Skip(skip).Take(take);
        }

        [HttpGet("{id}")]
        public IActionResult? RetornaParcientePorId(int id)
        {
            var paciente = pacientes.FirstOrDefault(p => p.Id == id);
            if (paciente == null) return NotFound();
            return Ok(paciente);
        }

    }
}
