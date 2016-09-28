using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;
using System.IO;

namespace PROYECTO_PROATITLAN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            foreach (Control control in this.Controls)

                if (control is MdiClient)

                {

                    MethodInfo method = ((MdiClient)control).GetType().GetMethod("SetStyle", BindingFlags.Instance | BindingFlags.NonPublic);

                    method.Invoke((MdiClient)control, new Object[] { ControlStyles.OptimizedDoubleBuffer, true });

                }
        }
        Form Empleado,Tipoempleado,centro,municipio,tipocentro,zona,familia,categoria,subcategoria,medida,desechos,vehiculo,ingresodesechos,
            tipocliente,cliente,venta,moneda,reportesexistencias;
        string opcion;

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
            toolStripStatusLabel1.Text=Program.puesto+": ";
            toolStripStatusLabel3.Text = Program.usuario;
        }
   
        private void buttonItem19_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(centro))
            {
                centro = new Centro();
                centro.MdiParent = this;
                centro.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                centro.Focus();
            }
        }

        private void buttonItem18_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(tipocentro))
            {
                tipocentro = new Tipo_Centro();
                tipocentro.MdiParent = this;
                tipocentro.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tipocentro.Focus();
            }
        }

        private void buttonItem21_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(categoria))
            {
                categoria = new Categoria();
                categoria.MdiParent = this;
                categoria.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                categoria.Focus();
            }
        }

        private void buttonItem1_Click(object sender, EventArgs e)
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

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "Bitmap files (*.bmp)|*.bmp|Gif files (*.gif)|*.gif|JGP files (*.jpg)|*.jpg|All (*.*)|*.* |PNG (*.png)|*.png ";
                openFileDialog1.FilterIndex = 3;
                openFileDialog1.FileName = "Seleccione una imagen";
                openFileDialog1.Title = "Escoja una imagen";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    opcion = openFileDialog1.FileName;
                    BackgroundImage = Image.FromFile(opcion);
                    //guardar archivo
                    StreamWriter escrito = File.CreateText(@"fondo.txt");
                    string contenido = opcion;
                    escrito.Write(contenido.ToString());
                    escrito.Flush();
                    //Cerramos
                    escrito.Close();

                    //System.IO.StreamReader sr = new System.IO.StreamReader(fic);
                    //dir = sr.ReadToEnd();
                    //
                    //sr.Close();
                    BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Intente de nuevo.","Error");
            }

            //openFileDialog1.Filter = "Sólo imágenes|*.jpg;*.pgn;*.gif";
            //openFileDialog1.Title = "Selecciona una imágen";
            //openFileDialog1.InitialDirectory = Environment.GetFolderPath(
            //    Environment.SpecialFolder.MyDocuments);
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    this.BackgroundImage = Image.FromFile(openFileDialog1.FileName);
            //}
        }

        private void buttonItem29_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(venta))
            {
                venta = new VentaDesechos();
                venta.MdiParent = this;
                venta.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                venta.Focus();
            }
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem31_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void buttonItem32_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void buttonItem33_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void EMPLEADOS_DoubleClick(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Refresh();
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.OfType<MdiClient>().First().BackgroundImage = new Bitmap(@"fondo.png");
            Form f = new Form();
            f.MdiParent = this;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            f.Refresh();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
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
            catch(Exception)
            {
                Application.Exit();
            }
        }

        private void buttonItem34_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(tipocliente))
            {
                tipocliente = new TipoDeCliente();
                tipocliente.MdiParent = this;
                tipocliente.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tipocliente.Focus();
            }
        }

        private void buttonItem27_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(reportesexistencias))
            {
                reportesexistencias = new ReporteExistencias();
                reportesexistencias.MdiParent = this;
                reportesexistencias.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reportesexistencias.Focus();
            }
        }

        private void buttonItem35_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(cliente))
            {
                cliente = new Clientes();
                cliente.MdiParent = this;
                cliente.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cliente.Focus();
            }
        }

        private void buttonItem30_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(moneda))
            {
                moneda = new Moneda();
                moneda.MdiParent = this;
                moneda.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                moneda.Focus();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            usuario();
            imagendefondo();
            Login l = new Login();
            l.Close();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

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
            catch(Exception)
            {
                BackgroundImageLayout = ImageLayout.Stretch;
                Controls.OfType<MdiClient>().First().BackgroundImage = new Bitmap(@"fondo.png");
                Form f = new Form();
                f.MdiParent = this;
                SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                f.Refresh();
            }
        }

        private void buttonItem13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonItem26_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(ingresodesechos))
            {
                ingresodesechos = new IngresoDesechos();
                ingresodesechos.MdiParent = this;
                ingresodesechos.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ingresodesechos.Focus();
            }
        }

        private void buttonItem25_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(vehiculo))
            {
                vehiculo = new Vehiculo();
                vehiculo.MdiParent = this;
                vehiculo.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vehiculo.Focus();
            }
        }

        private void buttonItem24_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(desechos))
            {
                desechos = new Desechos();
                desechos.MdiParent = this;
                desechos.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                desechos.Focus();
            }
        }

        private void buttonItem23_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(medida))
            {
                medida = new Medida();
                medida.MdiParent = this;
                medida.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                medida.Focus();
            }
        }

        private void buttonItem22_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(subcategoria))
            {
                subcategoria = new SubCategoria_Desechos();
                subcategoria.MdiParent = this;
                subcategoria.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                subcategoria.Focus();
            }
        }

        private void buttonItem20_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(familia))
            {
                familia = new Familia();
                familia.MdiParent = this;
                familia.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                familia.Focus();
            }
        }

        public void buttonItem17_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(municipio))
            {
                municipio = new Municipio();
                municipio.MdiParent = this;
                municipio.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                municipio.Focus();
            }
        }

        private void buttonItem16_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(zona))
            {
                zona = new ZonaDeGestion();
                zona.MdiParent = this;
                zona.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                zona.Focus();
            }
        }

        private void buttonItem15_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(Empleado))
            {
                Empleado = new Empleado();
                Empleado.MdiParent = this;
                Empleado.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Empleado.Focus();
            }
        }

        private void buttonItem14_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(Tipoempleado))
            {
                Tipoempleado = new Puesto();
                Tipoempleado.MdiParent = this;
                Tipoempleado.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Tipoempleado.Focus();
            }
        }
    }
}
