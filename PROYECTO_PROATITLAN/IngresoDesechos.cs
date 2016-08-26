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
        private void IngresoDesechos_Load(object sender, EventArgs e)
        {
            textBox2.Text = Program.usuario;
            listadocentros();
            id();
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
    }
}
