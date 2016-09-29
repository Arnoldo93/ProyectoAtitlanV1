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
            if (Program.puesto == "ADMINISTRADOR")
            {
                DataTable datos = new DataTable();
                datos = NDatosCentro.ListaDatosCentro();
                comboBox1.DataSource = datos;
                comboBox1.DisplayMember = "Nombre_centro";
                comboBox1.ValueMember = "Id_Centro";
            }
            else
            {
                DataTable datos = new DataTable();
                datos = NDatosCentro.CentroEmpleado(Convert.ToInt32(Program.idempleado));
                comboBox1.DataSource = datos;
                comboBox1.DisplayMember = "Nombre_centro";
                comboBox1.ValueMember = "Id_Centro";
            }
        }

        public void listadoexistencias()
        {
            var ex = new DExistencias();
            ex.idcentro =Convert.ToInt32(comboBox1.SelectedValue);
            DataTable datos = new DataTable();
            datos = NExistencias.listadoexistencia(ex);
            dataGridViewX1.DataSource = datos;
            dataGridViewX1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listadoexistencias();
        }
    }
}
