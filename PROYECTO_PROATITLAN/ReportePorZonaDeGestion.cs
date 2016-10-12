using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Negocio;
using AccesoDatos;

namespace PROYECTO_PROATITLAN
{
    public partial class ReportePorZonaDeGestion : Form
    {
        public ReportePorZonaDeGestion()
        {
            InitializeComponent();
        }

        private void ReportePorZonaDeGestion_Load(object sender, EventArgs e)
        {
            listadozonas();
        }

        private void listadozonas()
        {
            DataTable datos = new DataTable();
            datos=NZona.ListaZona();
            comboBox1.DataSource = datos;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Id_Zona";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable datos = new DataTable();
            datos = NEncabezadoDesechos.ProduccionPorZonaDeGestion(Convert.ToInt32( comboBox1.SelectedValue), dateTimePicker1.Value, dateTimePicker2.Value);
            dataGridView1.DataSource = datos;
            dataGridView1.Refresh();

        }
    }
}
