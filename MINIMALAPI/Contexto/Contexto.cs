using Microsoft.EntityFrameworkCore;
using MINIMALAPI.Entidades;

namespace MINIMALAPI.Contexto
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) => Database.EnsureCreated();

        public DbSet<Produto> Produto { get; set; }
    }
}
