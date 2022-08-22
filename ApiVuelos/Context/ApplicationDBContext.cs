using ApiVuelos.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ApiVuelos.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VuelosCiudades>()
                .HasKey(x => new { x.VueloId, x.CiudadId });

            modelBuilder.Entity<VuelosAerolinea>()
                .HasKey(x=> new {x.VueloId, x.AerolineaId});

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Ciudad> ciudades { get; set; }
        public DbSet<Aerolinea> aerolinea { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Vuelo> vuelos { get; set; }
        public DbSet<VuelosCiudades> vuelosCiudades { get; set; }
        public DbSet<VuelosAerolinea> vuelosAerolinea { get; set; }
    }
}
