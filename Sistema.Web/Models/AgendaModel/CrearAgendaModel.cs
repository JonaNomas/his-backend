namespace Sistema.Web.Models.AgendaModel
{
    public class CrearAgendaModel
    {
        public int duracion { get; set; }
        public int idProfesional { get; set; }
        public DateTime? inicio { get; set; }
        public DateTime? fin { get; set; }
        public TimeSpan? horaInicio { get; set; }
        public TimeSpan? horaFin { get; set; }
    }
}
