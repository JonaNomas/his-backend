using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema.Entidades.Estructura
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }

        [ForeignKey(nameof(Paciente))]
        public int? IdPaciente { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Correo { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Password { get; set; }

        [Required]
        public bool? Estado { get; set; }

        public Paciente? Paciente { get; set; }

        public ICollection<ProfesionalSalud> ProfesionalSalud { get; set; }
        public ICollection<GrupoUsuario> GrupoUsuarios { get; set; }
        public ICollection<Agenda> Agendas { get; set; }
    }
}
