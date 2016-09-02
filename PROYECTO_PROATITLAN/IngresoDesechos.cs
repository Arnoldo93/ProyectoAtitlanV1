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
using AccesoDatos;
using Negocio;
using Entidades;

namespace PROYECTO_PROATITLAN
{
    public partial class IngresoDesechos : Form
    {
        public IngresoDesechos()
        {
            InitializeComponent();
        }
        string centro;
        private static DDetalleIngreso d;
        private List<DDetalleIngreso> lista;

        private void IngresoDesechos_Load(object sender, EventArgs e)
        { 
            textBox2.Text = Program.usuario;
            comboBox2.Focus();
            listadocentros();
            idencabezado();
            iddetalle();
            desechos();
            vehiculo();
            centroempleado();
        }

        private void vehiculo()
        {
            comboBox3.DataSource = NVehiculo.ListadoVechiculos();
            comboBox3.DisplayMember = "Vehiculo";
            comboBox3.ValueMember = "Id_Vehiculo";
        }

        private void centroempleado()
        {
            DataTable datos = new DataTable();
            datos = NDatosCentro.CentroEmpleado(Convert.ToInt32( Program.idempleado));
            comboBox2.DataSource = datos;
            comboBox2.DisplayMember = "Nombre_centro";
            comboBox2.ValueMember = "Id_Centro";

        }

        private void desechos()
        {
            comboBox1.DataSource = NDesechos.ListaDesechos();
            comboBox1.DisplayMember = "Desecho";
            comboBox1.ValueMember = "Id_Desecho";
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            centro = comboBox2.SelectedValue.ToString();
        }

        private void listadocentros()
        {
            comboBox2.DataSource = NDatosCentro.ListaDatosCentro();
            comboBox2.DisplayMember = "Nombre_centro";
            comboBox2.ValueMember = "Id_Centro";
        }

        private void idencabezado()
        {
            var i = new DEncabezadoDesecho();
            i.Idencabezado = NEncabezadoDesechos.idencabezado() + 1;
            textBox1.Text = i.Idencabezado.ToString();
        }

        private void iddetalle()
        {
            var i = new DDetalleIngreso();
            i.iddetalle = NEncabezadoDesechos.iddetalle() + 1;
            textBox3.Text = i.iddetalle.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                iddetalle();
                button1.Enabled = false;
                button3.Enabled = true;

                lista = new List<DDetalleIngreso>();
                d = new DDetalleIngreso();
                d.idencabezado = Convert.ToInt32(textBox1.Text);
                d.iddetalle = Convert.ToInt32(textBox3.Text);
                d.iddesecho = Convert.ToInt32(comboBox1.SelectedValue);
                d.cantidad = Convert.ToInt32(textBox5.Text);
                d.idVehiculo = Convert.ToInt32(comboBox3.SelectedValue);
                lista.Add(d);

                var i = new DEncabezadoDesecho();
                i.listardetalle = lista;

                if (NEncabezadoDesechos.DetalleEncabezado(i))
                {
                    MessageBox.Show("Se agrego");
                    dataGridView1.Rows.Add(d.iddetalle, comboBox1.Text, d.cantidad,comboBox3.Text);

                    var cantidad = NDesechos.CantidadProductoPeso(Convert.ToInt32(comboBox1.SelectedValue));

                    int total = Convert.ToInt32(cantidad) + Convert.ToInt32(textBox5.Text);
                    var actualizarcantidad = new DDesechos();
                    actualizarcantidad.Id_desecho = Convert.ToInt32(comboBox1.SelectedValue);
                    actualizarcantidad.Cantida_peso = total;


                    if (NDesechos.ActualizarCantidadPeso(actualizarcantidad))
                    {
                        MessageBox.Show("Actualizado");
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Error, no se agrego verifique sus datos", "Aviso");
                
            }

            desechos();
            vehiculo();
            textBox5.Clear();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.RowCount == 0)
                {
                    MessageBox.Show("Debe Ingresar Desechos.", "Aviso");
                }
                else
                {
                    groupPanel2.Enabled = true;
                    groupPanel3.Enabled = true;
                    groupPanel1.Enabled = false;
                    groupPanel4.Enabled = false;


                    var v = new DEncabezadoDesecho();
                    v.Idencabezado = int.Parse(textBox1.Text);
                    v.fecharealizado = dateTimePicker1.Value;
                    v.idempleado = int.Parse(Program.idempleado);
                    v.idcentro = Convert.ToInt32(comboBox2.SelectedValue);

                    if (NEncabezadoDesechos.AgregarEncabezado(v))
                    {
                        MessageBox.Show("Se ingreso con exito.");
                    }
                    else
                    {
                        MessageBox.Show("Verifique sus datos");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView1[0, e.RowIndex].Value.ToString();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (NEncabezadoDesechos.EliminarDetalleEncabezado(Convert.ToInt32(textBox3.Text)))
                {
                    MessageBox.Show("Se eelimino correctamente");
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            groupPanel2.Enabled = true;
            groupPanel3.Enabled = true;
            idencabezado();
            centroempleado();
            iddetalle();
            desechos();
            vehiculo();
        }
    }
}
