using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema.Entidades.Estructura
{
    public class Paciente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPaciente { get; set; }

        public Guid PacienteUUID { get; set; }

        [MaxLength(10)]
        public string? Run { get; set; }

        [MaxLength(50)]
        public string? NombrePrimer { get; set; }

        [MaxLength(50)]
        public string? NombreSegundo { get; set; }

        [MaxLength(50)]
        public string? ApellidoPaterno { get; set; }

        [MaxLength(50)]
        public string? ApellidoMaterno { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        [MaxLength(10)]
        public string? Telefono { get; set; }

        [MaxLength(100)]
        public string? Direccion { get; set; }

        [MaxLength(100)]
        public string? Correo { get; set; }

        [MaxLength(100)]
        public string? ContactoEmergencia { get; set; }

        [ForeignKey(nameof(Parentesco))]
        public int? IdParentesco { get; set; }

        [MaxLength(10)]
        public string? TelefonoEmergencia { get; set; }

        [MaxLength(3)]
        public string? GrupoSanguineo { get; set; }

        [Required]
        public bool? Donador { get; set; }

        [MaxLength(50)]
        public string? Prevision { get; set; }

        [MaxLength(50)]
        public string? EstadoCivil { get; set; }

        [Required]
        [MaxLength(1)]
        public string? Sexo { get; set; }

        [MaxLength(100)]
        public string? NombreSocial { get; set; }

        public int? EstadoSalud { get; set; }

        public DateTime? FechaDefuncion { get; set; }

        public Parentesco Parentesco { get; set; }

        public Usuario Usuario { get; set; }

        public ICollection<Carga> CargasTitular { get; set; }
        public ICollection<Carga> CargasCarga { get; set; }
        public ICollection<Bloque> Bloque { get; set; }
        public ICollection<Laboratorio> Laboratorios { get; set; }
    }

}
