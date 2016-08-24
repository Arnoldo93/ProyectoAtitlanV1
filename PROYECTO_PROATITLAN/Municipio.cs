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
using MySql.Data.MySqlClient;
using MySql.Data;
using Entidades;
using Negocio;

namespace PROYECTO_PROATITLAN
{
    public partial class Municipio : Form
    {
        public Municipio()
        {
            InitializeComponent();
        }

        string zona="";

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (textBox2.Text != "")
            //    {
            //        Conexion con = new Conexion();
            //        string conexionbasededatos = con.Seconecto();
            //        string Consulta = "INSERT INTO municipio(Id_Municipio,Nombre,Id_Zona) VALUES('" + Convert.ToInt32(textBox1.Text) + "','" + textBox2.Text + "','" + Convert.ToInt32(zona) + "')";
            //        MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            //        MySqlCommand mc = new MySqlCommand(Consulta, cnn);
            //        cnn.Open();
            //        if (mc.ExecuteNonQuery() > 0)
            //        {
            //            cnn.Close();
            //            MessageBox.Show("Se Guardo correctamente.");
            //            id_municipio();
            //            limpiar();
            //            listarmunicipios();
            //            listarZonas();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Error verifique sus datos.",
            //            "Critical Warning",
            //            MessageBoxButtons.OK,
            //            MessageBoxIcon.Error,
            //            MessageBoxDefaultButton.Button1,
            //            MessageBoxOptions.RtlReading,
            //            true);
            //            limpiar();
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Error verifique sus datos.",
            //           "Critical Warning",
            //           MessageBoxButtons.OK,
            //           MessageBoxIcon.Error,
            //           MessageBoxDefaultButton.Button1,
            //           MessageBoxOptions.RtlReading,
            //           true);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}


            try
            {
                if (textBox2.Text != "")
                {
                    var c = new DMunicipio();
                    c.Id_Municipio = Convert.ToInt32(textBox1.Text);
                    c.Nombre = textBox2.Text;
                    c.Id_zona =Convert.ToInt32( zona);
                    if (NMunicipio.Agregar(c))
                    {
                        MessageBox.Show("Datos guardados correctamente", "Aviso");
                        id_municipio();
                        listarmunicipios();
                        listarZonas();
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
            //    string Consulta = "update municipio set Id_Municipio='" + int.Parse(textBox1.Text) + "',Nombre='" + this.textBox2.Text + "',Id_Zona='" + int.Parse(zona) + "' where Id_Municipio='" + int.Parse(textBox1.Text) + "';";

            //    MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            //    MySqlCommand mc = new MySqlCommand(Consulta, cnn);
            //    cnn.Open();
            //    if (mc.ExecuteNonQuery() > 0)
            //    {
            //        cnn.Close();
            //        MessageBox.Show("Se actualizo Correctamente.");
            //        id_municipio();
            //        limpiar();
            //        listarmunicipios();
            //        listarZonas();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Error verifique sus datos.",
            //        "Critical Warning",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Error,
            //        MessageBoxDefaultButton.Button1,
            //        MessageBoxOptions.RtlReading,
            //        true);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}


            try
            {
                
                    var c = new DMunicipio();
                    c.Id_Municipio = Convert.ToInt32(textBox1.Text);
                    c.Nombre = textBox2.Text;
                    c.Id_zona = Convert.ToInt32(zona);
                    if (NMunicipio.Actualizar(c))
                    {
                        MessageBox.Show("Datos guardados correctamente", "Aviso");
                        id_municipio();
                        listarmunicipios();
                        listarZonas();
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

        private void button3_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Conexion con = new Conexion();
            //    string conexionbasededatos = con.Seconecto();

            //    string Consulta = "delete from municipio where Id_Zona='" + int.Parse(this.textBox1.Text) + "';";

            //    MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            //    MySqlCommand mc = new MySqlCommand(Consulta, cnn);
            //    cnn.Open();
            //    if (mc.ExecuteNonQuery() > 0)
            //    {
            //        cnn.Close();
            //        MessageBox.Show("Se elimino correctamente.");
            //        listarmunicipios();
            //        id_municipio();
            //        limpiar();
            //        listarZonas();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Error verifique sus datos.",
            //        "Critical Warning",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Error,
            //        MessageBoxDefaultButton.Button1,
            //        MessageBoxOptions.RtlReading,
            //        true);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}


            try
            {
                
                    var c = new DMunicipio();
                    c.Id_Municipio = Convert.ToInt32(textBox1.Text);
  
                    if (NMunicipio.Eliminar(c))
                    {
                        MessageBox.Show("Datos guardados correctamente", "Aviso");
                        id_municipio();
                        listarmunicipios();
                        listarZonas();
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

        private void listarmunicipios()
        {
            Conexion con = new Conexion();
            string conexionbasededatos = con.Seconecto();
            string Consulta = "SELECT  municipio.Id_Municipio,municipio.Nombre as Municipio,municipio.Id_Zona,zona_gestiom.Nombre as Zona FROM proatitlan.municipio, proatitlan.zona_gestiom where municipio.Id_Zona = zona_gestiom.Id_Zona";
            MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            MySqlDataAdapter mdatos = new MySqlDataAdapter(Consulta, cnn);
            DataTable dtDatos = new DataTable();
            cnn.Open();
            mdatos.Fill(dtDatos);
            dataGridView1.DataSource = dtDatos;
            dataGridView1.Refresh();
            this.dataGridView1.Columns["Id_Zona"].Visible = false;
            cnn.Close();
        }

        private void id_municipio()
        {
            Conexion con = new Conexion();
            string conexionbasededatos = con.Seconecto();
            string Consulta = "select IFNULL (max(Id_Municipio),0) from municipio";
            MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            MySqlCommand mc = new MySqlCommand(Consulta, cnn);
            cnn.Open();
            int val = Convert.ToInt32(mc.ExecuteScalar()) + 1;
            textBox1.Text = val.ToString();
            cnn.Close();
        }

        private void listarZonas()
        {
            Conexion con = new Conexion();
            string conexionbasededatos = con.Seconecto();
            string Consulta = "Select * from zona_gestiom";
            MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            MySqlDataAdapter mdatos = new MySqlDataAdapter(Consulta, cnn);
            cnn.Open();
            DataTable dtDatos = new DataTable();
            mdatos.Fill(dtDatos);
            comboBox1.DataSource = dtDatos;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Id_Zona";
            cnn.Close();
        }

        private void limpiar()
        {
            textBox2.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            id_municipio();
            limpiar();
            listarmunicipios();
            listarZonas();
        }

        private void Municipio_Load(object sender, EventArgs e)
        {
            id_municipio();
            limpiar();
            listarmunicipios();
            listarZonas();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "Solola";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "San Jorge La Laguna";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "Panajachel";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "Santa Catarina Papoló";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "San Antonio Papoló";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "San Lucas Tolimán";
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "Santiago Atitlán";
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "San Pedro La Laguna";
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "San Juan La Laguna";
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "Santa María Visitación";
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "Santa Clara La Laguna";
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "San Pablo La Laguna";
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "San Marcos La Laguna";
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "Tzununá";
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "Santa Cruz La Laguna";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            zona = comboBox1.SelectedValue.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            textBox2.Text = dataGridView1[1, e.RowIndex].Value.ToString();
            comboBox1.SelectedValue = dataGridView1[2, e.RowIndex].Value;
        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton15_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox2.Text = "Solola";
        }
    }
}
