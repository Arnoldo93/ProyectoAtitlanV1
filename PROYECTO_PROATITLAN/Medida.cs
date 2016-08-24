﻿using System;
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
    public partial class Medida : Form
    {
        public Medida()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "")
                {
                    var c = new DMedida();
                    c.Id_medida = Convert.ToInt32(textBox1.Text);
                    c.Nombre =Convert.ToChar(textBox2.Text);

                    if (NMedida.Agregar(c))
                    {
                        MessageBox.Show("Datos guardados correctamente", "Aviso");
                        limpiar();
                        id_medida();
                        ListaMedida();
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
            try
            { 
                    var c = new DMedida();
                    c.Id_medida = Convert.ToInt32(textBox1.Text);
                    c.Nombre = Convert.ToChar(textBox2.Text);

                    if (NMedida.Actualizar(c))
                    {
                        MessageBox.Show("Datos guardados correctamente", "Aviso");
                        limpiar();
                        id_medida();
                        ListaMedida();
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
            try
            {
                
                    var c = new DMedida();
                c.Id_medida = Convert.ToInt32(textBox1.Text);

                if (NMedida.Eliminar(c))
                {
                    MessageBox.Show("Datos guardados correctamente", "Aviso");
                    limpiar();
                    id_medida();
                    ListaMedida();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            limpiar();
            id_medida();
            ListaMedida();

        }

        private void limpiar()
        {
            textBox2.Clear();
        }

        private void ListaMedida()
        {
            Conexion con = new Conexion();
            string conexionbasededatos = con.Seconecto();
            string Consulta = "Select * From medida";
            MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            MySqlDataAdapter mdatos = new MySqlDataAdapter(Consulta, cnn);
            cnn.Open();
            DataTable dtDatos = new DataTable();
            mdatos.Fill(dtDatos);
            dataGridView1.DataSource = dtDatos;
            dataGridView1.Refresh();
            cnn.Close();
        }

        private void id_medida()
        {
            Conexion con = new Conexion();
            string conexionbasededatos = con.Seconecto();
            string Consulta = "select IFNULL (max(Id_Medida),0) from medida";
            MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            MySqlCommand mc = new MySqlCommand(Consulta, cnn);
            cnn.Open();
            int val = Convert.ToInt32(mc.ExecuteScalar()) + 1;
            textBox1.Text = val.ToString();
            cnn.Close();
        }

        private void Medida_Load(object sender, EventArgs e)
        {
            limpiar();
            ListaMedida();
            id_medida();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            textBox2.Text = dataGridView1[1, e.RowIndex].Value.ToString();
        }
    }
}