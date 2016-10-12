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
    public partial class RepProduccionPorZona : Form
    {
        Reportes.CrystalReportProduccionPorZona info = new   Reportes.CrystalReportProduccionPorZona  ();
        ParameterValues valor = new ParameterValues();
        ParameterDiscreteValue dis = new ParameterDiscreteValue();

        public RepProduccionPorZona()
        {
            InitializeComponent();
        }

        private void RepProduccionPorZona_Load(object sender, EventArgs e)
        {
            DataTable datos = new DataTable();
            datos = NZona.ListaZona();
            comboBox1.DataSource = datos;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Id_Zona";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            valor.Clear();
            dis.Value = Convert.ToInt32(comboBox1.SelectedValue);
            valor.Add(dis);
            info.DataDefinition.ParameterFields["idzona"].ApplyCurrentValues(valor);


            valor.Clear();
            dis.Value = Convert.ToDateTime(dateTimePicker1.Value);
            valor.Add(dis);
            info.DataDefinition.ParameterFields["fecha1"].ApplyCurrentValues(valor);


            valor.Clear();
            dis.Value = Convert.ToDateTime(dateTimePicker2.Value);
            valor.Add(dis);
            info.DataDefinition.ParameterFields["fecha2"].ApplyCurrentValues(valor);
            crystalReportViewer1.ReportSource = info;
        }
    }
}
