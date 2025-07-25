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
    public partial class GestionUsuario : Form
    {
        Conexion conexion;
        public GestionUsuario()
        {
            InitializeComponent();
            llenargrid();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }

        private void btnInventario_Click_1(object sender, EventArgs e)
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            NuevoUsuario nuevoUsuario = new NuevoUsuario();
            nuevoUsuario.Show();
            this.Hide();
        }

        public void llenargrid()
        {

            conexion = new Conexion();
            MySqlConnection cone = conexion.GetConnection();
            try
            {
                string consulta = "select * from usuarios";
                var cmd = new MySqlCommand(consulta, cone);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                dataGridView1.DataSource = tabla;
                cone.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
