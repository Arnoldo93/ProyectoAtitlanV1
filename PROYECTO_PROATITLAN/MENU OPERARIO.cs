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
    }
}
