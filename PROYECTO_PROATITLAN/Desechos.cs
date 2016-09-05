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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                {
                    if (checkBox1.Checked != false)
                    {
                        checkBox1.Checked = true;
                    }
                    else
                    {
                        checkBox1.Checked = false;
                    }
                    var c = new DDesechos();
                    c.Id_desecho = Convert.ToInt32(textBox1.Text);
                    c.Nombre = textBox2.Text;
                    c.Id_familia = int.Parse(familia);
                    c.Id_categoria = int.Parse(categoria);
                    c.Id_subcategoria = int.Parse(subcategoria);
                    c.Cantida_peso =Convert.ToDecimal(textBox3.Text);
                    c.Id_medida = Convert.ToInt32(medida);
                    c.Volumen = int.Parse(textBox4.Text);
                    c.Precio_costo =Convert.ToDouble( textBox5.Text);
                    c.PrecioVenta = Convert.ToDouble(textBox6.Text);
                    c.Estado_desecho = Convert.ToByte(checkBox1.Checked);


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
                    c.Nombre = textBox2.Text;
                    c.Id_familia = Convert.ToInt32(comboBox1.SelectedValue);
                    c.Id_categoria = Convert.ToInt32(comboBox2.SelectedValue);
                    c.Id_subcategoria = Convert.ToInt32(comboBox4.SelectedValue);
                    c.Cantida_peso = Convert.ToDecimal(textBox3.Text);
                    c.Id_medida = Convert.ToInt32(comboBox3.SelectedValue);
                    c.Volumen = int.Parse(textBox4.Text);
                    c.Precio_costo = Convert.ToDouble(textBox5.Text);
                    c.PrecioVenta = Convert.ToDouble(textBox6.Text);
                    c.Estado_desecho = Convert.ToByte(checkBox1.Checked);


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
                    c.Nombre = textBox2.Text;
                    c.Id_familia = int.Parse(familia);
                    c.Id_categoria = int.Parse(categoria);
                    c.Id_subcategoria = int.Parse(subcategoria);
                    c.Cantida_peso = Convert.ToDecimal(textBox3.Text);
                    c.Id_medida = Convert.ToInt32(medida);
                    c.Volumen = int.Parse(textBox4.Text);
                    c.Precio_costo = Convert.ToDouble(textBox5.Text);
                    c.PrecioVenta = Convert.ToDouble(textBox6.Text);
                    c.Estado_desecho = Convert.ToByte(checkBox1.Checked);


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
            textBox3.Text = dataGridView1[8, e.RowIndex].Value.ToString();
            comboBox3.SelectedValue = dataGridView1[9, e.RowIndex].Value;
            textBox4.Text = dataGridView1[11, e.RowIndex].Value.ToString();
            textBox5.Text = dataGridView1[12, e.RowIndex].Value.ToString();
            textBox6.Text = dataGridView1[13, e.RowIndex].Value.ToString();
            checkBox1.Checked =Convert.ToBoolean( dataGridView1[14, e.RowIndex].Value);
        }
    }
}
