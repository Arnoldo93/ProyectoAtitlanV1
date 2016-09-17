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
    public partial class TipoDeCliente : Form
    {
        public TipoDeCliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "")
                {
                    var v = new DTipoDeCliente();
                    v.Idtipo = Convert.ToInt32(textBox1.Text);
                    v.nombretipo = textBox2.Text.ToUpper();

                    if (NTipoDeCliente.Agregar(v))
                    {
                        MessageBox.Show("Datos guardados correctamente.");
                        id();
                        limpiar();
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

        private void TipoDeCliente_Load(object sender, EventArgs e)
        {
            id();
            listado();
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void id()
        {
            var id =NTipoDeCliente.id()+1;
            textBox1.Text = id.ToString();

        }

        private void listado()
        {
            DataTable datos = new DataTable();
            datos = NTipoDeCliente.ListaTipoDeCliente();
            dataGridView1.DataSource = datos;
            dataGridView1.Refresh();
        }
        private void limpiar()
        {
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                   var v = new DTipoDeCliente();
                    v.Idtipo = Convert.ToInt32(textBox1.Text);
                    v.nombretipo = textBox2.Text.ToUpper();

                    if (NTipoDeCliente.Actualizar(v))
                    {
                        MessageBox.Show("Se actualizo correctamente");
                        id();
                        limpiar();
                        listado();
                    }
                    else
                    {
                        MessageBox.Show("Error, Verifique que los datos sean correctos.");
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
                var v = new DTipoDeCliente();
                v.Idtipo = Convert.ToInt32(textBox1.Text);

                if (NTipoDeCliente.Eliminar(v))
                {
                    MessageBox.Show("Se elimino correctamente");
                    id();
                    limpiar();
                    listado();
                }
                else
                {
                    MessageBox.Show("Error, Verifique que los datos sean correctos.");
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
            id();
            listado();
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
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
    }
}
