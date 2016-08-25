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
    public partial class Puesto : Form
    {
        public Puesto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "")
                {
                    var c = new Dpuesto();
                    c.Id_puesto = Convert.ToInt32(textBox1.Text);
                    c.Nombre_puesto = textBox2.Text;
                    if (Npuesto.Guardar(c))
                    {

                        MessageBox.Show("Se Agrego con exito.","Aviso");
                        id_puesto();
                        limpiar();
                        ListaPuestos();
                    }
                    else
                    {
                        MessageBox.Show("Ya existe el valor que desea ingresar.");
                    }
                }

                else
                {
                    MessageBox.Show("Error, Ingresa el nombre", "Aviso");
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
                var c = new Dpuesto();
                c.Id_puesto = Convert.ToInt32(textBox1.Text);
                c.Nombre_puesto = textBox2.Text;
                if (Npuesto.Actualizar(c))
                {
                    MessageBox.Show("Se actualizo correctamento.");
                    id_puesto();
                    limpiar();
                    ListaPuestos();
                }
                else
                {
                    MessageBox.Show("Error, vefique que exista.","Aviso");
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
                var c = new Dpuesto();
                c.Id_puesto = Convert.ToInt32(textBox1.Text);
                c.Nombre_puesto = textBox2.Text;

                if (Npuesto.Eliminar(c))
                {
                    MessageBox.Show("Datos guardados correctamente");
                    id_puesto();
                    limpiar();
                    ListaPuestos();
                }
                else
                {
                    MessageBox.Show("Error, verifique que el dato existe", "Aviso");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void Puesto_Load(object sender, EventArgs e)
        {
            ListaPuestos();
            id_puesto();
        }

        private void ListaPuestos()
        {
            try
            {
                DataTable datos = new DataTable();
                datos = Npuesto.ListaPuesto();
                dataGridView1.DataSource = datos;
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void id_puesto()
        {
            try
            {
                var c = new Dpuesto();
                c.Id_puesto = Npuesto.Id() + 1;
                textBox1.Text = c.Id_puesto.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void limpiar()
        {
            textBox2.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void groupPanel2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            textBox2.Text = dataGridView1[1, e.RowIndex].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            limpiar();
            ListaPuestos();
            id_puesto();
        }
    }
}
