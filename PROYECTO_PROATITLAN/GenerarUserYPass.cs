using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYECTO_PROATITLAN
{
    public partial class GenerarUserYPass : Form
    {
        public GenerarUserYPass()
        {
            InitializeComponent();
        }
        public string nombre;

        //El delegado tiene la firma de una funcion.
        //Nombre y parametro
        public delegate void Delegado1(string usuario, string pas,string nombre);
        public event Delegado1 FuncionAEecutar;

        //generador de password
        public static string CreateRandomPassword(int PasswordLength)
        {
            string _allowedChars = "abcdefghijkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ23456789!@$?";
            Byte[] randomBytes = new Byte[PasswordLength];
            char[] chars = new char[PasswordLength];
            int allowedCharCount = _allowedChars.Length;

            for (int i = 0; i < PasswordLength; i++)
            {
                Random randomObj = new Random();
                randomObj.NextBytes(randomBytes);
                chars[i] = _allowedChars[(int)randomBytes[i] % allowedCharCount];
            }

            return new string(chars);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //usuario
                string cadena = textBox2.Text.Trim().ToLower();
                string[] v;
                v = cadena.Split(' ');
                //label1.Text = (v[0].ToString() + v[1].ToString());
                textBox3.Text = (v[0].ToString().Substring(0, 3) + v[1].ToString().Substring(0, 3) + v[2].ToString().Substring(0, 3));
                //pasword
                textBox1.Text = CreateRandomPassword(6);
                //habilitar boton de imprimir
                button2.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Ingreso nombre completo para generar la contraseña.", "Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox1.Text != "")
            {

                FuncionAEecutar(textBox3.Text, textBox1.Text,textBox2.Text);
            }
            else
            {
                MessageBox.Show("Se deben generar los datos antes de pasarse.", "Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            System.Drawing.Printing.PrintDocument printDocument1 = new System.Drawing.Printing.PrintDocument();
            Graphics g = this.panel1.CreateGraphics();
            Bitmap bmp = new Bitmap(this.panel1.Width, this.panel1.Height);
            this.panel1.DrawToBitmap(bmp, new Rectangle(0, 0, this.panel1.Width, this.panel1.Height));
            Image Img = (Image)bmp;
            this.BackColor = Color.LimeGreen;
            printDocument1.DefaultPageSettings.Landscape = true;// Imprimir Horizontal
            printDocument1.PrintPage += (a, b) => { b.Graphics.DrawImage(Img, 50, 50); };
            printDocument1.Print();
        }

        private void GenerarUserYPass_Load(object sender, EventArgs e)
        {
            textBox2.Text = nombre.ToUpper();

        }
    }
}
