using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema.Entidades.Estructura
{
    public class Carga
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCarga { get; set; } 

        [Required]
        public int IdTitular { get; set; }

        [Required]
        public int IdPacienteCarga { get; set; } 

        [Required]
        public DateTime FechaTermino { get; set; }

        [Required]
        public byte Estado { get; set; }

        [ForeignKey("IdTitular")]
        public virtual Paciente Titular { get; set; }

        [ForeignKey("IdPacienteCarga")]
        public virtual Paciente PacienteCarga { get; set; }
    }
}
