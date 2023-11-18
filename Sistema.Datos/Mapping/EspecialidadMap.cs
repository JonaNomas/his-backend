using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Estructura;


namespace Sistema.Datos.Mapping
{
    internal class EspecialidadMap : IEntityTypeConfiguration<Especialidad>
    {
        public void Configure(EntityTypeBuilder<Especialidad> builder)
        {
            builder.ToTable("Especialidad")
                .HasKey(e => e.IdEspecialidad);

        }
    }
}
