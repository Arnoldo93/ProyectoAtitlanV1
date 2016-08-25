using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;
using Entidades;
using Negocio;

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
            var v = new DEmpleado();
            v.Usuario = textBox1.Text;
            v.Contrase_a = textBox2.Text;
            if (NEmpleado.loguin(v)==1)
            {
                MessageBox.Show("Bienvenido al Sistema.", "Aviso");
                Form1 f = new Form1();
                Program.usuario = v.Usuario;
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error, Ingrese un Usuario Valido","Aviso");
            }
        }
    }
}
