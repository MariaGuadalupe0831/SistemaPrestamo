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
    public partial class Inventario : Form
    {
        Conexion conexion;
        public Inventario()
        {
            InitializeComponent();
            cargarDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Inventario inventario = new Inventario();
            inventario.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GestionUsuario usuario = new GestionUsuario();
            usuario.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GestionPrestamo prestamo = new GestionPrestamo();
            prestamo.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            HistorialPrestamo historial = new HistorialPrestamo();
            historial.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AgregarNuevoInventario nuevoInventario = new AgregarNuevoInventario();
            nuevoInventario.Show();
            this.Hide();
        }
        private void comboBoxSeleccionar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seleccion = comboBoxSeleccionar.SelectedItem.ToString();
            string filtro = "";
            if (seleccion == "Equipo de Computo")
                filtro = "WHERE tp.nombre_tipo = 'Equipo de Computo'";
            else if (seleccion == "Accesorio")
                filtro = "WHERE tp.nombre_tipo = 'Accesorio'";
            cargarDatos(filtro);
        }


        private void cargarDatos(string filtro = "")
        {
            conexion = new Conexion();

            MySqlConnection cone = conexion.GetConnection();
            try
            {
                string consulta = "SELECT i.id_equipo,i.nombre_equipo, mo.`nombre_modelo`, ma.`nombre_marca`,i.numero_inventario, i.disponibilidad, tp.nombre_tipo\r\nFROM inventario i\r\nINNER JOIN tipo_equipo tp\r\nON i.id_tipo = tp.id_tipo\r\nINNER JOIN modelo mo\r\nON i.`modelo` = mo.`id_modelo`\r\nINNER JOIN marca ma\r\nON mo.`id_marca` = ma.`id_marca`" + filtro;
                var cmd = new MySqlCommand(consulta, cone);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                dgvDataInventario.DataSource = tabla;
                cone.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
