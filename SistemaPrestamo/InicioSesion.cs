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
    public partial class InicioSesion : Form
    {
        Conexion conexion;
        public InicioSesion()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            conexion = new Conexion();
            MySqlConnection cone = conexion.GetConnection();

            try
            {
                string consulta = "select correo, contrasena from administrador where correo =@Correo AND contrasena =@contrasena";
                var cmd = new MySqlCommand(consulta, cone);

                cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text);
                cmd.Parameters.AddWithValue("@contrasena", txtContrasena.Text);

                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    MessageBox.Show("Inicio de sesión correcto, Bienvenido");
                    Menu men = new Menu();
                    men.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Correo o contraseña incorrecta");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }


        }

        private void chkMostrarContrasena_CheckedChanged(object sender, EventArgs e)
        {
            txtContrasena.UseSystemPasswordChar = !chkMostrarContrasena.Checked;
        }
    }
}
