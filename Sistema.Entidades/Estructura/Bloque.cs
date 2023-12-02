using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema.Entidades.Estructura
{
    public class Bloque
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdBloque { get; set; }

        [ForeignKey(nameof(ProfesionalSalud))]
        public int IdProfesionalSalud { get; set; }

        [Required]
        public DateTime FechaHora { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        [Required]
        public int Duracion { get; set; }

        [Required]
        public Byte Estado { get; set; }

        public ProfesionalSalud ProfesionalSalud { get; set; }
        public ICollection<Agenda> Agendas { get; set; }
    }
}
