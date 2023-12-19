using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Entidades.Estructura
{
    public class ExamenLaboratorio
    {
        public int IdExamenLaboratorio { get; set; }
        public string Codigo { get; set; }

        [ForeignKey(nameof(TipoExamenLaboratorio))]
        public int IdTipoExamenLaboratorio { get; set;}
        public string Nombre { get; set; }
        public int ValorMinimo { get; set; }
        public int ValorMaximo { get; set; }
        public TipoExamenLaboratorio TipoExamenLaboratorio { get; set; }

    }
}
