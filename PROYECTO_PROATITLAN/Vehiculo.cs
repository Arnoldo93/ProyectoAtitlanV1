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
    public partial class Vehiculo : Form
    {
        public Vehiculo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "" && textBox3.Text != "")
                {
                    var v = new DVehiculo();
                    v.Idvehiculo = Convert.ToInt32(textBox1.Text);
                    v.Nombrevehiculo = textBox2.Text.ToUpper();
                    v.Volumen = Convert.ToInt32(textBox3.Text);

                    if (NVehiculo.agregar(v))
                    {
                        MessageBox.Show("Datos guardados correctamente.");
                        limpiar();
                        Id();
                        listado();
                    }
                    else
                    {
                        MessageBox.Show("Error, Verifique que los datos sean correctos.");
                    }
                }

                else
                {
                    MessageBox.Show("Debe ingresar datos en los dos campos.");
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
                var v = new DVehiculo();
                v.Idvehiculo = Convert.ToInt32( textBox1.Text);
                v.Nombrevehiculo = textBox2.Text;
                v.Volumen = Convert.ToInt32(textBox3.Text);
                if (NVehiculo.actualizar(v))
                {
                    MessageBox.Show("Se actualizo Correctamente.");
                    limpiar();
                    Id();
                    listado();
                    button1.Enabled = true;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Error verifique sus datos");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var v = new DVehiculo();
                v.Idvehiculo = Convert.ToInt32(textBox1.Text);
                if (NVehiculo.eliminar(v))
                {
                    MessageBox.Show("Se elimino Correctamente.");
                    limpiar();
                    Id();
                    listado();
                    button1.Enabled = true;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Error verifique sus datos");
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
            listado();
            Id();
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void listado()
        {
            try
            {
                DataTable datos = new DataTable();
                datos = NVehiculo.ListadoVechiculos();
                dataGridView1.DataSource = datos;
                dataGridView1.Refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Id()
        {
            try
            {
                var i = new DVehiculo();
                i.Idvehiculo = NVehiculo.Id() + 1;
                textBox1.Text = Convert.ToString(i.Idvehiculo);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void limpiar()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox2.Focus();
        }

        private void Vehiculo_Load(object sender, EventArgs e)
        {
            limpiar();
            Id();
            listado();
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            textBox2.Text = dataGridView1[1, e.RowIndex].Value.ToString();
            textBox3.Text = dataGridView1[2, e.RowIndex].Value.ToString();
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }
    }
}
