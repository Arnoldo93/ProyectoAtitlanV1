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
            //foreach(var i in NEmpleado.logueo(textBox1.Text,textBox2.Text))
            //{
            //    dataGridView1.Rows.Add(i.Id_Puesto, i.Nombre);
            //}

            ////var l = new  DEmpleado();
            ////l.Usuario = textBox1.Text;
            ////l.Contrase_a = textBox2.Text;
            ////if (NEmpleado.loguin(l)== 1)
            ////{
            ////    MessageBox.Show("Bienvenido al Sistema", "Aviso.");
            ////    Form1 f = new Form1();
            ////    Program.usuario = l.Usuario;
            ////    f.Show();
            ////    this.Hide();
            ////}
            ////else
            ////{
            ////    MessageBox.Show("Error, verifique sus datos","Aviso");
            ////}
            try
            {
                DataTable datos = new DataTable();
                datos = NEmpleado.logueo(textBox1.Text, textBox2.Text);
                string Id = datos.Rows[0][0].ToString();
                string nombre = datos.Rows[0][1].ToString();
                string puesto = datos.Rows[0][2].ToString();
                label1.Text = nombre;

                if (puesto == "Administrador")
                {
                    MessageBox.Show("Bienvenido al Sistema", "Aviso.");
                    Form1 f = new Form1();
                    Program.idempleado = Id;
                    Program.puesto = puesto;
                    Program.usuario = nombre;
                    f.Show();
                    this.Hide();
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
    }
}
