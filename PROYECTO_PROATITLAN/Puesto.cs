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
    public partial class Puesto : Form
    {
        public Puesto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TipoPuesto tipo = new TipoPuesto();
            //tipo.Id_Puesto =Convert.ToInt32( textBox1.Text);
            //tipo.Nombre_puesto = textBox2.Text;

            //try
            //{
            //    if (textBox2.Text !="")
            //    {
            //        Conexion con = new Conexion();
            //        string conexionbasededatos = con.Seconecto();
            //        string Consulta = "INSERT INTO puesto(Id_Puesto,Nombre_Puesto) VALUES('" + tipo.Id_Puesto + "','" + tipo.Nombre_puesto + "')";
            //        MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            //        MySqlCommand mc = new MySqlCommand(Consulta, cnn);
            //        cnn.Open();
            //        if (mc.ExecuteNonQuery() > 0)
            //        {
            //            MessageBox.Show("Se Guardo Correctamente.");
            //        }
            //        else
            //        {
            //            MessageBox.Show("Error verifique sus datos.",
            //         "Critical Warning",
            //         MessageBoxButtons.OK,
            //         MessageBoxIcon.Error,
            //         MessageBoxDefaultButton.Button1,
            //         MessageBoxOptions.RtlReading,
            //         true);
            //        }
            //        cnn.Close();
            //        limpiar();
            //        id_puesto();
            //        ListaPuestos();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Error verifique sus datos.",
            //         "Critical Warning",
            //         MessageBoxButtons.OK,
            //         MessageBoxIcon.Error,
            //         MessageBoxDefaultButton.Button1,
            //         MessageBoxOptions.RtlReading,
            //         true);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            //ListaPuestos();
            try
            {
                if (textBox2.Text != "")
                {
                    var c = new Dpuesto();
                    c.Id_puesto = Convert.ToInt32(textBox1.Text);
                    c.Nombre_puesto = textBox2.Text;
                    if (Npuesto.Guardar(c))
                    {
                        MessageBox.Show("Datos Guardados Correctamente");
                        id_puesto();
                        limpiar();
                        ListaPuestos();
                    }
                }

                else
                {
                    MessageBox.Show("Error", "Aviso");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //try
            //{

            //        Conexion con = new Conexion();
            //        string conexionbasededatos = con.Seconecto();
            //        string Consulta = "update puesto set Id_Puesto='" + int.Parse(textBox1.Text) + "',Nombre_Puesto='" + this.textBox2.Text + "' where Id_Puesto='" + Convert.ToInt32(this.textBox1.Text) + "';";

            //        MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            //        MySqlCommand mc = new MySqlCommand(Consulta, cnn);
            //        cnn.Open();
            //        if (mc.ExecuteNonQuery() > 0)
            //        {
            //            MessageBox.Show("Se Actualizao Correctamente.");
            //        }
            //        else
            //        {
            //         MessageBox.Show("Error verifique sus datos.",
            //         "Critical Warning",
            //         MessageBoxButtons.OK,
            //         MessageBoxIcon.Error,
            //         MessageBoxDefaultButton.Button1,
            //         MessageBoxOptions.RtlReading,
            //         true);
            //        }
            //        cnn.Close();
            //        limpiar();
            //        ListaPuestos();
            //        id_puesto();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //ListaPuestos();


            try
            {
                    var c = new Dpuesto();
                    c.Id_puesto = Convert.ToInt32(textBox1.Text);
                    c.Nombre_puesto = textBox2.Text;

                if (Npuesto.Actualizar(c))
                {
                    MessageBox.Show("Datos guardados correctamente", "Aviso");
                    id_puesto();
                    limpiar();
                    ListaPuestos();
                }
                else
                {
                    MessageBox.Show("Error", "Aviso");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Conexion con = new Conexion();
            //    string conexionbasededatos = con.Seconecto();

            //    string Consulta = "delete from puesto where Id_Puesto='" + int.Parse( this.textBox1.Text) + "';";

            //    MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            //    MySqlCommand mc = new MySqlCommand(Consulta, cnn);
            //    cnn.Open();
            //    if (mc.ExecuteNonQuery() > 0)
            //    {
            //        MessageBox.Show("Se Elimino Correctamente.");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Error verifique sus datos.",
            //     "Critical Warning",
            //     MessageBoxButtons.OK,
            //     MessageBoxIcon.Error,
            //     MessageBoxDefaultButton.Button1,
            //     MessageBoxOptions.RtlReading,
            //     true);
            //    }
            //    cnn.Close();
            //    limpiar();
            //    ListaPuestos();
            //   id_puesto();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            //ListaPuestos();



            try
            {
                var c = new Dpuesto();
                c.Id_puesto = Convert.ToInt32(textBox1.Text);
                c.Nombre_puesto = textBox2.Text;

                if (Npuesto.Eliminar(c))
                {
                    MessageBox.Show("Datos guardados correctamente", "Aviso");
                    id_puesto();
                    limpiar();
                    ListaPuestos();
                }
                else
                {
                    MessageBox.Show("Error", "Aviso");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void Puesto_Load(object sender, EventArgs e)
        {
            ListaPuestos();
            id_puesto();
        }

        private void ListaPuestos()
        {
            //Conexion con = new Conexion();
            //string conexionbasededatos = con.Seconecto();
            //string Consulta = "Select * From puesto";
            //MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            //MySqlDataAdapter mdatos = new MySqlDataAdapter(Consulta, cnn);
            //cnn.Open();
            //DataTable dtDatos = new DataTable();
            //mdatos.Fill(dtDatos);
            //dataGridView1.DataSource = dtDatos;
            //dataGridView1.Refresh();
            //cnn.Close();
            DataTable datos = new DataTable();
            datos =Npuesto.ListaPuesto();
            dataGridView1.DataSource = datos;
            dataGridView1.Refresh();            

        }

        private void id_puesto()
        {
            //Conexion con = new Conexion();
            //string conexionbasededatos = con.Seconecto();
            //string Consulta = "select IFNULL (max(Id_Puesto),0) from puesto";
            //MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            //MySqlCommand mc = new MySqlCommand(Consulta, cnn);
            //cnn.Open();
            //int val = Convert.ToInt32(mc.ExecuteScalar()) + 1;
            //textBox1.Text = val.ToString();
            //cnn.Close();
            var c = new Dpuesto();
            c.Id_puesto = Npuesto.Id() + 1;
            textBox1.Text = c.Id_puesto.ToString();
        }

        private void limpiar()
        {
            textBox2.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void groupPanel2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            textBox2.Text = dataGridView1[1, e.RowIndex].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            limpiar();
            ListaPuestos();
            id_puesto();
        }
    }
}
