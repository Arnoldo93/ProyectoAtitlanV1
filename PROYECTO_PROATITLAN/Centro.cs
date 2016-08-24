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
    public partial class Centro : Form
    {
        public Centro()
        {
            InitializeComponent();
        }
        string municipio,tipo_centro;
        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (textBox5.Text != "" || textBox6.Text != "" || textBox7.Text != "")
            //    {
            //        if (checkBox1.Checked != false)
            //        {
            //            checkBox1.Checked = true;
            //        }
            //        else
            //        {
            //            checkBox1.Checked = false;
            //        }
            //        Conexion con = new Conexion();
            //        string conexionbasededatos = con.Seconecto();
            //        string Consulta = "INSERT INTO centro(Id_Centro,Nombre_centro,Id_Municipio,Id_Tipo,Telefono,Direccion,Estado_centro) VALUES('" + Convert.ToInt32(textBox1.Text) + "','" + textBox5.Text + "','" +Convert.ToInt32( municipio) + "','" +Convert.ToInt32( tipo_centro) + "','" + int.Parse(textBox6.Text) + "','" + textBox7.Text + "','" + Convert.ToByte(checkBox1.Checked) + "')";
            //        MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            //        MySqlCommand mc = new MySqlCommand(Consulta, cnn);
            //        cnn.Open();
            //        if (mc.ExecuteNonQuery() > 0)
            //        {
            //            cnn.Close();
            //            MessageBox.Show("Se Guardo correctamente.");
            //            ListaCentros();
            //            ListaMunicipio();
            //            ListaTipocentro();
            //            id_centro();
            //            limpiar();

            //        }
            //        else
            //        {
            //            MessageBox.Show("Error verifique sus datos.",
            //        "Critical Warning",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Error,
            //        MessageBoxDefaultButton.Button1,
            //        MessageBoxOptions.RtlReading,
            //        true);
            //        }

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
                if (textBox5.Text != "")
                {
                    if (checkBox1.Checked != false)
                    {
                        checkBox1.Checked = true;
                    }
                    else
                    {
                        checkBox1.Checked = false;
                    }
                    var c = new DDatosCentro();
                    c.Id_Centro = Convert.ToInt32(textBox1.Text);
                    c.Nombre = textBox5.Text;
                    c.Id_Municipio =Convert.ToInt32(municipio);
                    c.Id_tipo =Convert.ToInt32 (tipo_centro);
                    c.Telefono =Convert.ToInt32 ( textBox6.Text);
                    c.Direccion = textBox7.Text;
                    c.Estado = Convert.ToByte(checkBox1.Checked);

                    if (NDatosCentro.Agregar(c))
                    {
                        MessageBox.Show("Datos guardados correctamente", "Aviso");
                        limpiar();
                        ListaCentros();
                        ListaMunicipio();
                        ListaTipocentro();
                        id_centro();
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
            //    string Consulta = "UPDATE centro SET Id_Centro ='"+int.Parse(textBox1.Text)+"',Nombre_centro = '"+textBox5.Text+"', Id_Municipio = '"+Convert.ToInt32( municipio)+"',Id_Tipo = '"+Convert.ToInt32( tipo_centro)+"',Telefono = '"+int.Parse(textBox6.Text)+"',Direccion = '"+textBox7.Text+"',Estado_centro = '"+Convert.ToByte(checkBox1.Checked)+"' WHERE Id_Centro ='"+int.Parse(textBox1.Text)+"';";

            //    MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            //    MySqlCommand mc = new MySqlCommand(Consulta, cnn);
            //    cnn.Open();
            //    if (mc.ExecuteNonQuery() > 0)
            //    {
            //        cnn.Close();
            //        MessageBox.Show("Se actualizo Correctamente.");
            //        id_centro();
            //        limpiar();
            //        ListaCentros();
            //        ListaMunicipio();
            //        ListaTipocentro();
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
                if (checkBox1.Checked != false)
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }
                var c = new DDatosCentro();
                c.Id_Centro = Convert.ToInt32(textBox1.Text);
                c.Nombre = textBox5.Text;
                c.Id_Municipio = int.Parse(municipio);
                c.Id_tipo = int.Parse(tipo_centro);
                c.Telefono = int.Parse(textBox6.Text);
                c.Direccion = textBox7.Text;
                c.Estado = Convert.ToByte(checkBox1.Checked);

                if (NDatosCentro.Actualizar(c))
                {
                    MessageBox.Show("Datos guardados correctamente", "Aviso");
                    limpiar();
                    ListaCentros();
                    ListaMunicipio();
                    ListaTipocentro();
                    id_centro();
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

            //    string Consulta = "DELETE FROM centro WHERE Id_Centro='" + int.Parse(this.textBox1.Text) + "';";

            //    MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            //    MySqlCommand mc = new MySqlCommand(Consulta, cnn);
            //    cnn.Open();
            //    if (mc.ExecuteNonQuery() > 0)
            //    {
            //        cnn.Close();
            //        MessageBox.Show("Se Elimino Correctamente.");
            //        limpiar();
            //        id_centro();
            //        ListaCentros();
            //        ListaMunicipio();
            //        ListaTipocentro();
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
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}


            try
            {
                var c = new DDatosCentro();
                c.Id_Centro = Convert.ToInt32(textBox1.Text);

                if (NDatosCentro.Eliminar(c))
                {
                    MessageBox.Show("Eliminado correctamente.", "Aviso");
                    limpiar();
                    ListaCentros();
                    ListaMunicipio();
                    ListaTipocentro();
                    id_centro();
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

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ListaMunicipio();
        }

        private void groupPanel3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipo_centro =comboBox1.SelectedValue.ToString();
        }

        private void Centro_Load(object sender, EventArgs e)
        {
            id_centro();
            ListaCentros();
            ListaMunicipio();
            ListaTipocentro();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            municipio = comboBox2.SelectedValue.ToString(); 
        }

        private void button7_Click(object sender, EventArgs e)
        {
            id_centro();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            checkBox1.Checked = false;
            ListaCentros();
            ListaMunicipio();
            ListaTipocentro();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
                     
            //if (!MdiChildren.Contains(municipio))
            //{
            //    municipio = new Municipio();
            //    municipio.MdiParent = this;
            //    municipio.Show();
            //}
            //else
            //{
            //    MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    municipio.Focus();
            //}
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            Municipio muni = new Municipio();
            muni.MdiParent = this.MdiParent;
            muni.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            textBox5.Text = dataGridView1[1, e.RowIndex].Value.ToString();
            comboBox2.SelectedValue = dataGridView1[2, e.RowIndex].Value;
            comboBox1.SelectedValue = dataGridView1[4, e.RowIndex].Value;
            textBox6.Text = dataGridView1[6, e.RowIndex].Value.ToString();
            textBox7.Text = dataGridView1[7, e.RowIndex].Value.ToString();
            checkBox1.Checked =Convert.ToBoolean(dataGridView1[8, e.RowIndex].Value);

        }

        private void ListaCentros()
        {
            Conexion con = new Conexion();
            string conexionbasededatos = con.Seconecto();
            string Consulta = "SELECT centro.Id_Centro, centro.Nombre_centro,centro.Id_Municipio,municipio.Nombre as Nombre_Municipio,centro.Id_Tipo,tipo_centro.Nombre as Nombre_Tipo,centro.Telefono,centro.Direccion,centro.Estado_centro FROM proatitlan.centro, proatitlan.municipio,proatitlan.tipo_centro where centro.Id_Municipio = municipio.Id_Municipio and centro.Id_Tipo = tipo_centro.Id_Tipo";
            MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            MySqlDataAdapter mdatos = new MySqlDataAdapter(Consulta, cnn);
            DataTable dtDatos = new DataTable();
            mdatos.Fill(dtDatos);
            cnn.Open();
            dataGridView1.DataSource = dtDatos;
            dataGridView1.Refresh();
            dataGridView1.Columns["Id_Municipio"].Visible = false;
            dataGridView1.Columns["Id_Tipo"].Visible = false;
            cnn.Close();
        }

        private void ListaTipocentro()
        {
            Conexion con = new Conexion();
            string conexionbasededatos = con.Seconecto();
            string Consulta = "Select * From tipo_centro";
            MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            MySqlDataAdapter mdatos = new MySqlDataAdapter(Consulta, cnn);
            DataTable dtDatos = new DataTable();
            mdatos.Fill(dtDatos);
            cnn.Open();
            comboBox1.DataSource = dtDatos;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Id_Tipo";
            comboBox1.Refresh();
            cnn.Close();
        }

        private void ListaMunicipio()
        {
            Conexion con = new Conexion();
            string conexionbasededatos = con.Seconecto();
            string Consulta = "Select * From municipio";
            MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            MySqlDataAdapter mdatos = new MySqlDataAdapter(Consulta, cnn);
            cnn.Open();
            DataTable dtDatos = new DataTable();
            mdatos.Fill(dtDatos);
            comboBox2.DataSource = dtDatos;
            comboBox2.DisplayMember = "Nombre";
            comboBox2.ValueMember = "Id_Municipio";
            comboBox2.Refresh();
            cnn.Close();
        }

        private void limpiar()
        {
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            checkBox1.Checked = false;
        }

        private void id_centro()
        {
            Conexion con = new Conexion();
            string conexionbasededatos = con.Seconecto();
            string Consulta = "select IFNULL (max(Id_Centro),0) from centro";
            MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            MySqlCommand mc = new MySqlCommand(Consulta, cnn);
            cnn.Open();
            int val = Convert.ToInt32(mc.ExecuteScalar()) + 1;
            textBox1.Text = val.ToString();
            cnn.Close();
        }

    }
}
