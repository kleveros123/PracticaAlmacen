using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PracticaAlmacen.Models
{
    class ProductosModel
    {
        //Atributos
        private int id;
        private string descripcion;
        private decimal precio;
        private int idCategoria;
        private int idMarca;

        //Propiedades
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int IdCategoria { get; set; }
        public int IdMarca { get; set; }

        private ConexionDB conexion = new ConexionDB();
        private SqlCommand comando = new SqlCommand();
        private SqlDataReader leerDatos;

        public DataTable mostrarCategorias()
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "Select * from categorias";
            //comando.CommandType = CommandType.StoredProcedure; //Si utiliza SP
            leerDatos = comando.ExecuteReader();
            tabla.Load(leerDatos);
            leerDatos.Close();
            conexion.cerrarConexion();
            return tabla;
        }
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
        public DataTable mostrarProductos()
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "select p.id, m.marca, c.categoria, p.descripcion, p.precio " +
                                    "from productos p " +
                                    "inner join marcas m on p.idmarca = m.id " +
                                    "inner join categorias c on p.idcategoria = c.id ";
            //comando.CommandType = CommandType.StoredProcedure; //Si utiliza SP
            leerDatos = comando.ExecuteReader();
            tabla.Load(leerDatos);
            leerDatos.Close();
            conexion.cerrarConexion();
            return tabla;
        }
        public void insertarProducto()
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "Insert into productos (descripcion, precio, idcategoria, idmarca) " +
                "values(@descripcion, @precio, @idCategoria, @idMarca)";
            comando.Parameters.AddWithValue("@descripcion", Descripcion);
            comando.Parameters.AddWithValue("@precio", Precio);
            comando.Parameters.AddWithValue("@idCategoria", IdCategoria);
            comando.Parameters.AddWithValue("@idMarca", IdMarca);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
        public void editarProducto()
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "update productos set idmarca=@idMarca, " +
                "idcategoria=@idCategoria, descripcion=@Descripcion, precio=@Precio " +
                "where id = @idProducto";
            comando.CommandType = CommandType.Text;
            comando.Parameters.AddWithValue("@idMarca", IdMarca);
            comando.Parameters.AddWithValue("@idCategoria", IdCategoria);
            comando.Parameters.AddWithValue("@Descripcion", Descripcion);
            comando.Parameters.AddWithValue("@Precio", Precio);
            comando.Parameters.AddWithValue("@idProducto", Id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrarConexion();
        }
        public void eliminarProducto()
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "delete from productos where id =" + this.Id;
            comando.ExecuteNonQuery();
            conexion.cerrarConexion();
        }
    }
}
