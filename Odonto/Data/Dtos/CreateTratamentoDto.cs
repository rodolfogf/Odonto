using Odonto.Models;
using System.ComponentModel.DataAnnotations;

namespace Odonto.Data.Dtos
{
    public class CreateTratamentoDto
    {
        public int PacienteId { get; set; }
        public string TipoTratamento { get; set; }
    }
}
