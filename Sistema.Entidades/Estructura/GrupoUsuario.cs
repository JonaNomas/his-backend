using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema.Entidades.Estructura
{
    public class GrupoUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdGrupoUsuario { get; set; }

        [ForeignKey(nameof(Usuario))]
        public int IdUsuario { get; set; }

        [ForeignKey(nameof(Grupo))]
        public int IdGrupo { get; set; }

        [Required]
        public byte Estado { get; set; }

        public Usuario Usuario { get; set; }
        public Grupo Grupo { get; set; }
    }
}
