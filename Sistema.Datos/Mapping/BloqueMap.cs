using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Estructura;

namespace Sistema.Datos.Mapping
{
    internal class BloqueMap : IEntityTypeConfiguration<Bloque>
    {
        public void Configure(EntityTypeBuilder<Bloque> builder)
        {
            builder.ToTable("Bloque")
                .HasKey(b => b.IdBloque);

        }
    }
}
