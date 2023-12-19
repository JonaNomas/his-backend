namespace Sistema.Web.Models.AgendaModel
{
    public class AgendaModel
    {
        public int? idBloque { get; set; }
        public string? name {get; set;}
        public string? rutPaciente { get; set;}
        public DateTime?  start { get; set;}
        public ProfesionalSaludModel? profesionalSalud {get; set;}
        public ResponsableModel? responsable {get; set;}
        public DateTime? fechaCreacion { get; set; }
        public int? duracion { get; set; }
        public byte? Estado { get; set; }
        public string? Especialidad { get; set; }
        public int? IdEspecialidad { get; set; }
    }
}
