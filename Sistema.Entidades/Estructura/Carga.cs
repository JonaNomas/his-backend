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
        [ForeignKey("Titular")]
        public int IdTitular { get; set; }

        [Required]
        [ForeignKey("PacienteCarga")]
        public int IdPacienteCarga { get; set; } 

        [Required]
        public DateTime FechaTermino { get; set; }

        [Required]
        public byte Estado { get; set; }

        public  Paciente Titular { get; set; }

        public Paciente PacienteCarga { get; set; }
    }
}
