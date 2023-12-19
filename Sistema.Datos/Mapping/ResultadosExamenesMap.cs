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
    internal class ResultadosExamenesMap : IEntityTypeConfiguration<ResultadosExamenes>
    {
        public void Configure(EntityTypeBuilder<ResultadosExamenes> builder)
        {
            builder.ToTable("ResultadosExamenes")
                .HasKey(g => g.IdResultadosExamenes);
        }
    }
}