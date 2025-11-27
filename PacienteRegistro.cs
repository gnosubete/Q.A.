using System.Windows.Forms;
using Clinica.Saludable.Datos;
using MySql.Data.MySqlClient;

namespace ClinicaSaludable
{
    public class PacienteService
    {
        private DatabaseConnection db = new DatabaseConnection();

        public bool Registrar(Paciente paciente)
        {
            try
            {
                using (var connection = db.GetConnection())
                {
                    connection.Open();

                    string query = @"INSERT INTO pacientes 
                                   (nombre_completo, rut, fecha_nacimiento, sexo_genero, direccion, 
                                    telefono_whatsapp, email, seguro, consentimiento_informado, autorizacion_whatsapp) 
                                   VALUES 
                                   (@nombre, @rut, @fecha, @sexo, @direccion, @telefono, 
                                    @email, @seguro, @consentimiento, @whatsapp)";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nombre", paciente.NombreCompleto);
                        cmd.Parameters.AddWithValue("@rut", paciente.Rut);
                        cmd.Parameters.AddWithValue("@fecha", paciente.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@sexo", paciente.SexoGenero);
                        cmd.Parameters.AddWithValue("@direccion", paciente.Direccion);
                        cmd.Parameters.AddWithValue("@telefono", paciente.TelefonoWhatsapp);
                        cmd.Parameters.AddWithValue("@email", paciente.Email);
                        cmd.Parameters.AddWithValue("@seguro", paciente.Seguro);
                        cmd.Parameters.AddWithValue("@consentimiento", paciente.ConsentimientoInformado);
                        cmd.Parameters.AddWithValue("@whatsapp", paciente.AutorizacionWhatsapp);

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error al registrar paciente");
                return false;
            }
        }
    }
}