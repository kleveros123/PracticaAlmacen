using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PracticaAlmacen.Models
{
    class ConexionDB
    {
        static private string cadenaConexion = "Data Source=DESKTOP-O68LK3D;Initial Catalog=almacen;User=sa;Password=123456";
        //static private string cadenaConexion = "Data Source=DESKTOP-O68LK3D;Initial Catalog=almacen;Integrated Security=true";
        private SqlConnection conexion = new SqlConnection(cadenaConexion);
        public SqlConnection abrirConexion()
        {
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();
            return conexion;
        }
        public SqlConnection cerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
            return conexion;
        }
    }
}
