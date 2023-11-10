using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Sistema.Entidades.Estructura
{
    public class Grupo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdGrupo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        public byte Estado { get; set; }

        // Relaciones
        public ICollection<GrupoUsuario> GrupoUsuarios { get; set; }
    }
}
