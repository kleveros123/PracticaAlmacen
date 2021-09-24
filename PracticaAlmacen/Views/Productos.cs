using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PracticaAlmacen.Models;
namespace PracticaAlmacen.Views
{
    public partial class Productos : Form
    {
        string operacion = "insertar";
        int id;
        public Productos()
        {
            InitializeComponent();
        }
        private void Productos_Load(object sender, EventArgs e)
        {
            listarCategorias();
            listarMarcas();
            listarProductos();
        }
        private void listarCategorias()
        {
            ProductosModel oProducto = new ProductosModel();
            cmbCategoria.DataSource = oProducto.mostrarCategorias();
            cmbCategoria.ValueMember = "id";
            cmbCategoria.DisplayMember = "categoria";
        }
        private void listarMarcas()
        {
            ProductosModel oProducto = new ProductosModel();
            cmbMarca.DataSource = oProducto.mostrarMarcas();
            cmbMarca.ValueMember = "id";
            cmbMarca.DisplayMember = "marca";
        }

        private void listarProductos()
        {
            ProductosModel oProducto = new ProductosModel();
            dataGridView1.DataSource = oProducto.mostrarProductos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
                ProductosModel oProducto = new ProductosModel();
                oProducto.IdMarca = int.Parse(cmbMarca.SelectedValue.ToString());
                oProducto.IdCategoria = int.Parse(cmbCategoria.SelectedValue.ToString());
                oProducto.Descripcion = txtDescripcion.Text;
                oProducto.Precio = decimal.Parse(txtPrecio.Text);
            if (operacion == "insertar")
            {
                oProducto.insertarProducto();
                MessageBox.Show("Registro Insertado correctamente");
            }
            else if(operacion == "editar")
            {
                oProducto.Id = id;
                oProducto.editarProducto();
                operacion = "insertar";
                MessageBox.Show("Registro Actualizado correctamente");
            }
            //MessageBox.Show(cmbCategoria.SelectedValue.ToString());
            listarProductos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                operacion = "editar";
                cmbCategoria.Text = dataGridView1.CurrentRow.Cells["categoria"].Value.ToString();
                cmbMarca.Text = dataGridView1.CurrentRow.Cells["marca"].Value.ToString();
                txtDescripcion.Text = dataGridView1.CurrentRow.Cells["descripcion"].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells["precio"].Value.ToString();
                id = int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila");
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                ProductosModel oProducto = new ProductosModel();
                oProducto.Id = int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
                oProducto.eliminarProducto();
            }
            listarProductos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Marcas oVentanaMarca = new Marcas();
            oVentanaMarca.ShowDialog();
            //oVentanaMarca.
            if ( !oVentanaMarca.Visible )
                listarMarcas();
        }
    }
}
