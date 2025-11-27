using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Clinica.Saludable.Datos
{
    public class DatabaseConnection
    {
        private string connectionString = "Server=127.0.0.1;Database=clinicasaludable;Uid=root;Pwd=;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
        public bool TestConnection()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
