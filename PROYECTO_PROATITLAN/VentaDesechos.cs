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
using AccesoDatos;
using Negocio;

namespace PROYECTO_PROATITLAN
{
    public partial class VentaDesechos : Form
    {
        public VentaDesechos()
        {
            InitializeComponent();
        }
        private void VentaDesechos_Load(object sender, EventArgs e)
        {
            idencabezado();
            iddetalle();
            moneda();
            cliente();
            desechos();
            //listacombinadatipocliente();
            textBox2.Text = Program.usuario;
            limpiar();
            //centroempleado();
        }

        private void idencabezado()
        {
            var id = NEncabezadoVenta.idencabezado()+1;
            textBox1.Text = id.ToString();
        }

        private void limpiar()
        {
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }

        private void iddetalle()
        {
            var id = NEncabezadoVenta.iddetalle() + 1;
            textBox4.Text = id.ToString();
        }

        private void listacombinadatipocliente()
        {
            DataTable datos = new DataTable();
            datos = NTipoDeCliente.listacombinadatipocliente(Convert.ToInt32(comboBox3.SelectedValue));
            comboBox2.DataSource = datos;
            comboBox2.DisplayMember = "Nombre";
            comboBox2.ValueMember = "Id_Categoria";
        }

        private void moneda()
        {
            DataTable datos = new DataTable();
            datos = NMoneda.ListarMoneda();
            comboBox1.DataSource = datos;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Id_Moneda";
        }

        private void cliente()
        {
            DataTable datos = new DataTable();
            datos = NCliente.ListaDatosCliente();
            comboBox3.DataSource = datos;
            comboBox3.DisplayMember = "Cliente";
            comboBox3.ValueMember = "Id_Cliente";
        }

        private void desechos()
        {
            DataTable datos = new DataTable();
            datos = NDesechos.ListaD();
            comboBox4.DisplayMember = "Nombre";
            comboBox4.ValueMember = "Id_Desecho";
            comboBox4.DataSource = datos;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var inser = new DEncabezadoVentas();
            inser.idventa =Convert.ToInt32(textBox1.Text);
            inser.total = Convert.ToDecimal(textBox8.Text);
            inser.fecharealizado = DateTime.Now;
            inser.idempleado = Convert.ToInt32(textBox2.Text);
            inser.idmoneda =Convert.ToInt32(comboBox1.SelectedValue);
            inser.idcliente = Convert.ToInt32(comboBox3.SelectedValue);
            inser.idcentro = Convert.ToInt32(comboBox2.SelectedValue);
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                var dese = new DDesechos();
                dese.Id_desecho = Convert.ToInt32(comboBox4.SelectedValue);
                dese.Nombre = comboBox4.Text;
                if (comboBox4.Text != "ORGANICO")
                {
                    DataTable datos = new DataTable();
                    datos = NDesechos.obtenercantidadpesodesechos(dese);
                    string cantidad = datos.Rows[0][2].ToString();
                    string precioventa = datos.Rows[0][3].ToString();
                    textBox5.Text = cantidad;
                    textBox6.Text = precioventa;
                    int SUBTOTAL =Convert.ToInt32(cantidad) * Convert.ToInt32(precioventa);
                    textBox7.Text = SUBTOTAL.ToString();
                }
                else
                {
                    DataTable datos1 = new DataTable();
                    datos1 = NDesechos.obtenerVolumendesechos(dese);
                    string volumen = datos1.Rows[0][2].ToString();
                    string precioventa = datos1.Rows[0][3].ToString();
                    textBox5.Text = volumen;
                    textBox6.Text = precioventa;
                    int SUBTOTAL = Convert.ToInt32(volumen) * Convert.ToInt32(precioventa);
                    textBox7.Text = SUBTOTAL.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}

        private void comboBox4_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }
    }
}
