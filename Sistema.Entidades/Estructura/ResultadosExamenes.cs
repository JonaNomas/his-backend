using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Entidades.Estructura
{
    public class ResultadosExamenes
    {
        public int IdResultadosExamenes { get; set; }

        [ForeignKey(nameof(Laboratorio))]
        public int IdLaboratotio { get; set; }

        [ForeignKey(nameof(ExamenLaboratorio))]
        public int IdExamenLaboratorio { get; set; }
        public string Resulatdo { get; set; }
        public ExamenLaboratorio ExamenLaboratorio { get; set; }
        public Laboratorio Laboratorio { get; set; }
    }
}
