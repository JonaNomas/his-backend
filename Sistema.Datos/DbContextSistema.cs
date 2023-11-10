using Microsoft.EntityFrameworkCore;
using Sistema.Datos.Mapping;
using Sistema.Entidades.Estructura;


namespace Sistema.Datos
{
    public  class DbContextSistema : DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Carga> Cargas { get; set; }


        public DbContextSistema(DbContextOptions<DbContextSistema> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PacienteMap());
            modelBuilder.ApplyConfiguration(new CargaMap());
        }

        }
}
