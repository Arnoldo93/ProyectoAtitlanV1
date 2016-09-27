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
using Entidades;
using AccesoDatos;
using Negocio;


namespace PROYECTO_PROATITLAN
{
    public partial class ReporteExistencias : Form
    {
        public ReporteExistencias()
        {
            InitializeComponent();
        }

        private void ReporteExistencias_Load(object sender, EventArgs e)
        {
            listadocentros();
        }

        public void listadocentros()
        {
            DataTable datos = new DataTable();
            datos = NTipoCentro.ListadoTipoCentro();
            comboBox1.DataSource = datos;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Id_Tipo";
        }

        public void listadoexistencias()
        {
            var ex = new DExistencias();
            ex.idcentro =Convert.ToInt32(comboBox1.SelectedValue);
            DataTable datos = new DataTable();
            datos = NExistencias.listadoexistencia(ex);
        }
    }
}
