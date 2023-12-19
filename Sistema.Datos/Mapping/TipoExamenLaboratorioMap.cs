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
    internal class TipoExamenLaboratorioMap : IEntityTypeConfiguration<TipoExamenLaboratorio>
    {
        public void Configure(EntityTypeBuilder<TipoExamenLaboratorio> builder)
        {
            builder.ToTable("TipoExamenLaboratorio")
                .HasKey(g => g.idTipoExamenLaboratorio);
        }
    }
}