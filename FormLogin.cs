using System;
using System.Drawing;
using System.Windows.Forms;
using Clinica.Saludable.Datos;
using Clinica.Saludable.Vistas;
using MySql.Data.MySqlClient;

namespace ClinicaSaludable
{
    public partial class LoginForm : Form
    {
        private DatabaseConnection dbConnection;

        public LoginForm()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Clínica Saludable - Login";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string rut = txtRut.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(rut) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, complete todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (ValidarUsuario(rut, password))
                {
                    MessageBox.Show("Login exitoso", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FormLogin mainForm = new FormLogin();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("RUT o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarUsuario(string rut, string password)
        {
            using (var connection = dbConnection.GetConnection())
            {
                connection.Open();

                string queryPacientes = @"SELECT id FROM pacientes 
                                        WHERE rut = @rut AND consentimiento_informado = 1 
                                        LIMIT 1";

                using (var cmd = new MySqlCommand(queryPacientes, connection))
                {
                    cmd.Parameters.AddWithValue("@rut", rut);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return true; 
                    }
                }


                string queryMedicos = @"SELECT id FROM medicos 
                                      WHERE rut = @rut AND activo = 1 
                                      LIMIT 1";

                using (var cmd = new MySqlCommand(queryMedicos, connection))
                {
                    cmd.Parameters.AddWithValue("@rut", rut);
                    var result = cmd.ExecuteScalar();
                    if (result != null) return true;
                }

                string queryAdmins = @"SELECT id FROM administradores 
                                     WHERE rut = @rut AND activo = 1 
                                     LIMIT 1";

                using (var cmd = new MySqlCommand(queryAdmins, connection))
                {
                    cmd.Parameters.AddWithValue("@rut", rut);
                    var result = cmd.ExecuteScalar();
                    if (result != null) return true;
                }


                string querySecretaria = @"SELECT id FROM secretaria 
                                         WHERE usuario = @rut 
                                         LIMIT 1";

                using (var cmd = new MySqlCommand(querySecretaria, connection))
                {
                    cmd.Parameters.AddWithValue("@rut", rut);
                    var result = cmd.ExecuteScalar();
                    if (result != null) return true;
                }

                return false;
            }
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            FormRegistro registroForm = new FormRegistro();
            registroForm.Show();
            this.Hide();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Probar conexión al cargar el formulario
            if (!dbConnection.TestConnection())
            {
                MessageBox.Show("No se pudo conectar a la base de datos. Verifique la conexión.", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
