using Odonto.Models;
using System.ComponentModel.DataAnnotations;

namespace Odonto.Data.Dtos;

public class UpdateTratamentoDto
{
   public int PacienteId { get; set; }
   public string TipoTratamento { get; set; }
}
