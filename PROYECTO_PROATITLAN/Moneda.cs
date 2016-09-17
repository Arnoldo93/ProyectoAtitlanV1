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
    public partial class Moneda : Form
    {
        public Moneda()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "")
                {
                    var c = new DMoneda();
                    c.idmoneda = Convert.ToInt32(textBox1.Text);
                    c.nombre = textBox2.Text.ToUpper();

                    if (NMoneda.Guardar(c))
                    {
                        MessageBox.Show("Datos guardados correctamente", "Aviso");
                        id();
                        limpiar();
                        listado();
                    }
                    else
                    {
                        MessageBox.Show("Error", "Aviso");
                    }
                }

                else
                {
                    MessageBox.Show("Debe ingresar Datos", "Aviso");
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
                    var c = new DMoneda();
                    c.idmoneda = Convert.ToInt32(textBox1.Text);
                    c.nombre = textBox2.Text.ToUpper();

                if (NMoneda.Actualizar(c))
                {
                    MessageBox.Show("Se actualizo correctamente", "Aviso");
                    id();
                    limpiar();
                    listado();
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
                  var c = new DMoneda();
                    c.idmoneda = Convert.ToInt32(textBox1.Text);

                if (NMoneda.Eliminar(c))
                {
                    MessageBox.Show("Se elimino correctamente", "Aviso");
                    id();
                    limpiar();
                    listado();
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
            id();
            limpiar();
            listado();
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void id()
        {
            var d = NMoneda.Id() + 1;
            textBox1.Text = d.ToString();
        }

        private void listado()
        {
            DataTable datos = new DataTable();
            datos = NMoneda.ListarMoneda();
            dataGridView1.DataSource = datos;
            dataGridView1.Refresh();
        }
        private void limpiar()
        {
            textBox2.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            textBox2.Text = dataGridView1[1, e.RowIndex].Value.ToString();
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void Moneda_Load(object sender, EventArgs e)
        {
            id();
            limpiar();
            listado();
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }
    }
}
