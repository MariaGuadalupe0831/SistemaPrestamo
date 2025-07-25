using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaPrestamo
{
    public partial class NuevoUsuario : Form
    {
        Conexion conexion;
        public NuevoUsuario()
        {
            InitializeComponent();
        }

        private void btnInicio_Click_1(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            Inventario inventario = new Inventario();
            inventario.Show();
            this.Hide();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            GestionUsuario usuario = new GestionUsuario();
            usuario.Show();
            this.Hide();
        }

        private void btnPrestamos_Click(object sender, EventArgs e)
        {
            GestionPrestamo prestamo = new GestionPrestamo();
            prestamo.Show();
            this.Hide();
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            HistorialPrestamo historial = new HistorialPrestamo();
            historial.Show();
            this.Hide();
        }

        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            conexion = new Conexion();
            MySqlConnection cone = conexion.GetConnection();

            try
            {
                string consulta = "insert into usuarios (nombre, apellido_p ,apellido_m, Matricula, correo, telefono, tipo_usuario)" + "values (@nombre, @apellido_p, @apellido_m,@Matricula, @correo, @telefono, @tipo_usuario)";
                var cmd = new MySqlCommand(consulta, cone);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@apellido_p", txtApellidoP.Text);
                cmd.Parameters.AddWithValue("@apellido_m", txtApellidoMa.Text);
                cmd.Parameters.AddWithValue("@Matricula", txtMatricula.Text);
                cmd.Parameters.AddWithValue("@correo", txtCorreo.Text);
                cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@tipo_usuario", cmbTipoUsuario.Text);
                int filasAfectadas = cmd.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Registro exitoso");
                    GestionUsuario usuario = new GestionUsuario();
                    usuario.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Error al agregar nuevo registro");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            GestionUsuario usuario = new GestionUsuario();
            usuario.Show();
            this.Hide();
        }
    }
}
