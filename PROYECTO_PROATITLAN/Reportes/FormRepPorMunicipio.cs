using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using Entidades;
using Negocio;

namespace PROYECTO_PROATITLAN
{
    public partial class FormRepPorMunicipio : Form
    {
        Reportes.CrystalReportMunicipio info = new Reportes.CrystalReportMunicipio();
        ParameterValues valor = new ParameterValues();
        ParameterDiscreteValue dis = new ParameterDiscreteValue();

        public FormRepPorMunicipio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            valor.Clear();
            dis.Value = Convert.ToInt32(comboBox1.SelectedValue);
            valor.Add(dis);

            info.DataDefinition.ParameterFields["id"].ApplyCurrentValues(valor);

            crystalReportViewer1.ReportSource = info;
        }

        private void FormRepPorMunicipio_Load(object sender, EventArgs e)
        {
            DataTable datos = new DataTable();
            datos = NMunicipio.ListaMunicipios();
            comboBox1.DataSource = datos;
            comboBox1.DisplayMember = "Municipio";
            comboBox1.ValueMember = "Id_Municipio";
        }
    }
}
