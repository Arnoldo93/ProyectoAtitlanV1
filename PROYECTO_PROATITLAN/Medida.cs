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
            try
            {
                DataTable datos = new DataTable();
                datos = NMedida.ListaMedida();
                dataGridView1.DataSource = datos;
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void id_medida()
        {
            try
            {
                var i = new DMedida();
                i.Id_medida = NMedida.id() + 1;
                textBox1.Text = i.Id_medida.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
