using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;
using Entidades;
using Negocio;

namespace PROYECTO_PROATITLAN
{
    public partial class SubCategoria_Desechos : Form
    {
        public SubCategoria_Desechos()
        {
            InitializeComponent();
        }
        string categoria, familia;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "")
                {
                    var c = new DSubcategoriaDesecho();
                    c.Id_SubCategoria = Convert.ToInt32(textBox1.Text);
                    c.Nombre = textBox2.Text.ToUpper();
                    c.Id_Categoria = Convert.ToInt32(categoria);
                    c.Id_Familia = Convert.ToInt32(familia);

                    if (NSubcategoriaDesecho.Agregar(c))
                    {
                        MessageBox.Show("Datos guardados correctamente", "Aviso");
                        limpiar();
                        ListadoCategorias();
                        ListadoFamilias();
                        ListaSubcategorias();
                        idSubCategoria();
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
                var c = new DSubcategoriaDesecho();
                c.Id_SubCategoria = Convert.ToInt32(textBox1.Text);
                c.Nombre = textBox2.Text.ToUpper();
                c.Id_Categoria = Convert.ToInt32(comboBox1.SelectedValue);
                c.Id_Familia = Convert.ToInt32(comboBox2.SelectedValue);

                if (NSubcategoriaDesecho.Actualizar(c))
                {
                    MessageBox.Show("Se actualizo correctamente", "Aviso");
                    limpiar();
                    ListadoCategorias();
                    ListadoFamilias();
                    ListaSubcategorias();
                    idSubCategoria();
                    button1.Enabled = true;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
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
                    var c = new DSubcategoriaDesecho();
                    c.Id_SubCategoria = Convert.ToInt32(textBox1.Text);

                if (NSubcategoriaDesecho.Eliminar(c))
                {
                    MessageBox.Show("Se elimino correctamente", "Aviso");
                    limpiar();
                    ListadoCategorias();
                    ListadoFamilias();
                    ListaSubcategorias();
                    idSubCategoria();
                    button1.Enabled = true;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
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

        private void button4_Click(object sender, EventArgs e)
        {
            limpiar();
            ListadoCategorias();
            ListadoFamilias();
            ListaSubcategorias();
            idSubCategoria();
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void ListaSubcategorias()
        {
            try
            {
                DataTable datos = new DataTable();
                datos = NSubcategoriaDesecho.ListadoSubcategoria();
                dataGridView1.DataSource = datos;
                dataGridView1.Refresh();
                dataGridView1.Columns["Id_Categoria"].Visible = false;
                dataGridView1.Columns["Id_Familia"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListadoCategorias()
        {
            try
            {
                DataTable datos = new DataTable();
                datos = NCategoriaDesecho.ListadoCategoria();
                comboBox1.DataSource = datos;
                comboBox1.DisplayMember = "Nombre";
                comboBox1.ValueMember = "Id_Categoria";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListadoFamilias()
        {
            try
            {
                DataTable datos = new DataTable();
                datos = NFamilia.ListadoFamilias();
                comboBox2.DataSource = datos;
                comboBox2.DisplayMember = "Nombre";
                comboBox2.ValueMember = "Id_Familia";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void idSubCategoria()
        {
            try
            {
                var val = new DSubcategoriaDesecho();
                val.Id_SubCategoria = NSubcategoriaDesecho.id() + 1;
                textBox1.Text = val.Id_SubCategoria.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SubCategoria_Desechos_Load(object sender, EventArgs e)
        {
            limpiar();
            ListadoCategorias();
            ListadoFamilias();
            ListaSubcategorias();
            idSubCategoria();
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            categoria = comboBox1.SelectedValue.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            familia = comboBox2.SelectedValue.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            textBox2.Text = dataGridView1[1, e.RowIndex].Value.ToString();
            comboBox1.SelectedValue = dataGridView1[2, e.RowIndex].Value;
            comboBox2.SelectedValue = dataGridView1[4, e.RowIndex].Value;
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void limpiar()
        {
            textBox2.Clear();
            textBox2.Focus();
        }

    }   
}
