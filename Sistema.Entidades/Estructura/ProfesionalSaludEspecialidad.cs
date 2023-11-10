using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema.Entidades.Estructura
{
    public class ProfesionalSaludEspecialidad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProfesionalSaludEspecialidad { get; set; }

        [ForeignKey(nameof(ProfesionalSalud))]
        public int IdProfesionalSalud { get; set; }

        [ForeignKey(nameof(Especialidad))]
        public int IdEspecialidad { get; set; }

        public ProfesionalSalud ProfesionalSalud { get; set; }
        public Especialidad Especialidad { get; set; }
    }
}
