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
    public partial class AgregarNuevoInventario : Form
    {
        Conexion conexion;
        public AgregarNuevoInventario()
        {
            InitializeComponent();
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

        private void cargarDatos()
        {
            conexion = new Conexion();
            MySqlConnection con = conexion.GetConnection();

            string consultaModelos = "SELECT * FROM modelo";
            MySqlDataAdapter adapterModelos = new MySqlDataAdapter(consultaModelos, con);
            DataTable dataModelos = new DataTable();
            adapterModelos.Fill(dataModelos);
            comboBoxModelo.DataSource = dataModelos;
            comboBoxModelo.ValueMember = "id_modelo";
            comboBoxModelo.DisplayMember = "nombre_modelo";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            conexion = new Conexion();
            MySqlConnection cone = conexion.GetConnection();

            try
            {
                string consulta = "insert into inventario (nombre_equipo ,modelo, numero_inventario, disponibilidad, id_tipo)" + "values (@nombre_equipo, @modelo,@numero_inventario, @disponibilidad, @id_tipo)";
                var cmd = new MySqlCommand(consulta, cone);

                int idTipo = 0;

                if (comboBox1.SelectedItem.ToString() == "Equipos")
                    idTipo = 2;
                else if (comboBox1.SelectedItem.ToString() == "Accesorios")
                    idTipo = 3;
                else
                {
                    MessageBox.Show("Selecciona un tipo válido");
                    return;
                }

                cmd.Parameters.AddWithValue("@nombre_equipo", txtNombre.Text);
                cmd.Parameters.AddWithValue("@modelo", comboBoxModelo.SelectedValue);
                cmd.Parameters.AddWithValue("@numero_inventario", txtNumeroIn.Text);
                cmd.Parameters.AddWithValue("@disponibilidad", txtDisponibilidad.Text);
                cmd.Parameters.AddWithValue("@id_tipo", idTipo);



                int filasAfectadas = cmd.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Registro de inventario exitoso");
                    Inventario inventario = new Inventario();
                    inventario.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Error al agregar nuevo inventario");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Inventario inventario = new Inventario();
            inventario.Show();
            this.Hide();
        }
    }
}
