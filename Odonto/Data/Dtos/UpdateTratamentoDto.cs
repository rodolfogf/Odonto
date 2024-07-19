﻿using Odonto.Models;
using System.ComponentModel.DataAnnotations;

namespace Odonto.Data.Dtos
{
    public class UpdateTratamentoDto
    {
        [Required]
        public int PacienteId { get; set; }
        public virtual Paciente Paciente { get; set; }
        [Required]
        public string TipoTratamento { get; set; }
    }
}
