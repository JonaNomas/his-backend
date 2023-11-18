using Microsoft.EntityFrameworkCore;
using Sistema.Datos.Mapping;
using Sistema.Entidades.Estructura;


namespace Sistema.Datos
{
    public  class DbContextSistema : DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Carga> Cargas { get; set; }
        public DbSet<Parentesco> Parentescos { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ProfesionalSalud> ProfesionalesSalud { get; set; }
        public DbSet<GrupoUsuario> GrupoUsuarios { get; set; }
        public DbSet<ProfesionalSaludEspecialidad> ProfesionalesSaludEspecialidades { get; set; }
        public DbSet<Bloque> Bloques { get; set; }
        public DbSet<Agenda> Agendas { get; set; }


        public DbContextSistema(DbContextOptions<DbContextSistema> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PacienteMap());
            modelBuilder.ApplyConfiguration(new CargaMap());
            modelBuilder.ApplyConfiguration(new ParentescoMap());
            modelBuilder.ApplyConfiguration(new EspecialidadMap());
            modelBuilder.ApplyConfiguration(new GrupoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new ProfesionalSaludMap());
            modelBuilder.ApplyConfiguration(new GrupoUsuarioMap());
            modelBuilder.ApplyConfiguration(new ProfesionalSaludEspecialidadMap());
            modelBuilder.ApplyConfiguration(new BloqueMap());
            modelBuilder.ApplyConfiguration(new AgendaMap());
        }

        }
}
