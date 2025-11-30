using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clinica_de_salud;

namespace Clinica_de_salud.Vistas
{
    public partial class FormRegistrosPacientes : Form
    {
        public FormRegistrosPacientes()
        {
            InitializeComponent();
            LimpiarCampos();
            cmbseso.Items.Add("masculino");
            cmbseso.Items.Add("femenino");
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtrut.Text = string.Empty;
            txtcontraseña.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            dtpfe.Value = DateTime.Today;
            txttipoSangre.Text = string.Empty;
            cmbseso.Text = string.Empty;
            txtpre.Text = string.Empty;
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string rut = txtrut.Text.Trim();
            string contraseña = txtcontraseña.Text.Trim();
            DateTime fecha = dtpfe.Value;
            string sexo = cmbseso.Text.Trim();
            string direccion = txtDireccion.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string email = txtCorreo.Text.Trim();
            string prevision = txtpre.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(contraseña) || string.IsNullOrEmpty(sexo) || string.IsNullOrEmpty(direccion))
            {
                MessageBox.Show("Todos los campos son obligatorios", "Validación", MessageBoxButtons.OK);
                return;
            }

            string rol_usuario = "paciente";
            string contraseñaAdo = BCrypt.Net.BCrypt.HashPassword(contraseña);

            try
            {
                using (var conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    string queryPacientes = "INSERT INTO pacientes (nombre_completo, rut, fecha_nacimiento, sexo_genero, direccion, telefono, email, sistema_salud, fecha_registro) VALUES (@nombre_completo, @rut, @fecha_nacimiento, @sexo_genero, @direccion, @telefono, @email, @sistema_salud, @fecha_registro)";

                    MySqlCommand cmdPacientes = new MySqlCommand(queryPacientes, conn);
                    cmdPacientes.Parameters.AddWithValue("@nombre_completo", nombre);
                    cmdPacientes.Parameters.AddWithValue("@rut", rut);
                    cmdPacientes.Parameters.AddWithValue("@fecha_nacimiento", fecha);
                    cmdPacientes.Parameters.AddWithValue("@sexo_genero", sexo);
                    cmdPacientes.Parameters.AddWithValue("@direccion", direccion);
                    cmdPacientes.Parameters.AddWithValue("@telefono", telefono);
                    cmdPacientes.Parameters.AddWithValue("@email", email);
                    cmdPacientes.Parameters.AddWithValue("@sistema_salud", prevision);
                    cmdPacientes.Parameters.AddWithValue("@fecha_registro", DateTime.Now);

                    cmdPacientes.ExecuteNonQuery();

                    string queryUsuarios = "INSERT INTO usuarios (rut, nombre, email, password, rol) VALUES (@rutUsuario, @nombreUsuario, @emailUsuario, @password, @rol)";

                    MySqlCommand cmdUsuarios = new MySqlCommand(queryUsuarios, conn);
                    cmdUsuarios.Parameters.AddWithValue("@rutUsuario", rut);
                    cmdUsuarios.Parameters.AddWithValue("@nombreUsuario", nombre);
                    cmdUsuarios.Parameters.AddWithValue("@emailUsuario", email);
                    cmdUsuarios.Parameters.AddWithValue("@password", contraseñaAdo);
                    cmdUsuarios.Parameters.AddWithValue("@rol", rol_usuario);

                    cmdUsuarios.ExecuteNonQuery();
                    MessageBox.Show("Registro completo", "Éxito", MessageBoxButtons.OK);
                    LimpiarCampos();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrio un error ado: {ex.Message}", "Error", MessageBoxButtons.OK);
            }
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            MessageBox.Show("Da solicitud de degisto se cancedo", "valicacion", MessageBoxButtons.OK);
            this.Close();
        }
    }
}

