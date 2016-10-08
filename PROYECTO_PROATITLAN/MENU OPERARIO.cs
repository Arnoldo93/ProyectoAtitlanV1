using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace PROYECTO_PROATITLAN
{
    public partial class MENU_OPERARIO : Form
    {
        public MENU_OPERARIO()
        {
            InitializeComponent();
            //codigo para que no parpadeen los formularios
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            foreach (Control control in this.Controls)

                if (control is MdiClient)

                {

                    MethodInfo method = ((MdiClient)control).GetType().GetMethod("SetStyle", BindingFlags.Instance | BindingFlags.NonPublic);

                    method.Invoke((MdiClient)control, new Object[] { ControlStyles.OptimizedDoubleBuffer, true });

                }
        }

        Form ingresodesechos, ventadesechos, cliente, tipocliente, reportesexistencias, reporteBuscaFacturasPorFecha,reportezonagestiondetalle;

        //codigo para que no parpadeen los formularios
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private void usuario()
        {
            Login l = new Login();
            toolStripStatusLabel1.Text = Program.puesto + ": ";
            toolStripStatusLabel3.Text = Program.usuario;
        }

        private void buttonItem56_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(ventadesechos))
            {
                ventadesechos = new VentaDesechos();
                ventadesechos.MdiParent = this;
                styleManager1.ManagerColorTint = Color.MediumSeaGreen;
                ventadesechos.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ventadesechos.Focus();
            }
        }

        private void buttonItem55_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(tipocliente))
            {
                tipocliente = new TipoDeCliente();
                tipocliente.MdiParent = this;
                styleManager1.ManagerColorTint = Color.MediumSeaGreen;
                tipocliente.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tipocliente.Focus();
            }
        }

        private void buttonItem54_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(cliente))
            {
                cliente = new Clientes();
                cliente.MdiParent = this;
                styleManager1.ManagerColorTint = Color.MediumSeaGreen;
                cliente.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cliente.Focus();
            }
        }

        private void buttonItem53_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(reportesexistencias))
            {
                reportesexistencias = new ReporteExistencias();
                reportesexistencias.MdiParent = this;
                styleManager1.ManagerColorTint = Color.MediumSeaGreen;
                reportesexistencias.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reportesexistencias.Focus();
            }
        }

        private void buttonItem52_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(reporteBuscaFacturasPorFecha))
            {
                reporteBuscaFacturasPorFecha = new ReporteVentasPorFechas();
                reporteBuscaFacturasPorFecha.MdiParent = this;
                styleManager1.ManagerColorTint = Color.MediumSeaGreen;
                reporteBuscaFacturasPorFecha.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reporteBuscaFacturasPorFecha.Focus();
            }
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            /////////////////////////////////////////
            if (!this.MdiChildren.Contains(reportezonagestiondetalle))
            {
                reportezonagestiondetalle = new ReportePorZonaDeGestion();
                reportezonagestiondetalle.MdiParent = this;
                styleManager1.ManagerColorTint = Color.MediumSeaGreen;
                reportezonagestiondetalle.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reportezonagestiondetalle.Focus();
            }
        }

        private void MENU_OPERARIO_Load(object sender, EventArgs e)
        {
            usuario();
            imagendefondo();
            Login l = new Login();
            l.Close();
        }

        private void MENU_OPERARIO_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.MdiChildren.Length > 1)
                {
                    //MessageBox.Show(this.ActiveMdiChild.Text);
                    MessageBox.Show("Cierre todos los formularios antes de salir\n\n Formulario activo:" + this.ActiveMdiChild.Text, "Aviso");
                    e.Cancel = true;
                }
                else
                {
                    Application.Exit();
                }
            }
            catch (Exception)
            {
                Application.Exit();
            }
        }

        private void imagendefondo()
        {
            try
            {
                //Crea archivo de ruta de imagen 
                StreamReader leido = File.OpenText(@"fondo.txt");
                //Variable que contendrá el archivo
                string contenido = null;
                //Leemos todo el archivo
                contenido = leido.ReadToEnd();
                //Lo mostramos
                //Cerramos
                leido.Close();

                //buscar la imgen y la agrega de fondo
                DoubleBuffered = true;

                BackgroundImageLayout = ImageLayout.Stretch;
                Controls.OfType<MdiClient>().First().BackgroundImage = new Bitmap(@contenido.ToString());
                Form f = new Form();
                f.MdiParent = this;
                SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                f.Refresh();
            }
            catch (Exception)
            {
                BackgroundImageLayout = ImageLayout.Stretch;
                Controls.OfType<MdiClient>().First().BackgroundImage = new Bitmap(@"fondo.png");
                Form f = new Form();
                f.MdiParent = this;
                SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                f.Refresh();
            }
        }

        private void buttonItem86_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length > 1)
            {
                MessageBox.Show("Cierre todos los formularios antes de salir", "Aviso");
            }
            else
            {
                this.Hide();
                Login l = new Login();
                l.Show();
            }
        }

        private void buttonItem65_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(ingresodesechos))
            {
                ingresodesechos = new IngresoDesechos();
                ingresodesechos.MdiParent = this;
                styleManager1.ManagerColorTint = Color.MediumSeaGreen;
                ingresodesechos.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ingresodesechos.Focus();
            }
        }
    }
}
