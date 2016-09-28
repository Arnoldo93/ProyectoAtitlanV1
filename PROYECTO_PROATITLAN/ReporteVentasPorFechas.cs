using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using AccesoDatos;
using Entidades;
using Negocio;


namespace PROYECTO_PROATITLAN
{
    public partial class ReporteVentasPorFechas : Form
    {
        public ReporteVentasPorFechas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable datos = new DataTable();
            datos = NEncabezadoVenta.BusquedaVentasPorFechas(dateTimePicker1.Value, dateTimePicker2.Value);
            dataGridView1.DataSource = datos;
            dataGridView1.Refresh();
        }
    }
}
