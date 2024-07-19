using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Odonto.Data;
using Odonto.Data.Dtos;
using Odonto.Models;

namespace Odonto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TratamentoController : ControllerBase
    {
        private OdontoContext _context;
        private IMapper _mapper;

        public TratamentoController(OdontoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaTratamento(CreateTratamentoDto tratamentoDto)
        {
            Tratamento tratamento = _mapper.Map<Tratamento>(tratamentoDto);
            _context.Tratamentos.Add(tratamento);
            _context.SaveChanges();

            return CreatedAtAction(
                nameof(RetornaTratamentoPorId),
                new { id = tratamento.Id },
                tratamento);

        }

        [HttpGet]
        public IEnumerable<ReadTratamentoDto> RetornaTratamentos([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            return _mapper.Map<List<ReadTratamentoDto>>(_context.Tratamentos.Skip(skip).Take(take));
        }

        [HttpGet]
        public IActionResult RetornaTratamentoPorId(int id)
        {
            var tratamento = _context.Tratamentos.FirstOrDefault(t => t.Id == id);
            if (tratamento == null) return NotFound();

            return Ok(tratamento);
        }

        [HttpPatch]
        IActionResult AtualizaTratamentoParcial(int id, JsonPatchDocument<UpdateTratamentoDto> patch)
        {
            var tratamento = _context.Tratamentos.FirstOrDefault(t => t.Id == id);
            if (tratamento == null) return NotFound();

            var tratamentoAtualizacao = _mapper.Map<UpdateTratamentoDto>(tratamento);
            patch.ApplyTo(tratamentoAtualizacao, ModelState);

            if (!TryValidateModel(tratamentoAtualizacao)) return ValidationProblem(ModelState);

            _mapper.Map(tratamentoAtualizacao, tratamento);
            _context.SaveChanges();

            return NoContent();

        }

        [HttpDelete]
        public IActionResult DeletaTratamento(int id)
        {
            var tratamento = _context.Tratamentos.FirstOrDefault(t => t.Id == id);
            if (tratamento == null) return NotFound();

            _context.Remove(tratamento);
            _context.SaveChanges();

            return NoContent();
        }




    }
}
