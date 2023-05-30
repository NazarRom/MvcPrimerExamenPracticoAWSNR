using Microsoft.EntityFrameworkCore;
using MvcPrimerExamenPracticoAWSNR.Models;

namespace MvcPrimerExamenPracticoAWSNR.Data
{
    public class CubosContext : DbContext
    {
        public CubosContext(DbContextOptions<CubosContext> options) : base(options) { }
        public DbSet<Cubo> Cubos { get; set; }
    }
}
