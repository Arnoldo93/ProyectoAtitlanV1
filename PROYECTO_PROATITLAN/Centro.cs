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
    public partial class Centro : Form
    {
        public Centro()
        {
            InitializeComponent();
        }
        string municipio,tipo_centro;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox5.Text != "")
                {
                    if (checkBox1.Checked != false)
                    {
                        checkBox1.Checked = true;
                    }
                    else
                    {
                        checkBox1.Checked = false;
                    }
                    var c = new DDatosCentro();
                    c.Id_Centro = Convert.ToInt32(textBox1.Text);
                    c.Nombre = textBox5.Text;
                    c.Id_Municipio =Convert.ToInt32(municipio);
                    c.Id_tipo =Convert.ToInt32 (tipo_centro);
                    c.Telefono =Convert.ToInt32 ( textBox6.Text);
                    c.Direccion = textBox7.Text;
                    c.Estado = Convert.ToByte(checkBox1.Checked);

                    if (NDatosCentro.Agregar(c))
                    {
                        MessageBox.Show("Datos guardados correctamente", "Aviso");
                        limpiar();
                        ListaCentros();
                        ListaMunicipio();
                        ListaTipocentro();
                        id_centro();
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
                if (checkBox1.Checked != false)
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }
                var c = new DDatosCentro();
                c.Id_Centro = Convert.ToInt32(textBox1.Text);
                c.Nombre = textBox5.Text;
                c.Id_Municipio = Convert.ToInt32(comboBox2.SelectedValue);
                c.Id_tipo = Convert.ToInt32(comboBox1.SelectedValue);
                c.Telefono = int.Parse(textBox6.Text);
                c.Direccion = textBox7.Text;
                c.Estado = Convert.ToByte(checkBox1.Checked);

                if (NDatosCentro.Actualizar(c))
                {
                    MessageBox.Show("Se actualizo correctamente", "Aviso");
                    limpiar();
                    ListaCentros();
                    ListaMunicipio();
                    ListaTipocentro();
                    id_centro();
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
                var c = new DDatosCentro();
                c.Id_Centro = Convert.ToInt32(textBox1.Text);

                if (NDatosCentro.Eliminar(c))
                {
                    MessageBox.Show("Se elimino correctamente", "Aviso");
                    limpiar();
                    ListaCentros();
                    ListaMunicipio();
                    ListaTipocentro();
                    id_centro();
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
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ListaMunicipio();
        }

        private void groupPanel3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipo_centro =comboBox1.SelectedValue.ToString();
        }

        private void Centro_Load(object sender, EventArgs e)
        {
            id_centro();
            ListaCentros();
            ListaMunicipio();
            ListaTipocentro();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
             
        }

        private void button7_Click(object sender, EventArgs e)
        {
            id_centro();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            checkBox1.Checked = false;
            ListaCentros();
            ListaMunicipio();
            ListaTipocentro();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
                     
            
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            Municipio muni = new Municipio();
            muni.MdiParent = this.MdiParent;
            muni.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            textBox5.Text = dataGridView1[1, e.RowIndex].Value.ToString();
            comboBox2.SelectedValue = dataGridView1[2, e.RowIndex].Value;
            comboBox1.SelectedValue = dataGridView1[4, e.RowIndex].Value;
            textBox6.Text = dataGridView1[6, e.RowIndex].Value.ToString();
            textBox7.Text = dataGridView1[7, e.RowIndex].Value.ToString();
            checkBox1.Checked =Convert.ToBoolean(dataGridView1[8, e.RowIndex].Value);

        }

        private void ListaCentros()
        {
            try
            {
                DataTable datos = new DataTable();
                datos = NDatosCentro.ListaDatosCentro();
                dataGridView1.DataSource = datos;
                dataGridView1.Refresh();
                dataGridView1.Columns["Id_Municipio"].Visible = false;
                dataGridView1.Columns["Id_Tipo"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListaTipocentro()
        {
            try
            {
                DataTable datos = new DataTable();
                datos = NTipoCentro.ListadoTipoCentro();
                comboBox1.DataSource = datos;
                comboBox1.DisplayMember = "Nombre";
                comboBox1.ValueMember = "Id_Tipo";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListaMunicipio()
        {
            try
            {
                DataTable datos = new DataTable();
                datos = NMunicipio.ListaMunicipios();
                comboBox2.DataSource = datos;
                comboBox2.DisplayMember = "Municipio";
                comboBox2.ValueMember = "Id_Municipio";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void limpiar()
        {
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            checkBox1.Checked = false;
            textBox5.Focus();
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            municipio = comboBox2.SelectedValue.ToString();
        }

        private void id_centro()
        {
            try
            {
                var i = new DDatosCentro();
                i.Id_Centro = NDatosCentro.Id()+1;
                textBox1.Text = i.Id_Centro.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
