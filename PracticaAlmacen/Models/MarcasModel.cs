using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PracticaAlmacen.Models
{
    class MarcasModel
    {
        //Atributos
        private int id;
        private string marca;

        //Propiedades
        public int Id{ get; set; }
        public string Marca { get; set; }

        private ConexionDB conexion = new ConexionDB();
        private SqlCommand comando = new SqlCommand();
        private SqlDataReader leerDatos;

        public DataTable mostrarMarcas()
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "Select * from marcas"; //puede incluir un SP
            //comando.CommandType = CommandType.StoredProcedure; //Si utiliza SP
            leerDatos = comando.ExecuteReader();
            tabla.Load(leerDatos);
            leerDatos.Close();
            conexion.cerrarConexion();
            return tabla;
        }
        public void insertarMarca()
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "Insert into marcas (marca) " +
                "values(@marca)";
            comando.Parameters.AddWithValue("@marca", Marca);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
        public void editarMarca()
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "update marcas set marca=@marca " +
                "where id = @idMarca";
            comando.CommandType = CommandType.Text;
            comando.Parameters.AddWithValue("@marca", Marca);
            comando.Parameters.AddWithValue("@idMarca", Id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrarConexion();
        }
        public void eliminarMarca()
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "delete from marcas where id =" + this.Id;
            comando.ExecuteNonQuery();
            conexion.cerrarConexion();
        }
    }
}
