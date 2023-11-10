using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Sistema.Entidades.Estructura
{
    public class Parentesco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdParentesco { get; set; }

        [Required]
        [MaxLength(50)]
        public string DescripcionParentesco { get; set; }

        // Relaciones
        public ICollection<Paciente> Pacientes { get; set; }
    }
}
