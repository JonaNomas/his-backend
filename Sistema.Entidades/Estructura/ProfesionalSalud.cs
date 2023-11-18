using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema.Entidades.Estructura
{
    public class ProfesionalSalud
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProfesionalSalud { get; set; }

        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }

        [Required]
        public byte Estado { get; set; }

        public Usuario Usuario { get; set; }

        public ICollection<ProfesionalSaludEspecialidad> ProfesionalSaludEspecialidades { get; set; }
        public ICollection<Bloque> Bloques { get; set; }
    }
}
