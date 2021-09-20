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
    public partial class Marcas : Form
    {
        string operacion = "insertar";
        int id;
        public Marcas()
        {
            InitializeComponent();
        }
        private void Marcas_Load(object sender, EventArgs e)
        {
            listarMarcas();
        }
        private void listarMarcas()
        {
            MarcasModel oMarca = new MarcasModel();
            dataGridView1.DataSource = oMarca.mostrarMarcas();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            MarcasModel oMarca = new MarcasModel();
            oMarca.Marca = txtMarca.Text;
            if (operacion == "insertar")
            {
                oMarca.insertarMarca();
                MessageBox.Show("Registro Insertado correctamente");
            }
            else if (operacion == "editar")
            {
                oMarca.Id = id;
                oMarca.editarMarca();
                operacion = "insertar";
                MessageBox.Show("Registro Actualizado correctamente");
            }
            listarMarcas();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                operacion = "editar";
                txtMarca.Text = dataGridView1.CurrentRow.Cells["marca"].Value.ToString();
                id = int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila");
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                MarcasModel oMarca = new MarcasModel();
                oMarca.Id = int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
                oMarca.eliminarMarca();
            }
            listarMarcas();
        }
    }
}
