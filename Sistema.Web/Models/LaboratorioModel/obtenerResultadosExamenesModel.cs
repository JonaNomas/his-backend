using Sistema.Entidades.Estructura;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema.Web.Models.LaboratorioModel
{
    public class obtenerResultadosExamenesModel
    {
        public int IdResultadosExamenes { get; set; }
        public int IdLaboratotio { get; set; }
        public int IdExamenLaboratorio { get; set; }
        public string Resulatdo { get; set; }
    }
}
