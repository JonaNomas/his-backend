using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Estructura;

namespace Sistema.Datos.Mapping
{
    internal class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario")
                .HasKey(u => u.IdUsuario);

            builder.HasOne(u => u.Paciente)
                .WithOne(p => p.Usuario)
                .HasForeignKey<Usuario>(u => u.IdPaciente);

            // Configuraciones adicionales para Usuario
        }
    }
}
