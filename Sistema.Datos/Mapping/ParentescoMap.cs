using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Estructura;

namespace Sistema.Datos.Mapping
{
    internal class ParentescoMap : IEntityTypeConfiguration<Parentesco>
    {
        public void Configure(EntityTypeBuilder<Parentesco> builder)
        {
            builder.ToTable("Parentesco")
                .HasKey(p => p.IdParentesco);

            // Si hay relaciones adicionales para Parentesco, se pueden configurar aquí
        }
    }
}
