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
using AccesoDatos;
using Negocio;

namespace PROYECTO_PROATITLAN
{
    public partial class VentaDesechos : Form
    {
        public VentaDesechos()
        {
            InitializeComponent();
        }
        string peso, precioventa;
        private static DDetalleVenta d;
        private List<DDetalleVenta> lista;
        private void VentaDesechos_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            limpiar();
            idencabezado();
            iddetalle();
            moneda();
            cliente();
            desechos();
            textBox2.Text= Program.usuario;
            centroempleado();
            dataGridView1.Columns["Column1"].Visible = false;
            dataGridView1.Columns["Column2"].Visible = false;
            groupPanel2.Enabled = false;
            groupPanel4.Enabled = false;
            button2.Enabled = false;
        }

        private void idencabezado()
        {
            var id = NEncabezadoVenta.idencabezado()+1;
            textBox1.Text = id.ToString();
        }

        private void limpiar()
        {
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }

        private void iddetalle()
        {
            var id = NEncabezadoVenta.iddetalle() + 1;
            textBox4.Text = id.ToString();
        }

        private void centroempleado()
        {
            DataTable datos = new DataTable();
            datos = NDatosCentro.CentroEmpleado(Convert.ToInt32(Program.idempleado));
            comboBox2.DataSource = datos;
            comboBox2.DisplayMember = "Nombre_centro";
            comboBox2.ValueMember = "Id_Centro";
        }

        private void moneda()
        {
            DataTable datos = new DataTable();
            datos = NMoneda.ListarMoneda();
            comboBox1.DataSource = datos;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Id_Moneda";
        }

        private void cliente()
        {
            DataTable datos = new DataTable();
            datos = NCliente.ListaDatosCliente();
            comboBox3.DataSource = datos;
            comboBox3.DisplayMember = "Cliente";
            comboBox3.ValueMember = "Id_Cliente";
        }

