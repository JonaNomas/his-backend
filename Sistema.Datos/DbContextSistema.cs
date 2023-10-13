using Microsoft.EntityFrameworkCore;
using Sistema.Datos.Mapping.Usuarios;
using Sistema.Entidades.Usuario;


namespace Sistema.Datos
{
    public  class DbContextSistema : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public DbContextSistema(DbContextOptions<DbContextSistema> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }

        }
}
