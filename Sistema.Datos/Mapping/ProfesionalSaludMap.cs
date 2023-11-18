using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Estructura;

namespace Sistema.Datos.Mapping
{
    internal class ProfesionalSaludMap : IEntityTypeConfiguration<ProfesionalSalud>
    {
        public void Configure(EntityTypeBuilder<ProfesionalSalud> builder)
        {
            builder.ToTable("ProfesionalSalud")
                .HasKey(ps => ps.IdProfesionalSalud);

            

        }
    }
}
