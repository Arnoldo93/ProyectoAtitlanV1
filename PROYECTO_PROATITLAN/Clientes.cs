using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MySql.Data;
using Entidades;
using AccesoDatos;
using Negocio;

namespace PROYECTO_PROATITLAN
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private static bool isValid(String str)
        {
            return Regex.IsMatch(str, @"^[a-z0-9._ -]+@[a-z0-9.-]+.[a-z]{2,3}$");
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            //try
            //{
                if (textBox2.Text != "")
                {
                    var c = new DCliente();
                    c.idcliente = Convert.ToInt32(textBox1.Text);
                    c.nombre = textBox2.Text.ToUpper();
                    c.idcategoria =Convert.ToInt32(comboBox1.SelectedValue);
                    c.direccion = Convert.ToString(textBox3.Text);
                    c.ubicacion = textBox4.Text;
                    c.zona = Convert.ToInt32(textBox5.Text);
                    c.telefono = Convert.ToInt32(maskedTextBox1.Text);
                    c.contacto = textBox7.Text; ;
                    c.correo = textBox8.Text;

                    if (isValid(textBox8.Text))
                    {

                        if (NCliente.Agregar(c))
                        {
                            MessageBox.Show("Datos guardados correctamente", "Aviso");
                            id();
                            listarcategoria();
                            listar();
                            limpiar();
                        }
                        else
                        {
                            MessageBox.Show("Error", "Aviso");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Revise que su correo electronico contenga el formato correcto", "Error");
                    }
                }

                else
                {
                    MessageBox.Show("Error", "Aviso");
                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                    var c = new DCliente();
                    c.idcliente = Convert.ToInt32(textBox1.Text);
                    c.nombre = textBox2.Text.ToUpper();
                    c.idcategoria = Convert.ToInt32(comboBox1.SelectedValue);
                    c.direccion = Convert.ToString(textBox3.Text);
                    c.ubicacion = textBox4.Text;
                    c.zona = Convert.ToInt32(textBox5.Text);
                    c.telefono = Convert.ToInt32(maskedTextBox1.Text);
                    c.contacto = textBox7.Text; ;
                    c.correo = textBox8.Text;
                if (isValid(textBox8.Text))
                {

                    if (NCliente.Actualizar(c))
                    {
                        MessageBox.Show("Se actualizo correctamente", "Aviso");
                        id();
                        listarcategoria();
                        listar();
                        limpiar();
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
                else
                {
                    MessageBox.Show("Revise que su correo electronico contenga el formato correcto","Error");
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
                    var c = new DCliente();
                    c.idcliente = Convert.ToInt32(textBox1.Text);
                if (NCliente.Eliminar(c))
                {
                    MessageBox.Show("Se elimino correctamente", "Aviso");
                    id();
                    listarcategoria();
                    listar();
                    limpiar();
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
            id();
            listar();
            listarcategoria();
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void limpiar()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            maskedTextBox1.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }

        private void id ()
        {
            var d = NCliente.Id() + 1;
            textBox1.Text = d.ToString();
        }

        private void listar()
        {
            DataTable datos = new DataTable();
            datos = NCliente.ListaDatosCliente();
            dataGridView1.DataSource = datos;
            dataGridView1.Refresh();
            dataGridView1.Columns["Id_Categoria"].Visible = false;
        }

        private void listarcategoria()
        {
            DataTable datos = new DataTable();
            datos = NTipoDeCliente.ListaTipoDeCliente();
            comboBox1.DataSource = datos;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Id_Categoria";
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            id();
            listarcategoria();
            listar();
            limpiar();
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            textBox2.Text = dataGridView1[1, e.RowIndex].Value.ToString();
            comboBox1.SelectedValue = dataGridView1[2, e.RowIndex].Value;
            textBox3.Text = dataGridView1[4, e.RowIndex].Value.ToString();
            textBox4.Text = dataGridView1[5, e.RowIndex].Value.ToString();
            textBox5.Text = dataGridView1[6, e.RowIndex].Value.ToString();
            maskedTextBox1.Text = dataGridView1[7, e.RowIndex].Value.ToString();
            textBox7.Text = dataGridView1[8, e.RowIndex].Value.ToString();
            textBox8.Text = dataGridView1[9, e.RowIndex].Value.ToString();
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            var bus = new DCliente();
            bus.nombre = Convert.ToString(textBox2.Text);

            dataGridView1.DataSource = NCliente.BuscarCliente(bus);
            dataGridView1.Refresh();
        }
    }
}
