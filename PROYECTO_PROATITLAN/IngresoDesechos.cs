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
using AccesoDatos;
using Negocio;
using Entidades;

namespace PROYECTO_PROATITLAN
{
    public partial class IngresoDesechos : Form
    {
        public IngresoDesechos()
        {
            InitializeComponent();
        }
        string centro,precioventa,preciocompra,volumen,peso;
        private static DDetalleIngreso d;
        private List<DDetalleIngreso> lista;

        private void IngresoDesechos_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            textBox2.Text = Program.usuario;
            comboBox2.Focus();
            listadocentros();
            idencabezado();
            iddetalle();
            desechos();
            vehiculo();
            centroempleado();
            textBox5.Text = 0.ToString();
            textBox7.Text = 0.ToString();
        }

        private void vehiculo()
        {
            comboBox3.DataSource = NVehiculo.ListadoVechiculos();
            comboBox3.DisplayMember = "Vehiculo";
            comboBox3.ValueMember = "Id_Vehiculo";
        }

        private void centroempleado()
        {
            DataTable datos = new DataTable();
            datos = NDatosCentro.CentroEmpleado(Convert.ToInt32(Program.idempleado));
            comboBox2.DataSource = datos;
            comboBox2.DisplayMember = "Nombre_centro";
            comboBox2.ValueMember = "Id_Centro";

        }

        private void desechos()
        {
            
            comboBox1.DisplayMember = "Desecho";
            comboBox1.ValueMember = "Id_Desecho";
            comboBox1.DataSource = NDesechos.ListaDesechos();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            centro = comboBox2.SelectedValue.ToString();
        }

        private void listadocentros()
        {
            comboBox2.DataSource = NDatosCentro.ListaDatosCentro();
            comboBox2.DisplayMember = "Nombre_centro";
            comboBox2.ValueMember = "Id_Centro";

        }

        private void idencabezado()
        {
            var i = new DEncabezadoDesecho();
            i.Idencabezado = NEncabezadoDesechos.idencabezado() + 1;
            textBox1.Text = i.Idencabezado.ToString();
        }

