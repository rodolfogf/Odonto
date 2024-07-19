using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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

        private OdontoContext _context;
        private IMapper _mapper;
        public PacienteController(OdontoContext context, IMapper mapper)
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
                new { id = paciente.Id },
                paciente);

        }

        [HttpGet]
        public IEnumerable<ReadPacienteDto> RetornaPacientes([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            return _mapper.Map<List<ReadPacienteDto>>(_context.Pacientes.Skip(skip).Take(take));
        }

        [HttpGet("{id}")]
        public IActionResult? RetornaParcientePorId(int id)
        {
            var paciente = _context.Pacientes.FirstOrDefault(p => p.Id == id);
            if (paciente == null) return NotFound();
            var pacienteDto = _mapper.Map<ReadPacienteDto>(paciente);
            return Ok(pacienteDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaPaciente(int id, [FromBody] UpdatePacienteDto pacienteDto)
        {
            var paciente = _context.Pacientes.FirstOrDefault(p => p.Id == id);
            if (paciente == null) return NotFound();
            _mapper.Map(pacienteDto, paciente);
            _context.SaveChanges();

            return NoContent();            
        }
        
        [HttpPatch("{id}")]
        public IActionResult AtualizaPacienteParcial(int id, JsonPatchDocument<UpdatePacienteDto> patch)
        {
            var paciente = _context.Pacientes.FirstOrDefault(p => p.Id == id);
            if (paciente == null) return NotFound();

            var pacienteAtualizacao = _mapper.Map<UpdatePacienteDto>(paciente);
            patch.ApplyTo(pacienteAtualizacao, ModelState);

            if (!TryValidateModel(pacienteAtualizacao)) return ValidationProblem(ModelState);
           
            _mapper.Map(pacienteAtualizacao, paciente);
            _context.SaveChanges();

            return NoContent();            
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaPaciente(int id)
        {
            var paciente = _context.Pacientes.FirstOrDefault(p => p.Id == id);
            if (paciente == null) return NotFound();

            _context.Remove(paciente);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
