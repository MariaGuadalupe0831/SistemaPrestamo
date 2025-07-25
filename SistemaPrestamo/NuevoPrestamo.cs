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
    public partial class NuevoPrestamo : Form
    {
        Conexion conexion;
        private int idUsuario = -1;
        public NuevoPrestamo()
        {
            InitializeComponent();

            datePrestamo.MinDate = DateTime.Today;
            dateDevolucion.MinDate = datePrestamo.Value;
            cargarDatos();
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
            string consultaModelos = "SELECT * FROM inventario";
            MySqlDataAdapter adapterModelos = new MySqlDataAdapter(consultaModelos, con);
            DataTable dataModelos = new DataTable();
            adapterModelos.Fill(dataModelos);
            comboBoxPrestamo.DataSource = dataModelos;
            comboBoxPrestamo.ValueMember = "id_equipo";
            comboBoxPrestamo.DisplayMember = "nombre_equipo";
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            conexion = new Conexion();
            MySqlConnection cone = conexion.GetConnection();
            try
            {
                string consulta = "select id_usuario,nombre, apellido_p, apellido_m,Matricula from usuarios where matricula =@matricula";
                var cmd = new MySqlCommand(consulta, cone);
                cmd.Parameters.AddWithValue("@matricula", txtMatricula.Text);
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    MessageBox.Show("Usuario encontrado");
                    idUsuario = Convert.ToInt32(reader["id_usuario"]);
                    string nombre = reader["nombre"].ToString();
                    string apellidoP = reader["apellido_p"].ToString();
                    string apellidoM = reader["apellido_m"].ToString();

                    txtNombre.Text = nombre + " " + apellidoP + " " + apellidoM;
                }
                else
                {
                    MessageBox.Show("usuario no encontrado");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            conexion = new Conexion();
            MySqlConnection cone = conexion.GetConnection();
            try
            {
                string consulta = "INSERT INTO prestamos (id_admin, id_usuario, id_equipo, fecha_prestamo, fecha_devolucion, estado_prestamo, observaciones) VALUES (1, @id_usuario, @id_equipo, @fecha_prestamo, @fecha_devolucion, @estado_prestamo, @observaciones)";
                var cmd = new MySqlCommand(consulta, cone);
                cmd.Parameters.AddWithValue("@id_usuario", idUsuario);
                cmd.Parameters.AddWithValue("@id_equipo", comboBoxPrestamo.SelectedValue);
                cmd.Parameters.AddWithValue("@fecha_prestamo", DateTime.Now);
                cmd.Parameters.AddWithValue("@fecha_devolucion", dateDevolucion.Value);
                cmd.Parameters.AddWithValue("@estado_prestamo", "EN PROCESO");
                cmd.Parameters.AddWithValue("@observaciones", txtObservaciones.Text);

                int filasAfectadas = cmd.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Registro de inventario exitoso");
                    GestionPrestamo gestionPre = new GestionPrestamo();
                    gestionPre.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Error al agregar nuevo inventario");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            GestionPrestamo prestamo = new GestionPrestamo();
            prestamo.Show();
            this.Hide();
        }
    }
}
