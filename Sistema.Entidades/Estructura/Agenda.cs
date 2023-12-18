using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema.Entidades.Estructura
{
    public class Agenda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAgenda { get; set; }

        [ForeignKey(nameof(Usuario))]
        public int IdUsuario { get; set; }

        [ForeignKey(nameof(Bloque))]
        public int IdBloque { get; set; }

        [Required]
        public bool Estado { get; set; }

        [ForeignKey(nameof(Paciente))]
        public int IdPaciente { get; set; }

        public Usuario Usuario { get; set; }
        public Bloque Bloque { get; set; }
        public Paciente Paciente { get; set; }
    }
}
