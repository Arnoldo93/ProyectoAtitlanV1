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
    public partial class Tipo_Centro : Form
    {
        public Tipo_Centro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "")
                {
                    var c = new DTipoCentro();
                    c.Id_Tipocentro = Convert.ToInt32(textBox1.Text);
                    c.Nombre = textBox2.Text;

                    if (NTipoCentro.Agregar(c))
                    {
                        MessageBox.Show("Datos guardados correctamente", "Aviso");
                        id_tipocentro();
                        listartipocentro();
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
                
                    var c = new DTipoCentro();
                    c.Id_Tipocentro = Convert.ToInt32(textBox1.Text);
                    c.Nombre = textBox2.Text;

                    if (NTipoCentro.Actualizar(c))
                    {
                        MessageBox.Show("Datos guardados correctamente", "Aviso");
                        id_tipocentro();
                        listartipocentro();
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
                
                    var c = new DTipoCentro();
                    c.Id_Tipocentro = Convert.ToInt32(textBox1.Text);

                    if (NTipoCentro.Eliminar(c))
                    {
                        MessageBox.Show("Elliminado correctamente.", "Aviso");
                        id_tipocentro();
                        listartipocentro();
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

        private void listartipocentro()
        {
            try
            {
                DataTable datos = new DataTable();
                datos = NTipoCentro.ListadoTipoCentro();
                dataGridView1.DataSource = datos;
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void id_tipocentro()
        {
            try
            {
                var val = new DTipoCentro();
                val.Id_Tipocentro = NTipoCentro.Id() + 1;
                textBox1.Text = val.Id_Tipocentro.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void limpiar()
        {
            textBox2.Clear();
            textBox2.Focus();
        }

        private void Tipo_Centro_Load(object sender, EventArgs e)
        {
            listartipocentro();
            id_tipocentro();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            textBox2.Text = dataGridView1[1, e.RowIndex].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listartipocentro();
            id_tipocentro();
            limpiar();
        }
    }
}
