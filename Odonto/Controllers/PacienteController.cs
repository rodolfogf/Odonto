using Microsoft.AspNetCore.Mvc;
using Odonto.Models;

namespace Odonto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacienteController : ControllerBase
    {
        private static List<Paciente> pacientes = new List<Paciente>();
        [HttpPost]
        public void AdicionaPaciente([FromBody] Paciente paciente)
        {
            pacientes.Add(paciente);
            Console.WriteLine(paciente.Nome);
        }

    }
}
