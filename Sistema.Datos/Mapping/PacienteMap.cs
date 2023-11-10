using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Estructura;

namespace Sistema.Datos.Mapping
{
    internal class PacienteMap : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("Paciente")
                .HasKey(i => i.IdPaciente);
        }
    }
}