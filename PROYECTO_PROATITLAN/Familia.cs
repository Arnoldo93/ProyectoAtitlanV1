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
    public partial class Familia : Form
    {
        public Familia()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "")
                {
                    var c = new DFamilia();
                    c.Id_Familia = Convert.ToInt32(textBox1.Text);
                    c.Nombre = textBox2.Text;

                    if (NFamilia.Agregar(c))
                    {
                        MessageBox.Show("Datos guardados correctamente", "Aviso");
                        id_familia();
                        ListaFamilia();
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
            try
            {
                
                    var c = new DFamilia();
                    c.Id_Familia = Convert.ToInt32(textBox1.Text);
                    c.Nombre = textBox2.Text;

                    if (NFamilia.Actualizar(c))
                    {
                        MessageBox.Show("Datos guardados correctamente", "Aviso");
                        id_familia();
                        ListaFamilia();
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
            try
            {
                
                    var c = new DFamilia();
                    c.Id_Familia = Convert.ToInt32(textBox1.Text);

                    if (NFamilia.Eliminar(c))
                    {
                        MessageBox.Show("Eliminado correctamente", "Aviso");
                        id_familia();
                        ListaFamilia();
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

        private void button4_Click(object sender, EventArgs e)
        {
            id_familia();
            ListaFamilia();
            limpiar();
        }

        private void ListaFamilia()
        {
            try
            {
                DataTable datos = new DataTable();
                datos = NFamilia.ListadoFamilias();
                dataGridView1.DataSource = datos;
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void id_familia()
        {
            try
            {
                var i = new DFamilia();
                i.Id_Familia = NFamilia.id() + 1;
                textBox1.Text = i.Id_Familia.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void limpiar()
        {
            textBox2.Clear();
        }

        private void Familia_Load(object sender, EventArgs e)
        {
            limpiar();
            ListaFamilia();
            id_familia();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            textBox2.Text = dataGridView1[1, e.RowIndex].Value.ToString();
        }
    }
}
