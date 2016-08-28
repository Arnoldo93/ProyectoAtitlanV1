using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace PROYECTO_PROATITLAN
{
    public partial class Categoria : Form
    {
        public Categoria()
        {
            InitializeComponent();
        }
        string familia;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "")
                {
                    var c = new DCategoriaDesecho();
                    c.Id_Categoria = Convert.ToInt32(textBox1.Text);
                    c.Nombre = textBox2.Text;
                    c.Id_Familia = Convert.ToInt32(familia);

                    if (NCategoriaDesecho.Agregar(c))
                    {
                        MessageBox.Show("Datos guardados correctamente", "Aviso");
                        limpiar();
                        id_categoria();
                        ListaCategorias(); ;
                        ListaFamilias();
                    }
                    else
                    {
                        MessageBox.Show("Error", "Aviso");
                    }
                }

                else
                {
                    MessageBox.Show("Error", "Aviso");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var c = new DCategoriaDesecho();
                c.Id_Categoria = Convert.ToInt32(textBox1.Text);
                c.Nombre = textBox2.Text;
                c.Id_Familia = Convert.ToInt32(familia);

                if (NCategoriaDesecho.Actualizar(c))
                {
                    MessageBox.Show("Datos guardados correctamente", "Aviso");
                    limpiar();
                    id_categoria();
                    ListaCategorias();
                    ListaFamilias();
                }
                else
                {
                    MessageBox.Show("Error", "Aviso");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var c = new DCategoriaDesecho();
                c.Id_Categoria = Convert.ToInt32(textBox1.Text);

                if (NCategoriaDesecho.Eliminar(c))
                {
                    MessageBox.Show("Eliminado correctamente", "Aviso");
                    limpiar();
                    id_categoria();
                    ListaCategorias();
                    ListaFamilias();
                }
                else
                {
                    MessageBox.Show("Error", "Aviso");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListaFamilias()
        {
            try
            {
                DataTable datos = new DataTable();
                datos = NFamilia.ListadoFamilias();
                comboBox1.DataSource = datos;
                comboBox1.DisplayMember = "Nombre";
                comboBox1.ValueMember = "Id_Familia";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListaCategorias()
        {
            try
            {
                DataTable datos = new DataTable();
                datos = NCategoriaDesecho.ListadoCategoria();
                dataGridView1.DataSource = datos;
                dataGridView1.Refresh();
                dataGridView1.Columns["Id_Familia"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void id_categoria()
        {
            try
            {
                var i = new DCategoriaDesecho();
                i.Id_Categoria = NCategoriaDesecho.Id() + 1;
                textBox1.Text = i.Id_Categoria.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void limpiar()
        {
            textBox2.Clear();
            textBox2.Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            textBox2.Text = dataGridView1[1, e.RowIndex].Value.ToString();
            comboBox1.SelectedValue = dataGridView1[2, e.RowIndex].Value;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            familia = comboBox1.SelectedValue.ToString();
        }

        private void Categoria_Load(object sender, EventArgs e)
        {
            limpiar();
            ListaCategorias();
            ListaFamilias();
            id_categoria();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            limpiar();
            ListaCategorias();
            ListaFamilias();
            id_categoria();
        }
    }
}
