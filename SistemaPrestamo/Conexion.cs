using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaPrestamo
{
    /*EQUIPO 4  3° "A"
    20241047 Hernandez Tomas Maria Guadalupe
    20241031 Romero Hernandez Jesus Diego
    20241059 Gomez JR Carlos Alberto
    20241091 Medellin Gonzalez Israel*/
    class Conexion
    {
        //declaramos la cadena de coneccion para poder conectar con la base 
        //de datos
        private string cadenaConeccion;

        public Conexion()
        {
            cadenaConeccion = "Server=127.0.0.1; Database=sistemaprestamostic´s;Uid=root;Pwd=;Port=3306;";

        }

        public MySqlConnection GetConnection()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(cadenaConeccion);
                con.Open();
                return con;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar a la base de datos: " + ex.Message);
                return null;
            }
        }
    }

}
