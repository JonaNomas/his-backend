using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sistema.Entidades.Estructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Datos.Mapping
{
    internal class ExamenLaboratorioMap : IEntityTypeConfiguration<ExamenLaboratorio>
    {
        public void Configure(EntityTypeBuilder<ExamenLaboratorio> builder)
        {
            builder.ToTable("ExamenLaboratorio")
                .HasKey(g => g.IdExamenLaboratorio);
        }
    }
}
