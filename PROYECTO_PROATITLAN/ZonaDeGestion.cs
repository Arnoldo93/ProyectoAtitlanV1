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
using AccesoDatos;
using Entidades;
using Negocio;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace PROYECTO_PROATITLAN
{
    public partial class ZonaDeGestion : Form
    {
        public ZonaDeGestion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           try
            {
                if (textBox2.Text != "")
                {
                    var c = new DZona();
                    c.Id_zona = Convert.ToInt32(textBox1.Text);
                    c.Nombrezona = textBox2.Text;

                    if (NZona.Agregar(c))
                    {
                        MessageBox.Show("Datos guardados correctamente", "Aviso");
                        listarZonas();
                        id_zona();
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
                if (textBox2.Text != "")
                {
                    var c = new DZona();
                    c.Id_zona = Convert.ToInt32(textBox1.Text);
                    c.Nombrezona = textBox2.Text;

                    if (NZona.Actualizar(c))
                    {
                        MessageBox.Show("Se actualizo correctamente", "Aviso");
                        listarZonas();
                        id_zona();
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

        private void button3_Click(object sender, EventArgs e)
        {
                       try
            {
                    var c = new DZona();
                    c.Id_zona = Convert.ToInt32(textBox1.Text);

                    if (NZona.Eliminar(c))
                    {
                        MessageBox.Show("Se elimino correctamente", "Aviso");
                        listarZonas();
                        id_zona();
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

        private void listarZonas()
        {
            try
            {
                DataTable datos = new DataTable();
                datos = NZona.ListaZona();
                dataGridView1.DataSource = datos;
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void id_zona()
        {
            try
            {
                var c = new DZona();
                c.Id_zona = NZona.Id() + 1;
                textBox1.Text = c.Id_zona.ToString();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void limpiar()
        {
            textBox2.Clear();
            textBox2.Focus();
        }

        private void ZonaDeGestion_Load(object sender, EventArgs e)
        {
            id_zona();
            listarZonas();
            limpiar();
            button2.Enabled = false;
            button3.Enabled = false;
            button12.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.Text = "Norte";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.Text = "Nor-Este";
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.Text = "Este";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.Text = "Sur-Este";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.Text = "Sur";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.Text = "Sur-Oeste";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.Text = "Oeste";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.Text = "Nor-Oeste";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            textBox2.Text = dataGridView1[1, e.RowIndex].Value.ToString();
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button12.Enabled = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            limpiar();
            id_zona();
            listarZonas();
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button12.Enabled = false;
        }
    }
}
