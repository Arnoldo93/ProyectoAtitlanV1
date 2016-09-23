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
using Entidades;
using Negocio;

namespace PROYECTO_PROATITLAN
{
    public partial class Desechos : Form
    {
        public Desechos()
        {
            InitializeComponent();
        }
        string familia, categoria, subcategoria, medida;
        private void Desechos_Load(object sender, EventArgs e)
        {
            limpiar();
            IdDesecho();
            ListadoFamilia();
            ListadoCategoria();
            ListadoSubCategoria();
            ListadoMedida();
            Listadodesecho();
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "")
                {
                    var c = new DDesechos();
                    c.Id_desecho = Convert.ToInt32(textBox1.Text);
                    c.Nombre = textBox2.Text.ToUpper();
                    c.Id_familia = int.Parse(familia);
                    c.Id_categoria = int.Parse(categoria);
                    c.Id_subcategoria = int.Parse(subcategoria);
                    c.Id_medida = Convert.ToInt32(medida);


                    if (NDesechos.Agregar(c))
                    {
                        MessageBox.Show("Datos guardados correctamente", "Aviso");
                        limpiar();
                        IdDesecho();
                        ListadoFamilia();
                        ListadoCategoria();
                        ListadoSubCategoria();
                        ListadoMedida();
                        Listadodesecho();

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
                    var c = new DDesechos();
                    c.Id_desecho = Convert.ToInt32(textBox1.Text);
                    c.Nombre = textBox2.Text.ToUpper();
                    c.Id_familia = Convert.ToInt32(comboBox1.SelectedValue);
                    c.Id_categoria = Convert.ToInt32(comboBox2.SelectedValue);
                    c.Id_subcategoria = Convert.ToInt32(comboBox4.SelectedValue);
                    c.Id_medida = Convert.ToInt32(comboBox3.SelectedValue);


                if (NDesechos.Actualizar(c))
                {
                    MessageBox.Show("Se actualizo correctamente", "Aviso");
                    limpiar();
                    IdDesecho();
                    ListadoFamilia();
                    ListadoCategoria();
                    ListadoSubCategoria();
                    ListadoMedida();
                    Listadodesecho();
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
                    var c = new DDesechos();
                    c.Id_desecho = Convert.ToInt32(textBox1.Text);

                if (NDesechos.Eliminar(c))
                {
                    MessageBox.Show("Se elimino correctamente", "Aviso");
                    limpiar();
                    IdDesecho();
                    ListadoFamilia();
                    ListadoCategoria();
                    ListadoSubCategoria();
                    ListadoMedida();
                    Listadodesecho();
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
            IdDesecho();
            ListadoFamilia();
            ListadoCategoria();
            ListadoSubCategoria();
            ListadoMedida();
            Listadodesecho();
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void IdDesecho()
        {
            try
            {
                var i = new DDesechos();
                i.Id_desecho = NDesechos.Id() + 1;
                textBox1.Text = i.Id_desecho.ToString(); ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Listadodesecho()
        {
            try
            {
                DataTable datos = new DataTable();
                datos = NDesechos.ListaDesechos();
                dataGridView1.DataSource = datos;
                dataGridView1.Refresh();
                dataGridView1.Columns["Id_Familia"].Visible = false;
                dataGridView1.Columns["Id_Categoria"].Visible = false;
                dataGridView1.Columns["Id_SubCategoria"].Visible = false;
                dataGridView1.Columns["Id_Medida"].Visible = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListadoFamilia()
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

        private void ListadoCategoria()
        {
            try
            {
                DataTable datos = new DataTable();
                datos = NCategoriaDesecho.ListadoCategoria();
                comboBox2.DataSource = datos;
                comboBox2.DisplayMember = "Nombre";
                comboBox2.ValueMember = "Id_Categoria";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListadoSubCategoria()
        {
            try
            {
                DataTable datos = new DataTable();
                datos = NSubcategoriaDesecho.ListadoSubcategoria();
                comboBox4.DataSource = datos;
                comboBox4.DisplayMember = "SubCategoria";
                comboBox4.ValueMember = "Id_SubCategoria";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListadoMedida()
        {
            try
            {
                DataTable datos = new DataTable();
                datos = NMedida.ListaMedida();
                comboBox3.DataSource = datos;
                comboBox3.DisplayMember = "Medida";
                comboBox3.ValueMember = "Id_Medida";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void limpiar()
        {
            foreach (Control item in groupPanel1.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            textBox2.Focus();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            familia = comboBox1.SelectedValue.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            categoria = comboBox2.SelectedValue.ToString();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            subcategoria = comboBox4.SelectedValue.ToString();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            medida = comboBox3.SelectedValue.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            textBox2.Text = dataGridView1[1, e.RowIndex].Value.ToString();
            comboBox1.SelectedValue = dataGridView1[2, e.RowIndex].Value;
            comboBox2.SelectedValue = dataGridView1[4, e.RowIndex].Value;
            comboBox4.SelectedValue = dataGridView1[6, e.RowIndex].Value;
            comboBox3.SelectedValue = dataGridView1[8, e.RowIndex].Value;
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }
    }
}
