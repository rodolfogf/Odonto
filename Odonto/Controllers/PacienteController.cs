using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Odonto.Data;
using Odonto.Data.Dtos;
using Odonto.Models;

namespace Odonto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacienteController : ControllerBase
    {

        private PacienteContext _context;
        private IMapper _mapper;
        public PacienteController(PacienteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaPaciente([FromBody] CreatePacienteDto pacienteDto)
        {
                Paciente paciente = _mapper.Map<Paciente>(pacienteDto);
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
