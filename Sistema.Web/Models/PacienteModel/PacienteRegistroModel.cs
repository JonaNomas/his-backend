namespace Sistema.Web.Models.PacienteModel
{
    public class PacienteRegistroModel
    {
        public string? rut { get; set; }

        public string? NombrePrimer { get; set; }

        public string? NombreSegundo { get; set; }

        public string? ApellidoPaterno { get; set; }

        public string? ApellidoMaterno { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public string? Telefono { get; set; }

        public string? Direccion { get; set; }

        public string? Correo { get; set; }

        public string? ContactoEmergencia { get; set; }

        public int? IdParentesco { get; set; }

        public string? TelefonoEmergencia { get; set; }

        public string? GrupoSanguineo { get; set; }

        public bool? Donador { get; set; }

        public string? Prevision { get; set; }

        public string? EstadoCivil { get; set; }

        public string? Sexo { get; set; }

        public string? NombreSocial { get; set; }

        public int? EstadoSalud { get; set; }

        public DateTime? FechaDefuncion { get; set; }
    }
}
