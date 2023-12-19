using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Entidades.Estructura
{
    public class Laboratorio
    {
        public int IdLaboratorio { get; set; }

        [ForeignKey(nameof(Paciente))]
        public int IdPaciente { get; set; }
        public DateTime FechaHora { get; set; }

        [ForeignKey(nameof(Usuario))]
        public int IdUsuario { get; set; }
        public Paciente Paciente { get; set; }
        public Usuario Usuario { get; set;}
        public ICollection<ResultadosExamenes> ResultadosExamenes { get; set; }
    }
}
