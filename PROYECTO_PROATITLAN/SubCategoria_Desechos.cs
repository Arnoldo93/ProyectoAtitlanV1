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
using MySql.Data;
using Entidades;
using Negocio;

namespace PROYECTO_PROATITLAN
{
    public partial class SubCategoria_Desechos : Form
    {
        public SubCategoria_Desechos()
        {
            InitializeComponent();
        }
        string categoria, familia;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "")
                {
                    var c = new DSubcategoriaDesecho();
                    c.Id_SubCategoria = Convert.ToInt32(textBox1.Text);
                    c.Nombre = textBox2.Text;
                    c.Id_Categoria = Convert.ToInt32(categoria);
                    c.Id_Familia = Convert.ToInt32(familia);

                    if (NSubcategoriaDesecho.Agregar(c))
                    {
                        MessageBox.Show("Datos guardados correctamente", "Aviso");
                        limpiar();
                        ListadoCategorias();
                        ListadoFamilias();
                        ListaSubcategorias();
                        idSubCategoria();
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
                var c = new DSubcategoriaDesecho();
                c.Id_SubCategoria = Convert.ToInt32(textBox1.Text);
                c.Nombre = textBox2.Text;
                c.Id_Categoria = Convert.ToInt32(categoria);
                c.Id_Familia = Convert.ToInt32(familia);

                if (NSubcategoriaDesecho.Actualizar(c))
                {
                    MessageBox.Show("Datos guardados correctamente", "Aviso");
                    limpiar();
                    ListadoCategorias();
                    ListadoFamilias();
                    ListaSubcategorias();
                    idSubCategoria();
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
                    var c = new DSubcategoriaDesecho();
                    c.Id_SubCategoria = Convert.ToInt32(textBox1.Text);
                    c.Nombre = textBox2.Text;
                    c.Id_Categoria = Convert.ToInt32(categoria);
                    c.Id_Familia = Convert.ToInt32(familia);

                    if (NSubcategoriaDesecho.Eliminar(c))
                    {
                        MessageBox.Show("Datos guardados correctamente", "Aviso");
                        limpiar();
                        ListadoCategorias();
                        ListadoFamilias();
                        ListaSubcategorias();
                        idSubCategoria();
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
            ListadoCategorias();
            ListadoFamilias();
            ListaSubcategorias();
            idSubCategoria();
        }

        private void ListaSubcategorias()
        {
            Conexion con = new Conexion();
            string conexionbasededatos = con.Seconecto();
            string Consulta = "SELECT subcategoria_desecho.Id_SubCategoria, subcategoria_desecho.Nombre as NombreSubcategoria,subcategoria_desecho.Id_Categoria,categoria_desecho.Nombre as NombreCategoria,subcategoria_desecho.Id_Familia, familia.Nombre as NombreFamilia FROM subcategoria_desecho,categoria_desecho,familia where subcategoria_desecho.Id_Categoria=categoria_desecho.Id_Categoria and subcategoria_desecho.Id_Familia=familia.Id_Familia";
            MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            MySqlDataAdapter mdatos = new MySqlDataAdapter(Consulta, cnn);
            cnn.Open();
            DataTable dtDatos = new DataTable();
            mdatos.Fill(dtDatos);
            dataGridView1.DataSource = dtDatos;
            dataGridView1.Refresh();
            dataGridView1.Columns["Id_Categoria"].Visible = false;
            dataGridView1.Columns["Id_Familia"].Visible = false;
            cnn.Close();
        }

        private void ListadoCategorias()
        {
            Conexion con = new Conexion();
            string conexionbasededatos = con.Seconecto();
            string Consulta = "Select * from categoria_desecho";
            MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            MySqlDataAdapter mdatos = new MySqlDataAdapter(Consulta, cnn);
            cnn.Open();
            DataTable dtDatos = new DataTable();
            mdatos.Fill(dtDatos);
            comboBox1.DataSource = dtDatos;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Id_Categoria";
            comboBox1.Refresh();
            cnn.Close();
        }

        private void ListadoFamilias()
        {
            Conexion con = new Conexion();
            string conexionbasededatos = con.Seconecto();
            string Consulta = "Select * from familia";
            MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            MySqlDataAdapter mdatos = new MySqlDataAdapter(Consulta, cnn);
            cnn.Open();
            DataTable dtDatos = new DataTable();
            mdatos.Fill(dtDatos);
            comboBox2.DataSource = dtDatos;
            comboBox2.DisplayMember = "Nombre";
            comboBox2.ValueMember = "Id_Familia";
            comboBox2.Refresh();
            cnn.Close();
        }

        private void idSubCategoria()
        {
            Conexion con = new Conexion();
            string conexionbasededatos = con.Seconecto();
            string Consulta = "select IFNULL (max(Id_SubCategoria),0) from subcategoria_desecho";
            MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            MySqlCommand mc = new MySqlCommand(Consulta, cnn);
            cnn.Open();
            int val = Convert.ToInt32(mc.ExecuteScalar()) + 1;
            textBox1.Text = val.ToString();
            cnn.Close();
        }

        private void SubCategoria_Desechos_Load(object sender, EventArgs e)
        {
            limpiar();
            ListadoCategorias();
            ListadoFamilias();
            ListaSubcategorias();
            idSubCategoria();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            categoria = comboBox1.SelectedValue.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            familia = comboBox2.SelectedValue.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            textBox2.Text = dataGridView1[1, e.RowIndex].Value.ToString();
            comboBox1.SelectedValue = dataGridView1[2, e.RowIndex].Value;
            comboBox2.SelectedValue = dataGridView1[4, e.RowIndex].Value;
        }

        private void limpiar()
        {
            textBox2.Clear();
        }

    }   
}
