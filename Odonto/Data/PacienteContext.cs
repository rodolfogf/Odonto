using Microsoft.EntityFrameworkCore;
using Odonto.Models;

namespace Odonto.Data
{
    public class PacienteContext : DbContext
    {
        public PacienteContext(DbContextOptions<PacienteContext> opts) : base(opts)
        {
            
        }
        public DbSet<Paciente> Pacientes { get; set; }
    }
}
