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
    internal class LaboratorioMap : IEntityTypeConfiguration<Laboratorio>
    {
        public void Configure(EntityTypeBuilder<Laboratorio> builder)
        {
            builder.ToTable("Laboratorio")
                .HasKey(g => g.IdLaboratorio);
        }
    }
}