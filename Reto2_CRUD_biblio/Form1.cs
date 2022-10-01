using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Capa_Entidad;
using Capa_Negocio;

namespace Reto2_CRUD_biblio
{
    public partial class Form1 : Form
    {
        ClassEntidad objent = new ClassEntidad();
        ClassNegocio objneg = new ClassNegocio();

        public Form1()
        {
            InitializeComponent();
        }

        void mantenimiento(string accion)

        {
            objent.codigo = txtid.Text;
            objent.accion = accion;
            objent.titulo = txttitulo.Text;
            objent.autor = txtautor.Text;
            objent.editorial = txteditorial.Text;
            objent.precio = Convert.ToInt32(txtprecio.Text);
            objent.cantidad = Convert.ToInt32(txtcantidad.Text);

            string men = objneg.N_mantenimiento_libros(objent);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        void limpiar()
        {
            txtautor.Text = "";
            txtbuscar.Text = "";
            txtcantidad.Text = "";
            txteditorial.Text = "";
            txtprecio.Text = "";
            txttitulo.Text = "";
            dataGridView1.DataSource = objneg.N_listar_libros();
        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {
            dataGridView1.DataSource = objneg.N_listar_libros();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentCell.RowIndex;
            txtid.Text = dataGridView1[0, fila].Value.ToString();
            txttitulo.Text = dataGridView1[1, fila].Value.ToString();
            txtautor.Text = dataGridView1[2, fila].Value.ToString();
            txteditorial.Text = dataGridView1[3, fila].Value.ToString();
            txtprecio.Text = dataGridView1[4, fila].Value.ToString();
            txtcantidad.Text = dataGridView1[5, fila].Value.ToString();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "")
            {
                if (MessageBox.Show("Desea registrar el libro " + txttitulo.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("1");
                    limpiar();
                }
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "")
            {
                if (MessageBox.Show("Desea modificar el libro " + txttitulo.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("2");
                    limpiar();
                }
            }

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "")
            {
                if (MessageBox.Show("Desea eliminar el libro " + txttitulo.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("3");
                    limpiar();
                }
            }
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            if(txtbuscar.Text != "")
            {
                objent.titulo= txtbuscar.Text;
                DataTable dt = new DataTable();
                dt = objneg.N_buscar_libros(objent);
                dataGridView1.DataSource = dt;
            }
            else
            {
                dataGridView1.DataSource = objneg.N_listar_libros();
            }
        }
    }
}