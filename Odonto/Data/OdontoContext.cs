using Microsoft.EntityFrameworkCore;
using Odonto.Models;

namespace Odonto.Data;

public class OdontoContext : DbContext
{
    public OdontoContext(DbContextOptions<OdontoContext> opts) : base(opts)
    {

    }
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Tratamento> Tratamentos { get; set; }
}