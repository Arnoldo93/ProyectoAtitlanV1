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
using CrystalDecisions.Shared;

namespace PROYECTO_PROATITLAN
{
    public partial class RepExistenciaPorCentros : Form
    {
        Reportes.CrystalReportExistenciaPorCentro info = new Reportes.CrystalReportExistenciaPorCentro ();
        ParameterValues valor = new ParameterValues();
        ParameterDiscreteValue dis = new ParameterDiscreteValue();
        public RepExistenciaPorCentros()
        {
            InitializeComponent();
        }

        private void RepExistenciaPorCentros_Load(object sender, EventArgs e)
        {
            DataTable datos = new DataTable();
            datos = NDatosCentro.ListaDatosCentro();
            comboBox1.DataSource = datos;
            comboBox1.DisplayMember = "Nombre_centro";
            comboBox1.ValueMember = "Id_Centro";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            valor.Clear();
            dis.Value = Convert.ToInt32(comboBox1.SelectedValue);
            valor.Add(dis);
            info.DataDefinition.ParameterFields["idcentro"].ApplyCurrentValues(valor);
            crystalReportViewer1.ReportSource = info;
        }
    }
}
