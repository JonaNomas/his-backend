using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Estructura;

namespace Sistema.Datos.Mapping
{
    internal class ProfesionalSaludEspecialidadMap : IEntityTypeConfiguration<ProfesionalSaludEspecialidad>
    {
        public void Configure(EntityTypeBuilder<ProfesionalSaludEspecialidad> builder)
        {
            builder.ToTable("ProfesionalSaludEspecialidad")
                .HasKey(pse => pse.IdProfesionalSaludEspecialidad);

            builder.HasOne(pse => pse.ProfesionalSalud)
                .WithMany(ps => ps.ProfesionalSaludEspecialidades)
                .HasForeignKey(pse => pse.IdProfesionalSalud);

            builder.HasOne(pse => pse.Especialidad)
                .WithMany(e => e.ProfesionalSaludEspecialidades)
                .HasForeignKey(pse => pse.IdEspecialidad);
        }
    }
}
