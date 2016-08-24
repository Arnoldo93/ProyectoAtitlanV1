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
    public partial class Tipo_Centro : Form
    {
        public Tipo_Centro()
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
            //        string Consulta = "INSERT INTO tipo_centro(Id_Tipo,Nombre) VALUES('" + Convert.ToInt32(textBox1.Text) + "','" + textBox2.Text + "')";
            //        MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            //        MySqlCommand mc = new MySqlCommand(Consulta, cnn);
            //        cnn.Open();
            //        if (mc.ExecuteNonQuery() > 0)
            //        { 
            //        cnn.Close();
            //        MessageBox.Show("Se Guardo correctamente.");
            //        listartipocentro();
            //            id_tipocentro();
            //            limpiar();
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


            try
            {
                if (textBox2.Text != "")
                {
                    var c = new DTipoCentro();
                    c.Id_Tipocentro = Convert.ToInt32(textBox1.Text);
                    c.Nombre = textBox2.Text;

                    if (NTipoCentro.Agregar(c))
                    {
                        MessageBox.Show("Datos guardados correctamente", "Aviso");
                        id_tipocentro();
                        listartipocentro();
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
            //    string Consulta = "update tipo_centro set Id_Tipo='" + int.Parse(textBox1.Text) + "',Nombre='" + this.textBox2.Text + "' where Id_Tipo='" + int.Parse(textBox1.Text)+"';";

            //    MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            //    MySqlCommand mc = new MySqlCommand(Consulta, cnn);
            //    cnn.Open();
            //    if (mc.ExecuteNonQuery() > 0)
            //    {
            //        cnn.Close();
            //        MessageBox.Show("Datos Actualizados");
            //        id_tipocentro();
            //        limpiar();
            //        listartipocentro();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Error verifique sus datos.",
            //       "Critical Warning",
            //       MessageBoxButtons.OK,
            //       MessageBoxIcon.Error,
            //       MessageBoxDefaultButton.Button1,
            //       MessageBoxOptions.RtlReading,
            //       true);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error, no se pudo actualizar ", ex.ToString());
            //}


            try
            {
                
                    var c = new DTipoCentro();
                    c.Id_Tipocentro = Convert.ToInt32(textBox1.Text);
                    c.Nombre = textBox2.Text;

                    if (NTipoCentro.Actualizar(c))
                    {
                        MessageBox.Show("Datos guardados correctamente", "Aviso");
                        id_tipocentro();
                        listartipocentro();
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

            //    string Consulta = "delete from tipo_centro where Id_Tipo='" + int.Parse(this.textBox1.Text) + "';";

            //    MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            //    MySqlCommand mc = new MySqlCommand(Consulta, cnn);
            //    cnn.Open();
            //    if (mc.ExecuteNonQuery() > 0)
            //    {
            //        cnn.Close();
            //        MessageBox.Show("Se elimino correctamente.");
            //        id_tipocentro();
            //        limpiar();
            //        listartipocentro();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Error verifique sus datos.",
            //       "Critical Warning",
            //       MessageBoxButtons.OK,
            //       MessageBoxIcon.Error,
            //       MessageBoxDefaultButton.Button1,
            //       MessageBoxOptions.RtlReading,
            //       true);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error al eliminar", ex.ToString());
            //}


            try
            {
                
                    var c = new DTipoCentro();
                    c.Id_Tipocentro = Convert.ToInt32(textBox1.Text);

                    if (NTipoCentro.Eliminar(c))
                    {
                        MessageBox.Show("Elliminado correctamente.", "Aviso");
                        id_tipocentro();
                        listartipocentro();
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

        private void listartipocentro()
        {
            Conexion con = new Conexion();
            string conexionbasededatos = con.Seconecto();
            string Consulta = "Select * From tipo_centro";
            MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            MySqlDataAdapter mdatos = new MySqlDataAdapter(Consulta, cnn);
            cnn.Open();
            DataTable dtDatos = new DataTable();
            mdatos.Fill(dtDatos);
            dataGridView1.DataSource = dtDatos;
            dataGridView1.Refresh();
            cnn.Close();
        }

        private void id_tipocentro()
        {
            Conexion con = new Conexion();
            string conexionbasededatos = con.Seconecto();
            string Consulta = "select IFNULL (max(Id_Tipo),0) from tipo_centro";
            MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            MySqlCommand mc = new MySqlCommand(Consulta, cnn);
            cnn.Open();
            int val = Convert.ToInt32(mc.ExecuteScalar()) + 1;
            textBox1.Text = val.ToString();
            cnn.Close();
        }

        private void limpiar()
        {
            textBox2.Clear();
        }

        private void Tipo_Centro_Load(object sender, EventArgs e)
        {
            listartipocentro();
            id_tipocentro();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            textBox2.Text = dataGridView1[1, e.RowIndex].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listartipocentro();
            id_tipocentro();
            limpiar();
        }
    }
}
