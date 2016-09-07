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
            textBox2.Text = Program.usuario;
            //centroempleado();
        }

        private void idencabezado()
        {
            var id = NEncabezadoVenta.idencabezado()+1;
            textBox1.Text = id.ToString();
        }

        private void iddetalle()
        {
            var id = NEncabezadoVenta.iddetalle() + 1;
            textBox4.Text = id.ToString();
        }

        private void centroempleado()
        {
            DataTable datos = new DataTable();
            datos = NDatosCentro.CentroEmpleado(Convert.ToInt32(Program.idempleado));
            comboBox2.DataSource = datos;
            comboBox2.DisplayMember = "Nombre_centro";
            comboBox2.ValueMember = "Id_Centro";

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
    }
}
