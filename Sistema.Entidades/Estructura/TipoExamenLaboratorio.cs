using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Entidades.Estructura
{
    public class TipoExamenLaboratorio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idTipoExamenLaboratorio { get; set; }
        public string nombre { get; set; }
        public ICollection<ExamenLaboratorio> examenLaboratorios { get; set; }
    }
}
