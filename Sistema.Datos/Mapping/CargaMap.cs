using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Entidades.Estructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Datos.Mapping
{
    internal class CargaMap : IEntityTypeConfiguration<Carga>
    {
        public void Configure(EntityTypeBuilder<Carga> builder)
        {
            builder.ToTable("Carga")
                .HasKey(c => c.IdCarga);

            builder.HasOne(c => c.Titular)
                .WithMany(t => t.CargasTitular)
                .HasForeignKey(c => c.IdTitular)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.PacienteCarga)
                .WithMany(t => t.CargasCarga)
                .HasForeignKey(c => c.IdPacienteCarga)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
