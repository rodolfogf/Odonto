using System.ComponentModel.DataAnnotations;

namespace Odonto.Models
{
    public class Tratamento
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string TipoTratamento { get; set; }
        [Required] 
        public int PacienteId { get; set; }
        public virtual Paciente Paciente { get; set; }

    }
}
