using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Sistema.Entidades.Estructura
{
    public class Especialidad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEspecialidad { get; set; }

        [Required]
        [MaxLength(50)]
        public string NombreEspecialidad { get; set; }

        // Relaciones
        public virtual ICollection<ProfesionalSaludEspecialidad> ProfesionalSaludEspecialidades { get; set; }
    }

}
