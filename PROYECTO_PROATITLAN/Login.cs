using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using AccesoDatos;
using Negocio;
using Entidades;

namespace PROYECTO_PROATITLAN
{
    public partial class Login : Form
    {
        Point FormPosition;
        Boolean mouseAction;
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseAction==true)
            {
                Location = new Point(Cursor.Position.X - FormPosition.X, Cursor.Position.Y - FormPosition.Y);
           
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            FormPosition = new Point(Cursor.Position.X -Location.X, Cursor.Position.Y - Location.Y);
            mouseAction = true;

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseAction = false;    
        }

        private void button2_Click(object sender, EventArgs e)
        {
         //NO USAR   
        }

        private void button1_Click(object sender, EventArgs e)
        {
           //NO USAR
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Seleccion_Mapas n = new Seleccion_Mapas();

            try
            {
                if (NEmpleado.logprimeravez() <= 0)
                {

                    if (textBox1.Text == "admin" && textBox2.Text == "admin")
                    {
                        Form1 f = new Form1();
                        
                        f.Show();
                        textBox1.Clear();
                        textBox2.Clear();
                    }

                }
                else
                {
                    DataTable datos = new DataTable();
                    datos = NEmpleado.logueo(textBox1.Text, textBox2.Text);
                    string Id = datos.Rows[0][0].ToString();
                    string nombre = datos.Rows[0][1].ToString();
                    string puesto = datos.Rows[0][2].ToString();

                    if (puesto == "ADMINISTRADOR")
                    {
                        MessageBox.Show("Bienvenido al Sistema", "Aviso.");
                        Form1 f = new Form1();
                        textBox1.Clear();
                        textBox2.Clear();
                        Program.idempleado = Id;
                        Program.puesto = puesto;
                        Program.usuario = nombre;
                        f.Show();
                    }
                    else
                    {
                        MessageBox.Show("Error, verifique sus datos", "Aviso");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error, verifique sus datos.\nIngrese usuario y pasword valido.", "Aviso");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Desea salir del programa", "Advertencia", MessageBoxButtons.OKCancel)==DialogResult.OK)

            {
                Application.Exit();
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //int alto=Screen.PrimaryScreen.Bounds.Height ;
            //int ancho = Screen.PrimaryScreen.Bounds.Width;
          //  this.Size = new Size(alto, ancho);
            
            label1.Text = DateTime.Now.ToLongTimeString();
            label2.Text = DateTime.Now.ToLongDateString();  
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
                label1.Text = DateTime.Now.ToLongTimeString();
            
            }
    }
}
