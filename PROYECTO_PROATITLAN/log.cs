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
using Entidades;
using Negocio;
using AccesoDatos;

namespace PROYECTO_PROATITLAN
{
    public partial class log : Form
    {
        public log()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable datos = new DataTable();
                datos = NEmpleado.logueo(textBox1.Text, textBox2.Text);
                string Id = datos.Rows[0][0].ToString();
                string nombre = datos.Rows[0][1].ToString();
                string puesto = datos.Rows[0][2].ToString();

                if (puesto == "Administrador")
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
            catch (Exception ex)
            {
                MessageBox.Show("Error, verifique sus datos.\nIngrese usuario y pasword valido.","Aviso");
            }
        }

        private void log_Load(object sender, EventArgs e)
        {
        }
    }
}
