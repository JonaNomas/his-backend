using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Estructura;

namespace Sistema.Datos.Mapping
{
    internal class GrupoUsuarioMap : IEntityTypeConfiguration<GrupoUsuario>
    {
        public void Configure(EntityTypeBuilder<GrupoUsuario> builder)
        {
            builder.ToTable("GrupoUsuario")
                .HasKey(gu => gu.IdGrupoUsuario);

            builder.HasOne(gu => gu.Usuario)
                .WithMany(u => u.GrupoUsuarios)
                .HasForeignKey(gu => gu.IdUsuario);

            builder.HasOne(gu => gu.Grupo)
                .WithMany(g => g.GrupoUsuarios)
                .HasForeignKey(gu => gu.IdGrupo);
        }
    }
}