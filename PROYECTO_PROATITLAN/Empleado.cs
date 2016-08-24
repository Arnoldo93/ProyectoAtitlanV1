﻿using System;
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
    public partial class Empleado : Form
    {
        public Empleado()
        {
            InitializeComponent();
        }
        Conexion con = new Conexion();
        string puesto="", centro="";
        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (textBox2.Text != "")
            //    {
            //        if (checkBox1.Checked != false)
            //        {
            //            checkBox1.Checked = true;
            //        }
            //        else
            //        {
            //            checkBox1.Checked = false;
            //        }
            //        string conexionbasededatos = con.Seconecto();
            //        string Consulta = "INSERT INTO empleado(Id_Empleado,Nombre_Empleado,Direccion,Telefono,Usuario,Contrase_a,Estado_Empleado,Id_Puesto,Id_centro) VALUES('" + Convert.ToInt32(textBox1.Text) + "','" + textBox2.Text + "','" + textBox3.Text + "','" + int.Parse(textBox4.Text) + "','" + textBox7.Text + "','" + textBox8.Text + "','" + Convert.ToByte(checkBox1.Checked) +
            //            "','" + int.Parse(puesto) + "','" + int.Parse(centro) + "')";
            //        MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            //        MySqlCommand mc = new MySqlCommand(Consulta, cnn);
            //        cnn.Open();
            //        if (mc.ExecuteNonQuery() > 0)
            //        {
            //            cnn.Close();
            //            MessageBox.Show("Datos Guardatos");
            //            id_centro();
            //            limpiar();
            //            Listacentros();
            //            ListaEmpleados();
            //            ListaPuestos();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Error verifique sus datos.",
            //           "Critical Warning",
            //           MessageBoxButtons.OK,
            //           MessageBoxIcon.Error,
            //           MessageBoxDefaultButton.Button1,
            //           MessageBoxOptions.RtlReading,
            //           true);
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Error verifique sus datos.",
            //          "Critical Warning",
            //          MessageBoxButtons.OK,
            //          MessageBoxIcon.Error,
            //          MessageBoxDefaultButton.Button1,
            //          MessageBoxOptions.RtlReading,
            //          true);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            try
            {
                if (textBox2.Text != ""&&textBox7.Text!=""&&textBox8.Text!="")
                {
                    if (checkBox1.Checked != false)
                    {
                        checkBox1.Checked = true;
                    }
                    else
                    {
                        checkBox1.Checked = false;
                    }
                    var c = new DEmpleado();
                    c.Id_Empleado = Convert.ToInt32(textBox1.Text);
                    c.Nombre = textBox2.Text;
                    c.Direccion = textBox3.Text;
                    c.Telefono = int.Parse(textBox4.Text);
                    c.Usuario = textBox7.Text;
                    c.Contrase_a = textBox8.Text;
                    c.Estado_Empleado = Convert.ToByte(checkBox1.Checked);
                    c.Id_Puesto = int.Parse(puesto);
                    c.Id_Centro = int.Parse(centro);


                    if (NEmpleado.Agregar(c))
                    {
                        MessageBox.Show("Datos guardados correctamente", "Aviso");
                        idempleado();
                        limpiar();
                        Listacentros();
                        ListaPuestos();
                        ListaEmpleados();
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
            //    string conexionbasededatos = con.Seconecto();
            //    string Consulta = "update empleado set Id_Empleado='" + int.Parse(textBox1.Text) + "',Nombre_Empleado='" + this.textBox2.Text+ "',Direccion='" + this.textBox3.Text + "',Telefono='" +int.Parse( this.textBox4.Text) + "',Usuario='" +textBox7.Text + "',Contrase_a='" + textBox8.Text + "',Estado_Empleado='" +Convert.ToByte(checkBox1.Checked) + "',Id_Puesto='" + int.Parse(puesto) + "',Id_Centro='" + int.Parse(centro) + "'where Id_Empleado='" + int.Parse( this.textBox1.Text) + "';";

            //    MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            //    MySqlCommand mc = new MySqlCommand(Consulta, cnn);
            //    cnn.Open();
            //    if (mc.ExecuteNonQuery() > 0)
            //    {
            //        cnn.Close();
            //        MessageBox.Show("Datos Actualizados");
            //        id_centro();
            //        limpiar();
            //        Listacentros();
            //        ListaEmpleados();
            //        ListaPuestos();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Error verifique sus datos.",
            //          "Critical Warning",
            //          MessageBoxButtons.OK,
            //          MessageBoxIcon.Error,
            //          MessageBoxDefaultButton.Button1,
            //          MessageBoxOptions.RtlReading,
            //          true);
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
                var c = new DEmpleado();
                    c.Id_Empleado = Convert.ToInt32(textBox1.Text);
                    c.Nombre = textBox2.Text;
                    c.Direccion = textBox3.Text;
                    c.Telefono = int.Parse(textBox4.Text);
                    c.Usuario = textBox7.Text;
                    c.Contrase_a = textBox8.Text;
                    c.Estado_Empleado = Convert.ToByte(checkBox1.Checked);
                    c.Id_Puesto = int.Parse(puesto);
                    c.Id_Centro = int.Parse(centro);


                    if (NEmpleado.Actualizar(c))
                    {
                        MessageBox.Show("Datos guardados correctamente", "Aviso");
                        idempleado();
                        limpiar();
                        Listacentros();
                        ListaPuestos();
                        ListaEmpleados();
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
            //    string conexionbasededatos = con.Seconecto();

            //    string Consulta = "delete from empleado where Id_Empleado='" +int.Parse( this.textBox1.Text) + "';";

            //    MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            //    MySqlCommand mc = new MySqlCommand(Consulta, cnn);
            //    cnn.Open();
            //    if (mc.ExecuteNonQuery() > 0)
            //    {
            //        cnn.Close();
            //        MessageBox.Show("Se elimino correctamente.");
            //        id_centro();
            //        limpiar();
            //        Listacentros();
            //        ListaEmpleados();
            //        ListaPuestos();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Error verifique sus datos.",
            //          "Critical Warning",
            //          MessageBoxButtons.OK,
            //          MessageBoxIcon.Error,
            //          MessageBoxDefaultButton.Button1,
            //          MessageBoxOptions.RtlReading,
            //          true);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            try
            {
                if (textBox2.Text != "" && textBox7.Text != "" && textBox8.Text != "")
                {
                    var c = new DEmpleado();
                    c.Id_Empleado = Convert.ToInt32(textBox1.Text);

                    if (NEmpleado.Eliminar(c))
                    {
                        MessageBox.Show("Eliminacion correcta.", "Aviso");
                        idempleado();
                        limpiar();
                        Listacentros();
                        ListaPuestos();
                        ListaEmpleados();
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            idempleado();
            limpiar();
            Listacentros();
            ListaEmpleados();
            ListaPuestos();
        }

        private void ListaEmpleados()
        {
            Conexion con = new Conexion();
            string conexionbasededatos = con.Seconecto();
            string Consulta = "SELECT empleado.Id_Empleado,empleado.Nombre_Empleado,empleado.Direccion,empleado.Telefono,empleado.Usuario,empleado.Contrase_a,empleado.Estado_Empleado,empleado.Id_Puesto,puesto.Nombre_Puesto,empleado.Id_Centro,centro.Nombre_centro FROM proatitlan.empleado, proatitlan.puesto,proatitlan.centro where empleado.Id_Puesto= puesto.Id_Puesto and empleado.Id_Centro=centro.Id_Centro;";
            MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            MySqlDataAdapter mdatos = new MySqlDataAdapter(Consulta, cnn);
            cnn.Open();
            DataTable dtDatos = new DataTable();
            mdatos.Fill(dtDatos);
            dataGridView1.DataSource = dtDatos;
            dataGridView1.Refresh();
            dataGridView1.Columns["Usuario"].Visible = false;
            dataGridView1.Columns["Contrase_a"].Visible = false;
            dataGridView1.Columns["Id_Puesto"].Visible = false;
            dataGridView1.Columns["Id_Centro"].Visible = false;
            cnn.Close();
        }

        private void ListaPuestos()
        {
            Conexion con = new Conexion();
            string conexionbasededatos = con.Seconecto();
            string Consulta = "Select * From puesto";
            MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            MySqlDataAdapter mdatos = new MySqlDataAdapter(Consulta, cnn);
            cnn.Open();
            DataTable dtDatos = new DataTable();
            mdatos.Fill(dtDatos);
            comboBox1.DataSource = dtDatos;
            comboBox1.DisplayMember = "Nombre_Puesto";
            comboBox1.ValueMember = "Id_Puesto";
            cnn.Close();
        }

        private void Listacentros()
        {
            Conexion con = new Conexion();
            string conexionbasededatos = con.Seconecto();
            string Consulta = "Select * From centro";
            MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            MySqlDataAdapter mdatos = new MySqlDataAdapter(Consulta, cnn);
            cnn.Open();
            DataTable dtDatos = new DataTable();
            mdatos.Fill(dtDatos);
            comboBox2.DataSource = dtDatos;
            comboBox2.DisplayMember = "Nombre_centro";
            comboBox2.ValueMember = "Id_Centro";
            cnn.Close();
        }

        private void idempleado()
        {
            Conexion con = new Conexion();
            string conexionbasededatos = con.Seconecto();
            string Consulta = "select IFNULL (max(Id_Empleado),0) from empleado";
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
            textBox3.Clear();
            textBox4.Clear();
            textBox7.Clear();
            textBox8.Clear();
            checkBox1.Checked = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            puesto = comboBox1.SelectedValue.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            centro = comboBox2.SelectedValue.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            textBox2.Text = dataGridView1[1, e.RowIndex].Value.ToString();
            textBox3.Text = dataGridView1[2, e.RowIndex].Value.ToString();
            textBox4.Text = dataGridView1[3, e.RowIndex].Value.ToString();
            textBox7.Text = dataGridView1[4, e.RowIndex].Value.ToString();
            textBox8.Text = dataGridView1[5, e.RowIndex].Value.ToString();
            checkBox1.Checked =Convert.ToBoolean(dataGridView1[6, e.RowIndex].Value.ToString());
            comboBox1.SelectedValue = dataGridView1[7, e.RowIndex].Value;
            comboBox2.SelectedValue = dataGridView1[9, e.RowIndex].Value;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                textBox8.PasswordChar = (char)0;
            }
            else
            {
                textBox8.PasswordChar = '*';
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        { 
                Conexion con = new Conexion();
                string conexionbasededatos = con.Seconecto();
                string Consulta = "SELECT empleado.Id_Empleado,empleado.Nombre_Empleado,empleado.Direccion,empleado.Telefono,empleado.Usuario,empleado.Contrase_a,empleado.Estado_Empleado,empleado.Id_Puesto,puesto.Nombre_Puesto,empleado.Id_Centro,centro.Nombre_centro FROM proatitlan.empleado, proatitlan.puesto,proatitlan.centro where empleado.Id_Puesto= puesto.Id_Puesto and empleado.Id_Centro=centro.Id_Centro and empleado.Nombre_Empleado like'" + textBox2.Text + "%';";
                MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
                MySqlDataAdapter mdatos = new MySqlDataAdapter(Consulta, cnn);
                cnn.Open();
                DataTable dtDatos = new DataTable();
                mdatos.Fill(dtDatos);
                dataGridView1.DataSource = dtDatos;
                dataGridView1.Refresh();
                dataGridView1.Columns["Usuario"].Visible = false;
                dataGridView1.Columns["Contrase_a"].Visible = false;
                dataGridView1.Columns["Id_Puesto"].Visible = false;
                dataGridView1.Columns["Id_Centro"].Visible = false;
            cnn.Close();
        }

        private void Empleado_Load(object sender, EventArgs e)
        {
            idempleado();
            Listacentros();
            ListaEmpleados();
            ListaPuestos();
            limpiar();
        }
    }
}