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
    internal class AgendaMap : IEntityTypeConfiguration<Agenda>
    {
        public void Configure(EntityTypeBuilder<Agenda> builder)
        {
            builder.ToTable("Agenda")
                .HasKey(a => a.IdAgenda);

            builder.HasOne(a => a.Usuario)
                .WithMany(u => u.Agendas)
                .HasForeignKey(a => a.IdUsuario);

            builder.HasOne(a => a.Bloque)
                .WithMany(b => b.Agendas)
                .HasForeignKey(a => a.IdBloque);

        }
    }
}
