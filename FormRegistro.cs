using System;
using System.Drawing;
using System.Windows.Forms;
using Clinica.Saludable.Datos;
using MySql.Data.MySqlClient;

namespace ClinicaSaludable
{
    public partial class RegistroForm : Form
    {
        private DatabaseConnection dbConnection;

        public RegistroForm()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Registro de Paciente";
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                RegistrarPaciente();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtNombre.Text) ||
                string.IsNullOrEmpty(txtRut.Text) ||
                string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!checkConsentimiento.Checked)
            {
                MessageBox.Show("Debe aceptar el consentimiento informado", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void RegistrarPaciente()
        {
            using (var connection = dbConnection.GetConnection())
            {
                connection.Open();

                string query = @"INSERT INTO pacientes 
                               (nombre_completo, rut, fecha_nacimiento, sexo_genero, direccion, 
                                telefono_whatsapp, email, seguro, consentimiento_informado, autorizacion_whatsapp) 
                               VALUES 
                               (@nombre, @rut, @fecha_nac, @sexo, @direccion, @telefono, 
                                @email, @seguro, @consentimiento, @autorizacion_whatsapp)";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@rut", txtRut.Text);
                    cmd.Parameters.AddWithValue("@fecha_nac", dateNacimiento.Value);
                    cmd.Parameters.AddWithValue("@sexo", comboSexo.SelectedItem?.ToString());
                    cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                    cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@seguro", txtSeguro.Text);
                    cmd.Parameters.AddWithValue("@consentimiento", checkConsentimiento.Checked);
                    cmd.Parameters.AddWithValue("@autorizacion_whatsapp", checkWhatsApp.Checked);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Registro exitoso. Ahora puede iniciar sesión.", "Éxito",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Volver al login
                        LoginForm loginForm = new LoginForm();
                        loginForm.Show();
                        this.Close();
                    }
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }
    }
}