        private void desechos()
        {
            DataTable datos = new DataTable();
            datos = NDesechos.ListaDesechosVenta();
            comboBox4.DisplayMember = "Nombre";
            comboBox4.ValueMember = "Id_Desecho";
            comboBox4.DataSource = datos;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            try
            {
                textBox8.Text = 0.ToString();
                var inser = new DEncabezadoVentas();
                inser.idventa = Convert.ToInt32(textBox1.Text);
                inser.total = Convert.ToDecimal(textBox8.Text);
                inser.fecharealizado = DateTime.Now;
                inser.idempleado = Convert.ToInt32(Program.idempleado);
                inser.idmoneda = Convert.ToInt32(comboBox1.SelectedValue);
                inser.idcliente = Convert.ToInt32(comboBox3.SelectedValue);
                inser.idcentro = Convert.ToInt32(comboBox2.SelectedValue);

                if (NEncabezadoVenta.AgregarEncabezado(inser))
                {
                    MessageBox.Show("Encabezado ingresado correctamente.", "Aviso");
                    groupPanel1.Enabled = false;
                    button1.Enabled = false;
                    button2.Enabled = false;
                    groupPanel2.Enabled = true;
                    groupPanel4.Enabled = true;
                }
                else
                {
                    MessageBox.Show("verifique que sus datos sean correctos", "Error");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                #region desechos
                //var dese = new DDesechos();
                //dese.Id_desecho = Convert.ToInt32(comboBox4.SelectedValue);
                //dese.Nombre = comboBox4.Text;
                ////if (comboBox4.Text != "ORGANICO")
                ////{
                //    DataTable datos = new DataTable();
                //    datos = NDesechos.obtenercantidadpesodesechos(dese);
                //    string cantidad = datos.Rows[0][2].ToString();
                //    string precioventa = datos.Rows[0][3].ToString();
                //    textBox5.Text = cantidad;
                //    textBox6.Text = precioventa;
                //}
                //else
                //{
                //    DataTable datos1 = new DataTable();
                //    datos1 = NDesechos.obtenerVolumendesechos(dese);
                //    string volumen = datos1.Rows[0][2].ToString();
                //    string precioventa = datos1.Rows[0][3].ToString();
                //    textBox5.Text = volumen;
                //    textBox6.Text = precioventa;
                //    int SUBTOTAL = Convert.ToInt32(volumen) * Convert.ToInt32(precioventa);
                //    textBox7.Text = SUBTOTAL.ToString();
                //}
                #endregion

                DataTable datos = new DataTable();
                var pv = new DExistencias();
                pv.idcentro = Convert.ToInt32(comboBox2.SelectedValue);
                pv.iddesecho = Convert.ToInt32(comboBox4.SelectedValue);
                datos = NExistencias.pesoyvolumen(pv);
                peso = datos.Rows[0][0].ToString();
                precioventa = datos.Rows[0][3].ToString();
                textBox5.Text = peso.ToString();
                textBox6.Text = precioventa.ToString();

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //try
            //{
            //var dese = new DDesechos();
            //dese.Id_desecho = Convert.ToInt32(comboBox4.SelectedValue);
            //dese.Nombre = comboBox4.Text;
            //if (comboBox4.Text != "ORGANICO")
            //{
            //Si la cantidad guardada es mayor a la venta
            //DataTable datos = new DataTable();
            //datos = NDesechos.CantidadProductoPeso(comboBox4.Text);
            //string cantidad = datos.Rows[0][2].ToString();
            //textBox5.Text = cantidad;
            

            #region
            //}
            //else
            //{
            //    DataTable datos1 = new DataTable();
            //    datos1 = NDesechos.obtenerVolumendesechos(dese);
            //    string volumen = datos1.Rows[0][2].ToString();
            //    string precioventa = datos1.Rows[0][3].ToString();
            //    textBox5.Text = volumen;
            //    textBox6.Text = precioventa;
            //    int TOT = Convert.ToInt32(volumen) * Convert.ToInt32(precioventa);
            //    textBox7.Text = TOT.ToString();
            //    if (TOT < 0)
            //    {
            //        MessageBox.Show("Error la cantidad ingresada es mayor a la que esta guardada");
            //    }
            //    else
            //    {
            //        lista = new List<DDetalleVenta>();
            //        d = new DDetalleVenta();
            //        d.idventa = Convert.ToInt32(textBox1.Text);
            //        d.iddetalleventa = Convert.ToInt32(textBox4.Text);
            //        d.iddesecho = Convert.ToInt32(comboBox4.SelectedValue);
            //        d.cantidad = Convert.ToInt32(textBox5.Text);
            //        d.precio = Convert.ToDecimal(textBox6.Text);
            //        d.subtotal = Convert.ToDecimal(textBox7.Text);
            //        lista.Add(d);

            //        var i = new DEncabezadoVentas();
            //        i.listardetalleventa = lista;
            //        MessageBox.Show("Se agrego correctamente");
            //    }
            //}
            //}
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            #endregion

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            timer2.Stop();
            textBox4.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            textBox5.Text = dataGridView1[1, e.RowIndex].Value.ToString();
            comboBox4.SelectedValue = dataGridView1[2, e.RowIndex].Value;
            textBox6.Text = dataGridView1[4, e.RowIndex].Value.ToString();
            textBox7.Text = dataGridView1[5, e.RowIndex].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
            limpiar();
            idencabezado();
            cliente();
            centroempleado();
            moneda();
            iddetalle();
            desechos();
            groupPanel1.Enabled = true;
            groupPanel2.Enabled = false;
            button1.Enabled = true;
            groupPanel4.Enabled = false;
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            button2.Enabled = true;
            try
            {
                //int cantidad = NDesechos.CantidadProductoPeso(comboBox4.Text);
                //int maxcantidad = Convert.ToInt32(cantidad) - Convert.ToInt32(textBox5.Text);
                DataTable datos = new DataTable();
                var pv = new DExistencias();
                pv.idcentro = Convert.ToInt32(comboBox2.SelectedValue);
                pv.iddesecho = Convert.ToInt32(comboBox4.SelectedValue);
                datos = NExistencias.pesoyvolumen(pv);
                peso = datos.Rows[0][0].ToString();

                double maxcantidad = Convert.ToDouble(peso) - Convert.ToDouble(textBox5.Text);

                if (maxcantidad < 0)
                {
                    MessageBox.Show("La cantidad ingresada es mayor a la que esta guardada", "Error");
                }
                else
                {
                    var upex = new DExistencias();
                    upex.idcentro = Convert.ToInt32(comboBox2.SelectedValue);
                    upex.iddesecho = Convert.ToInt32(comboBox4.SelectedValue);
                    //upex.preciocosto = Convert.ToDouble(textBox4.Text);
                    //upex.precioventa = Convert.ToDouble(textBox6.Text);
                    //se suma la cantidad y el peso a lo que ya esta en la base de datos
                    upex.cantidadpeso = Convert.ToDouble(peso) - Convert.ToDouble(textBox5.Text);

                    if (NExistencias.Actualizarexistenciaventa(upex))
                    {
                        MessageBox.Show("Se actualizo con exito", "Aviso");

                        decimal TOT = Convert.ToInt32(textBox6.Text) * Convert.ToInt32(textBox5.Text);
                        textBox7.Text = TOT.ToString();
                        lista = new List<DDetalleVenta>();
                        d = new DDetalleVenta();
                        d.idventa = Convert.ToInt32(textBox1.Text);
                        d.iddetalleventa = Convert.ToInt32(textBox4.Text);
                        d.iddesecho = Convert.ToInt32(comboBox4.SelectedValue);
                        d.cantidad = Convert.ToInt32(textBox5.Text);
                        d.precio = Convert.ToDecimal(textBox6.Text);
                        d.subtotal = Convert.ToDecimal(textBox7.Text);
                        lista.Add(d);

                        var i = new DEncabezadoVentas();
                        i.listardetalleventa = lista;

                        if (NEncabezadoVenta.DetalleEncabezado(i))
                        {
                            dataGridView1.Columns["Column1"].Visible = false;
                            dataGridView1.Columns["Column2"].Visible = false;
                            dataGridView1.Rows.Add(d.iddetalleventa, d.cantidad, d.iddesecho, comboBox4.Text, d.precio, d.subtotal);
                            int result = dataGridView1.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToInt32(x.Cells["Column5"].Value));
                            textBox8.Text = result.ToString();
                            MessageBox.Show("Se agrego correctamente");

                            var actuatotal = new DEncabezadoVentas();
                            actuatotal.idventa = Convert.ToInt32(textBox1.Text);
                            actuatotal.total = Convert.ToDecimal(textBox8.Text);
                            if (NEncabezadoVenta.ActualizarTotalVenta(actuatotal))
                            {
                                MessageBox.Show("Se actualizo Correctamente el Total", "Aviso");
                                textBox5.Clear();
                                textBox6.Clear();
                                textBox7.Clear();
                                desechos();
                            }
                            else
                            {
                                MessageBox.Show("Verifique sus datos", "Error");
                            }

                        }
                        else
                        {
                            MessageBox.Show("No se agrego", "Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se realizo la actualizacion, verifique sus datos", "Error");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            timer2.Start();
            try
            {
                var upex = new DExistencias();
                upex.idcentro = Convert.ToInt32(comboBox2.SelectedValue);
                upex.iddesecho = Convert.ToInt32(comboBox4.SelectedValue);
                //upex.preciocosto = Convert.ToDouble(textBox4.Text);
                //upex.precioventa = Convert.ToDouble(textBox6.Text);
                //se suma la cantidad y el peso a lo que ya esta en la base de datos
                upex.cantidadpeso = Convert.ToDouble(textBox5.Text) + Convert.ToDouble(peso);
                upex.cantidadvolumen = Convert.ToDouble(textBox7.Text) + Convert.ToDouble(0);

                if (NExistencias.Actualizarexistenciaventa(upex))
                {
                    MessageBox.Show("Se actualizo con exito", "Aviso");

                    if (NEncabezadoVenta.EliminarDetalleEncabezado(Convert.ToInt32(textBox4.Text)))
                    {
                        dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                        MessageBox.Show("Se elimino Correctamente el detalle", "Aviso");
                        textBox5.Clear();
                        textBox6.Clear();
                        textBox7.Clear();
                        desechos();

                    }
                    else
                    {
                        MessageBox.Show("Revise sus datos", "Error");
                    }

                }
                else
                {
                    MessageBox.Show("Revise que los datos sean correctos", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count <= 1)
            {
                if (NEncabezadoVenta.EliminarEncabezado(int.Parse(textBox1.Text)))
                {
                    MessageBox.Show("Se elimino el Encabezado");
                    this.Close();
                }
            }
            if (dataGridView1.Rows.Count > 1)
            {
                MessageBox.Show("saliendo...");
                this.Close();
            }

            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            idencabezado();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
