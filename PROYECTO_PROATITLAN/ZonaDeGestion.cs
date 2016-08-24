using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using AccesoDatos;
using Entidades;
using Negocio;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace PROYECTO_PROATITLAN
{
    public partial class ZonaDeGestion : Form
    {
        public ZonaDeGestion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (textBox2.Text != "")
            //    {
            //        Conexion con = new Conexion();
            //        string conexionbasededatos = con.Seconecto();
            //        string Consulta = "INSERT INTO zona_gestiom(Id_Zona,Nombre) VALUES('" + Convert.ToInt32(textBox1.Text) + "','" + textBox2.Text + "')";

            //        MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            //        MySqlCommand mc = new MySqlCommand(Consulta, cnn);
            //        // MySqlDataReader MyReader2;

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
            //        limpiar();
            //        id_zona();
            //        listarZonas();
            //        cnn.Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Error");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error, vefique que los datos sean correctos", ex.ToString());
            //}


            try
            {
                if (textBox2.Text != "")
                {
                    var c = new DZona();
                    c.Id_zona = Convert.ToInt32(textBox1.Text);
                    c.Nombrezona = textBox2.Text;

                    if (NZona.Agregar(c))
                    {
                        MessageBox.Show("Datos guardados correctamente", "Aviso");
                        listarZonas();
                        id_zona();
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Error", "Aviso");
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
            //    Conexion con = new Conexion();
            //    string conexionbasededatos = con.Seconecto();
            //    string Consulta = "update zona_gestiom set Id_Zona='" +Convert.ToInt32(textBox1.Text) + "', Nombre='" + this.textBox2.Text + "' where Id_Zona='" +int.Parse( textBox1.Text) + "';";
            //    MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            //    MySqlCommand mc = new MySqlCommand(Consulta, cnn);
            //    cnn.Open();
            //    if (mc.ExecuteNonQuery() > 0)
            //    {
            //        MessageBox.Show("Datos actualizados correctamente.");
            //        limpiar();
            //        id_zona();
            //        listarZonas();
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
            //    cnn.Close();


            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}


            try
            {
                if (textBox2.Text != "")
                {
                    var c = new DZona();
                    c.Id_zona = Convert.ToInt32(textBox1.Text);
                    c.Nombrezona = textBox2.Text;

                    if (NZona.Actualizar(c))
                    {
                        MessageBox.Show("Datos guardados correctamente", "Aviso");
                        listarZonas();
                        id_zona();
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Error", "Aviso");
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

        private void button3_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Conexion con = new Conexion();
            //    string conexionbasededatos = con.Seconecto();

            //    string Consulta = "delete from zona_gestiom where Id_Zona='" + int.Parse(this.textBox1.Text) + "';";

            //    MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            //    MySqlCommand mc = new MySqlCommand(Consulta, cnn);
            //    cnn.Open();
            //    if (mc.ExecuteNonQuery() > 0)
            //    {
            //        MessageBox.Show("Se elimino correctamente.");
            //        limpiar();
            //        id_zona();
            //        listarZonas();
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
            //    cnn.Close();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error al eliminar", ex.ToString());
            //}



            try
            {
                    var c = new DZona();
                    c.Id_zona = Convert.ToInt32(textBox1.Text);

                    if (NZona.Eliminar(c))
                    {
                        MessageBox.Show("Datos guardados correctamente", "Aviso");
                        listarZonas();
                        id_zona();
                        limpiar();
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

        private void listarZonas()
        {
            Conexion con = new Conexion();
            string conexionbasededatos = con.Seconecto();
            string Consulta = "Select * From zona_gestiom";
            MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            MySqlDataAdapter mdatos = new MySqlDataAdapter(Consulta, cnn);
            cnn.Open();
            DataTable dtDatos = new DataTable();
            mdatos.Fill(dtDatos);
            dataGridView1.DataSource = dtDatos;
            dataGridView1.Refresh();
            cnn.Close();
        }

        private void id_zona()
        {
            Conexion con = new Conexion();
            string conexionbasededatos = con.Seconecto();
            string Consulta = "select IFNULL (max(Id_Zona),0) from zona_gestiom";
            MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            MySqlCommand mc = new MySqlCommand(Consulta, cnn);
            cnn.Open();
            int val =Convert.ToInt32( mc.ExecuteScalar())+1;
            textBox1.Text = val.ToString();
            cnn.Close();
        }

        private void limpiar()
        {
            textBox2.Clear();
        }

        private void ZonaDeGestion_Load(object sender, EventArgs e)
        {
            id_zona();
            listarZonas();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.Text = "Norte";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.Text = "Nor-Este";
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.Text = "Este";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.Text = "Sur-Este";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.Text = "Sur";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.Text = "Sur-Oeste";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.Text = "Oeste";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.Text = "Nor-Oeste";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            textBox2.Text = dataGridView1[1, e.RowIndex].Value.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            limpiar();
            id_zona();
            listarZonas();
        }
    }
}
