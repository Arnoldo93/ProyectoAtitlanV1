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
using Negocio;

namespace PROYECTO_PROATITLAN
{
    public partial class Desechos : Form
    {
        public Desechos()
        {
            InitializeComponent();
        }
        string familia, categoria, subcategoria, medida;
        private void Desechos_Load(object sender, EventArgs e)
        {
            limpiar();
            IdDesecho();
            ListadoFamilia();
            ListadoCategoria();
            ListadoSubCategoria();
            ListadoMedida();
            Listadodesecho();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                {
                    if (checkBox1.Checked != false)
                    {
                        checkBox1.Checked = true;
                    }
                    else
                    {
                        checkBox1.Checked = false;
                    }
                    var c = new DDesechos();
                    c.Id_desecho = Convert.ToInt32(textBox1.Text);
                    c.Nombre = textBox2.Text;
                    c.Id_familia = int.Parse(familia);
                    c.Id_categoria = int.Parse(categoria);
                    c.Id_subcategoria = int.Parse(subcategoria);
                    c.Cantida_peso =Convert.ToDecimal(textBox3.Text);
                    c.Id_medida = Convert.ToInt32(medida);
                    c.Volumen = int.Parse(textBox4.Text);
                    c.Precio_costo =Convert.ToDouble( textBox5.Text);
                    c.PrecioVenta = Convert.ToDouble(textBox6.Text);
                    c.Estado_desecho = Convert.ToByte(checkBox1.Checked);


                    if (NDesechos.Agregar(c))
                    {
                        MessageBox.Show("Datos guardados correctamente", "Aviso");
                        limpiar();
                        IdDesecho();
                        ListadoFamilia();
                        ListadoCategoria();
                        ListadoSubCategoria();
                        ListadoMedida();
                        Listadodesecho();

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
                    var c = new DDesechos();
                    c.Id_desecho = Convert.ToInt32(textBox1.Text);
                    c.Nombre = textBox2.Text;
                    c.Id_familia = int.Parse(familia);
                    c.Id_categoria = int.Parse(categoria);
                    c.Id_subcategoria = int.Parse(subcategoria);
                    c.Cantida_peso = Convert.ToDecimal(textBox3.Text);
                    c.Id_medida = Convert.ToInt32(medida);
                    c.Volumen = int.Parse(textBox4.Text);
                    c.Precio_costo = Convert.ToDouble(textBox5.Text);
                    c.PrecioVenta = Convert.ToDouble(textBox6.Text);
                    c.Estado_desecho = Convert.ToByte(checkBox1.Checked);


                    if (NDesechos.Actualizar(c))
                    {
                        MessageBox.Show("Datos guardados correctamente", "Aviso");
                        limpiar();
                        IdDesecho();
                        ListadoFamilia();
                        ListadoCategoria();
                        ListadoSubCategoria();
                        ListadoMedida();
                        Listadodesecho();
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
                    var c = new DDesechos();
                    c.Id_desecho = Convert.ToInt32(textBox1.Text);
                    c.Nombre = textBox2.Text;
                    c.Id_familia = int.Parse(familia);
                    c.Id_categoria = int.Parse(categoria);
                    c.Id_subcategoria = int.Parse(subcategoria);
                    c.Cantida_peso = Convert.ToDecimal(textBox3.Text);
                    c.Id_medida = Convert.ToInt32(medida);
                    c.Volumen = int.Parse(textBox4.Text);
                    c.Precio_costo = Convert.ToDouble(textBox5.Text);
                    c.PrecioVenta = Convert.ToDouble(textBox6.Text);
                    c.Estado_desecho = Convert.ToByte(checkBox1.Checked);


                    if (NDesechos.Eliminar(c))
                    {
                        MessageBox.Show("Eliminado Correctamente.", "Aviso");
                        limpiar();
                        IdDesecho();
                        ListadoFamilia();
                        ListadoCategoria();
                        ListadoSubCategoria();
                        ListadoMedida();
                        Listadodesecho();
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
            limpiar();
            IdDesecho();
            ListadoFamilia();
            ListadoCategoria();
            ListadoSubCategoria();
            ListadoMedida();
            Listadodesecho();
        }

        private void IdDesecho()
        {
            Conexion con = new Conexion();
            string conexionbasededatos = con.Seconecto();
            string Consulta = "select IFNULL (max(Id_Desecho),1) from desechos";
            MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            MySqlCommand mc = new MySqlCommand(Consulta, cnn);
            cnn.Open();
            int val = Convert.ToInt32(mc.ExecuteScalar()) + 1;
            textBox1.Text = val.ToString();
            cnn.Close();
        }

        private void Listadodesecho()
        {
            Conexion con = new Conexion();
            string conexionbasededatos = con.Seconecto();
            string Consulta = "select desechos.Id_Desecho,desechos.Nombre as Desecho,desechos.Id_Familia,familia.Nombre as Familia,desechos.Id_Categoria,categoria_desecho.Nombre as Categoria, desechos.Id_SubCategoria,subcategoria_desecho.Nombre as Subcategoria,desechos.Cantidad_Peso, desechos.Id_Medida,medida.Medida,desechos.Volumen,desechos.Precio_Costo,desechos.Precio_Venta,desechos.Estado_desechos FROM desechos,familia,categoria_desecho,subcategoria_desecho,medida WHERE desechos.Id_Familia = familia.Id_Familia and desechos.Id_Categoria = categoria_desecho.Id_Categoria and desechos.Id_SubCategoria = subcategoria_desecho.Id_SubCategoria and desechos.Id_Medida = medida.Id_Medida";
            MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            MySqlDataAdapter mdatos = new MySqlDataAdapter(Consulta, cnn);
            cnn.Open();
            DataTable dtDatos = new DataTable();
            mdatos.Fill(dtDatos);
            dataGridView1.DataSource = dtDatos;
            dataGridView1.Refresh();
            dataGridView1.Columns["Id_Familia"].Visible = false;
            dataGridView1.Columns["Id_Categoria"].Visible = false;
            dataGridView1.Columns["Id_SubCategoria"].Visible = false;
            dataGridView1.Columns["Id_Medida"].Visible = false;
            cnn.Close();
        }

        private void ListadoFamilia()
        {
            Conexion con = new Conexion();
            string conexionbasededatos = con.Seconecto();
            string Consulta = "Select * From familia";
            MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            MySqlDataAdapter mdatos = new MySqlDataAdapter(Consulta, cnn);
            cnn.Open();
            DataTable dtDatos = new DataTable();
            mdatos.Fill(dtDatos);
            comboBox1.DataSource = dtDatos;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Id_Familia";
            cnn.Close();
        }

        private void ListadoCategoria()
        {
            Conexion con = new Conexion();
            string conexionbasededatos = con.Seconecto();
            string Consulta = "Select * From categoria_desecho";
            MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            MySqlDataAdapter mdatos = new MySqlDataAdapter(Consulta, cnn);
            cnn.Open();
            DataTable dtDatos = new DataTable();
            mdatos.Fill(dtDatos);
            comboBox2.DataSource = dtDatos;
            comboBox2.DisplayMember = "Nombre";
            comboBox2.ValueMember = "Id_Categoria";
            cnn.Close();
        }

        private void ListadoSubCategoria()
        {
            Conexion con = new Conexion();
            string conexionbasededatos = con.Seconecto();
            string Consulta = "Select * From subcategoria_desecho";
            MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            MySqlDataAdapter mdatos = new MySqlDataAdapter(Consulta, cnn);
            cnn.Open();
            DataTable dtDatos = new DataTable();
            mdatos.Fill(dtDatos);
            comboBox4.DataSource = dtDatos;
            comboBox4.DisplayMember = "Nombre";
            comboBox4.ValueMember = "Id_SubCategoria";
            cnn.Close();
        }

        private void ListadoMedida()
        {
            Conexion con = new Conexion();
            string conexionbasededatos = con.Seconecto();
            string Consulta = "Select * From medida";
            MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            MySqlDataAdapter mdatos = new MySqlDataAdapter(Consulta, cnn);
            cnn.Open();
            DataTable dtDatos = new DataTable();
            mdatos.Fill(dtDatos);
            comboBox3.DataSource = dtDatos;
            comboBox3.DisplayMember = "Medida";
            comboBox3.ValueMember = "Id_Medida";
            cnn.Close();
        }

        private void limpiar()
        {
            foreach (Control item in groupPanel1.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            familia = comboBox1.SelectedValue.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            categoria = comboBox2.SelectedValue.ToString();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            subcategoria = comboBox4.SelectedValue.ToString();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            medida = comboBox3.SelectedValue.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            textBox2.Text = dataGridView1[1, e.RowIndex].Value.ToString();
            comboBox1.SelectedValue = dataGridView1[2, e.RowIndex].Value;
            comboBox2.SelectedValue = dataGridView1[4, e.RowIndex].Value;
            comboBox4.SelectedValue = dataGridView1[6, e.RowIndex].Value;
            textBox3.Text = dataGridView1[8, e.RowIndex].Value.ToString();
            comboBox3.SelectedValue = dataGridView1[9, e.RowIndex].Value;
            textBox4.Text = dataGridView1[11, e.RowIndex].Value.ToString();
            textBox5.Text = dataGridView1[12, e.RowIndex].Value.ToString();
            textBox6.Text = dataGridView1[13, e.RowIndex].Value.ToString();
            checkBox1.Checked =Convert.ToBoolean( dataGridView1[14, e.RowIndex].Value);
        }
    }
}