        private void iddetalle()
        {
            var i = new DDetalleIngreso();
            i.iddetalle = NEncabezadoDesechos.iddetalle() + 1;
            textBox3.Text = i.iddetalle.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            #region existencias   
            //existencias
            var upex = new DExistencias();
            upex.idcentro = Convert.ToInt32(comboBox2.SelectedValue);
            upex.iddesecho = Convert.ToInt32(comboBox1.SelectedValue);
            upex.preciocosto = Convert.ToDouble(textBox4.Text);
            upex.precioventa = Convert.ToDouble(textBox6.Text);
            //se suma la cantidad y el peso a lo que ya esta en la base de datos
            if (comboBox1.Text == "ORGANICO")
            { 
                upex.cantidadvolumen = Convert.ToDouble(textBox7.Text) + Convert.ToDouble(volumen);
                upex.cantidadpeso = Convert.ToDouble(0);
            }
            else
            {
                upex.cantidadvolumen = Convert.ToDouble(0);
                upex.cantidadpeso = Convert.ToDouble(textBox5.Text) + Convert.ToDouble(peso);
            }
            
           

            if (NExistencias.Agregar(upex))
            {
                //MessageBox.Show("Se agrego a la existencia", "Aviso");

                //ingreso detalle
                lista = new List<DDetalleIngreso>();
                d = new DDetalleIngreso();
                d.idencabezado = Convert.ToInt32(textBox1.Text);
                d.iddetalle = Convert.ToInt32(textBox3.Text);
                d.iddesecho = Convert.ToInt32(comboBox1.SelectedValue);
                //CANTIDAD DE DETALLE (ORGANICO U OTROS)
                int can=0;
                if (comboBox1.Text == "ORGANICO")
                {
                    can = Convert.ToInt32(textBox7.Text);
                }
                else
                {
                    can = Convert.ToInt32(textBox5.Text);
                }
                d.cantidad = Convert.ToInt32(can);
                d.idVehiculo = Convert.ToInt32(comboBox3.SelectedValue);
                lista.Add(d);

                var i = new DEncabezadoDesecho();
                i.listardetalle = lista;
                if (NEncabezadoDesechos.DetalleEncabezado(i))
                {

                    MessageBox.Show("Se agrego correctamente","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    dataGridView1.Columns["Column5"].Visible = false;
                    //
                    if (comboBox1.Text == "ORGANICO")
                    {
                        dataGridView1.Rows.Add(d.iddetalle, d.iddesecho, comboBox1.Text, 0,textBox7.Text,comboBox3.Text,textBox4.Text,textBox6.Text);
                        iddetalle();
                        desechos();
                        button3.Enabled = true;
                        textBox4.Clear();
                        textBox6.Clear();
                        textBox5.Clear();
                        textBox7.Clear();
                    }
                    else
                    {
                        dataGridView1.Rows.Add(d.iddetalle, d.iddesecho, comboBox1.Text, d.cantidad , 0, comboBox3.Text, textBox4.Text, textBox6.Text);
                        iddetalle();
                        desechos();
                        button3.Enabled = true;
                        textBox4.Clear();
                        textBox6.Clear();
                        textBox5.Clear();
                        textBox7.Clear();
                    }
                    

                }
                else
                {
                    MessageBox.Show("Error al agregar cantidad peso","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //fin ingresodetalle
            }
            else
            {
                MessageBox.Show("Verifique sus datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            //boton guardar encabezado
            try
            {
                    groupPanel2.Enabled = true;
                    groupPanel3.Enabled = true;
                    groupPanel1.Enabled = false;
                    button1.Enabled = false;
                    button3.Enabled = false;

                    var v = new DEncabezadoDesecho();
                    v.Idencabezado = int.Parse(textBox1.Text);
                    v.fecharealizado = dateTimePicker1.Value;
                    v.idempleado = int.Parse(Program.idempleado);
                    v.idcentro = Convert.ToInt32(comboBox2.SelectedValue);

                    if (NEncabezadoDesechos.AgregarEncabezado(v))
                    {
                        MessageBox.Show("Se ingreso con exito.");
                        
                    }
                    else
                    {
                        MessageBox.Show("Verifique sus datos");
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            timer2.Stop();
            textBox3.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            comboBox1.SelectedValue = dataGridView1[1, e.RowIndex].Value;
            textBox5.Text = dataGridView1[3, e.RowIndex].Value.ToString();
            textBox7.Text = dataGridView1[4, e.RowIndex].Value.ToString();
            textBox4.Text = dataGridView1[6, e.RowIndex].Value.ToString();
            textBox6.Text = dataGridView1[7, e.RowIndex].Value.ToString();

        }

        private void button2_Click_1(object sender, EventArgs e)
        { 
            #region eliminarexistencia
            try
            {
                //datos del existencia para actualizar 
                DataTable datos = new DataTable();
                var pv = new DExistencias();
                pv.idcentro = Convert.ToInt32(comboBox2.SelectedValue);
                pv.iddesecho = Convert.ToInt32(comboBox1.SelectedValue);
                datos = NExistencias.pesoyvolumen(pv);
                peso = datos.Rows[0][0].ToString();
                volumen = datos.Rows[0][1].ToString();
                preciocompra = datos.Rows[0][2].ToString();
                precioventa = datos.Rows[0][3].ToString();
                ///

                var upex = new DExistencias();
                upex.idcentro = Convert.ToInt32(comboBox2.SelectedValue);
                upex.iddesecho = Convert.ToInt32(comboBox1.SelectedValue);
                upex.preciocosto = Convert.ToDouble(textBox4.Text);
                upex.precioventa = Convert.ToDouble(textBox6.Text);
                //se suma la cantidad y el peso a lo que ya esta en la base de datos
                upex.cantidadpeso = Convert.ToDouble(peso) - Convert.ToDouble(textBox5.Text);
                upex.cantidadvolumen = Convert.ToDouble(volumen) - Convert.ToDouble(textBox7.Text);

                if (NExistencias.Agregar(upex))
                {
                    MessageBox.Show("Se agrego a la existencia", "Aviso");

                    if (NEncabezadoDesechos.EliminarDetalleEncabezado(Convert.ToInt32(textBox3.Text)))
                    {
                        MessageBox.Show("Se Elimino correctamente");
                        dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                        desechos();
                        textBox5.Clear();
                        textBox7.Clear();
                        textBox4.Clear();
                        textBox6.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }
                else
                {
                    MessageBox.Show("revise sus datos", "Error");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            desechos();
            vehiculo();
            textBox5.Text = 0.ToString();
            textBox7.Text = 0.ToString();
            textBox4.Clear();
            textBox6.Clear();

            #endregion
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            idencabezado();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            iddetalle();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            timer1.Start();
            //nuevo encabezado
            idencabezado();
            groupPanel1.Enabled = true;
            button1.Enabled = true;
            button3.Enabled = false;
            centroempleado();
            iddetalle();
            desechos();
            vehiculo();
            dataGridView1.Rows.Clear();
            groupPanel2.Enabled = false;
            groupPanel3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count<=1)
            {
                if (NEncabezadoDesechos.EliminarEncabezado(int.Parse(textBox1.Text)))
                {
                    MessageBox.Show("Se elimino el Encabezado");
                    this.Close();
                }
            }
            if (dataGridView1.Rows.Count > 1)
            {
                MessageBox.Show("saliendo");
                this.Close();
            }

            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            textBox5.Text = 0.ToString();
            textBox7.Text = 0.ToString();
            try
            {
                if (comboBox1.Text == "ORGANICO")
                {
                    textBox7.Enabled = true;
                    textBox5.Enabled = false;
                    DataTable datos = new DataTable();
                    var pv = new DExistencias();
                    pv.idcentro = Convert.ToInt32(comboBox2.SelectedValue);
                    pv.iddesecho = Convert.ToInt32(comboBox1.SelectedValue);
                    datos = NExistencias.pesoyvolumen(pv);
                    //peso = datos.Rows[0][0].ToString();
                    volumen = datos.Rows[0][1].ToString();
                    //preciocompra = datos.Rows[0][2].ToString();
                    //precioventa = datos.Rows[0][3].ToString();
                }
                else
                {
                    textBox7.Enabled = false;
                    textBox5.Enabled = true;
                    DataTable datos = new DataTable();
                    var pv = new DExistencias();
                    pv.idcentro = Convert.ToInt32(comboBox2.SelectedValue);
                    pv.iddesecho = Convert.ToInt32(comboBox1.SelectedValue);
                    datos = NExistencias.pesoyvolumen(pv);
                    peso = datos.Rows[0][0].ToString();
                    //volumen = datos.Rows[0][1].ToString();
                    //preciocompra = datos.Rows[0][2].ToString();
                    //precioventa = datos.Rows[0][3].ToString();
                }
            }
            catch(Exception)
            {
                //MessageBox.Show(ex.Message);
            }
        }
    }
}
