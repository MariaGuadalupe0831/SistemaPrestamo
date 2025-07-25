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
    public partial class GestionPrestamo : Form
    {
        Conexion conexion;
        public GestionPrestamo()
        {
            InitializeComponent();
            cargaDatos();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void btnAgregarPrestamo_Click(object sender, EventArgs e)
        {
            NuevoPrestamo nuevoPrestamo = new NuevoPrestamo();
            nuevoPrestamo.Show();
            this.Hide();
        }

        private void cargaDatos()
        {
            conexion = new Conexion();
            MySqlConnection cone = conexion.GetConnection();
            try
            {
                string consulta = "SELECT pre.`id_prestamo`, us.`nombre`, us.`apellido_p`,us.`apellido_m`, us.`Matricula`,us.`tipo_usuario`, us.`telefono`, us.`correo`, inv.`nombre_equipo`\r\nFROM prestamos pre\r\nINNER JOIN usuarios us\r\nON pre.`id_usuario` = us.`id_usuario`\r\nINNER JOIN `inventario` inv\r\nON pre.`id_equipo` = inv.`id_equipo`";
                var cmd = new MySqlCommand(consulta, cone);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                // Mostrar datos en el DataGridView
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
