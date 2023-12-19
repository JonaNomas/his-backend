using Sistema.Entidades.Estructura;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema.Web.Models.LaboratorioModel
{
    public class ExamenLaboratorioModel
    {
        public int IdExamenLaboratorio { get; set; }
        public string Codigo { get; set; }
        public int IdTipoExamenLaboratorio { get; set; }
        public string NombreTipoExamenLaboratorio { get; set; }
        public string Nombre { get; set; }
        public int ValorMinimo { get; set; }
        public int ValorMaximo { get; set; }
    }
}
