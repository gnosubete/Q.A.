using System;

namespace ClinicaSaludable
{
    public class Paciente
    {
        public string NombreCompleto { get; set; }
        public string Rut { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string SexoGenero { get; set; }
        public string Direccion { get; set; }
        public string TelefonoWhatsapp { get; set; }
        public string Email { get; set; }
        public string Seguro { get; set; }
        public bool ConsentimientoInformado { get; set; }
        public bool AutorizacionWhatsapp { get; set; }
    }
}
