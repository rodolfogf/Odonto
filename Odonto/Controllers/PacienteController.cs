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
        public void AdicionaPaciente([FromBody] Paciente paciente)
        {
            paciente.Id = id++;
            pacientes.Add(paciente);
            Console.WriteLine(paciente.Nome);
        }

        [HttpGet]
        public IEnumerable<Paciente> RetornaPacientes()
        {
            return pacientes;
        }

        [HttpGet("{id}")]
        public Paciente? RetornaParcientePorId(int id)
        {
            return pacientes.FirstOrDefault(p => p.Id == id);
        }

    }
}
