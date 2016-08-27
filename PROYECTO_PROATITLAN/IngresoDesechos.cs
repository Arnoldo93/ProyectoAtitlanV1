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
        public static DDetalleIngresoProducto pro=null;
        private void IngresoDesechos_Load(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox2.Text = Program.usuario;
            listadocentros();
            id();
            desechos();
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

        private void id()
        {
            var i = new DEncabezadoDesecho();
            i.Idencabezado = NEncabezadoDesechos.id() + 1;
            textBox1.Text = i.Idencabezado.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = comboBox1.SelectedValue.ToString();
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

                var lista = new List<DDetalleIngreso>();
                foreach(DataGridViewRow i in dataGridView1.Rows)
                {
                    var d = new DDetalleIngreso();
                    d.iddesecho = (int)i.Cells[0].Value;
                    d.cantidad = (int)i.Cells[2].Value;
                    lista.Add(d);
                }

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            pro = new DDetalleIngresoProducto();
            pro.idproducto = int.Parse(textBox1.Text);
            pro.nombreproducto = comboBox1.Text;
            pro.cantidad = int.Parse(textBox5.Text);

            dataGridView1.Rows.Add(pro.idproducto, pro.nombreproducto, pro.cantidad);
            textBox3.Clear();
            textBox5.Clear();
        }
    }
}
