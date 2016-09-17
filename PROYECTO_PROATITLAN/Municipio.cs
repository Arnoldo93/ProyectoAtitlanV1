using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using MySql.Data;
using Entidades;
using Negocio;

namespace PROYECTO_PROATITLAN
{
    public partial class Municipio : Form
    {
        public Municipio()
        {
            InitializeComponent();
        }

        string zona;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "")
                {
                    var c = new DMunicipio();
                    c.Id_Municipio = Convert.ToInt32(textBox1.Text);
                    c.Nombre = textBox2.Text;
                    c.Id_zona =Convert.ToInt32( zona);
                    if (NMunicipio.Agregar(c))
                    {
                        MessageBox.Show("Datos guardados correctamente", "Aviso");
                        id_municipio();
                        listarmunicipios();
                        listarZonas();
                        limpiar();
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
                
                    var c = new DMunicipio();
                    c.Id_Municipio = Convert.ToInt32(textBox1.Text);
                    c.Nombre = textBox2.Text;
                    c.Id_zona = Convert.ToInt32(comboBox1.SelectedValue);
                    if (NMunicipio.Actualizar(c))
                    {
                        MessageBox.Show("Se actualizo correctamente", "Aviso");
                        id_municipio();
                        listarmunicipios();
                        listarZonas();
                    limpiar();
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
                
                    var c = new DMunicipio();
                    c.Id_Municipio = Convert.ToInt32(textBox1.Text);
  
                    if (NMunicipio.Eliminar(c))
                    {
                        MessageBox.Show("Se elimino correctamente", "Aviso");
                        id_municipio();
                        listarmunicipios();
                        listarZonas();
                    limpiar();
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

        private void listarmunicipios()
        {
            try
            {
                DataTable datos = new DataTable();
                datos = NMunicipio.ListaMunicipios();
                dataGridView1.DataSource = datos;
                dataGridView1.Refresh();
                this.dataGridView1.Columns["Id_Zona"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void id_municipio()
        {
            try
            {
                var val = new DMunicipio();
                val.Id_Municipio = NMunicipio.Id() + 1;
                textBox1.Text = val.Id_Municipio.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listarZonas()
        {
            try
            {
                DataTable datos = new DataTable();
                datos = NZona.ListaZona();
                comboBox1.DataSource = datos;
                comboBox1.DisplayMember = "Nombre";
                comboBox1.ValueMember = "Id_Zona";
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

        private void button4_Click(object sender, EventArgs e)
        {
            id_municipio();
            limpiar();
            listarmunicipios();
            listarZonas();
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void Municipio_Load(object sender, EventArgs e)
        {
            id_municipio();
            limpiar();
            listarmunicipios();
            listarZonas();
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "Solola";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "San Jorge La Laguna";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "Panajachel";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "Santa Catarina Papoló";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "San Antonio Papoló";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "San Lucas Tolimán";
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "Santiago Atitlán";
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "San Pedro La Laguna";
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "San Juan La Laguna";
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "Santa María Visitación";
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "Santa Clara La Laguna";
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "San Pablo La Laguna";
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "San Marcos La Laguna";
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "Tzununá";
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "Santa Cruz La Laguna";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            zona = comboBox1.SelectedValue.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            textBox2.Text = dataGridView1[1, e.RowIndex].Value.ToString();
            comboBox1.SelectedValue = dataGridView1[2, e.RowIndex].Value;
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton15_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox2.Text = "Solola";
        }
    }
}
