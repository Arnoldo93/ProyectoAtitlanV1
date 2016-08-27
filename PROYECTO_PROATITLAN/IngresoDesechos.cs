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
        public static DDetalleIngreso d;
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
        }

        private void vehiculo()
        {
            comboBox3.DataSource = NVehiculo.ListadoVechiculos();
            comboBox3.DisplayMember = "Vehiculo";
            comboBox3.ValueMember = "Id_Vehiculo";
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
            var i = new DEncabezadoDesecho();
            i.Idencabezado = NEncabezadoDesechos.iddetalle() + 1;
            textBox3.Text = i.Idencabezado.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("Debe Ingresar Desechos.", "Aviso");
            }
            else
            {
                //encabezado
                var v = new DEncabezadoDesecho();
                v.Idencabezado =int.Parse( textBox1.Text);
                v.fecharealizado = dateTimePicker1.Value;
                v.idempleado =int.Parse(Program.idempleado);
                v.idcentro =Convert.ToInt32(comboBox2.SelectedValue.ToString());

                //detalle
                v.listardetalle = lista;
               


                //foreach(DataGridViewRow i in dataGridView1.Rows)
                //{
                //    var d = new DDetalleIngreso();
                //    d.iddesecho = (int)i.Cells[0].Value;
                //    d.cantidad = (int)i.Cells[2].Value;
                //    lista.Add(d);
                //}
                //v.listardetalle = lista;
                if (NEncabezadoDesechos.Agregar(v))
                {
                    MessageBox.Show("Se ingreso con exito.");
                }
                else
                {
                    MessageBox.Show("Verifique sus datos");
                }

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            lista = new List<DDetalleIngreso>();
            d= new DDetalleIngreso();
            d.iddetalle = Convert.ToInt32(textBox3.Text);
            d.iddesecho = (int)comboBox1.SelectedValue;
            d.cantidad = Convert.ToInt32(textBox5.Text);
            d.idVehiculo = (int)comboBox3.SelectedValue;
            lista.Add(d);
            iddetalle();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
            dataGridView1.Refresh();
        }
    }
}
