using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace PROYECTO_PROATITLAN
{
    public partial class Categoria : Form
    {
        public Categoria()
        {
            InitializeComponent();
        }
        string familia;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "")
                {
                    var c = new DCategoriaDesecho();
                    c.Id_Categoria = Convert.ToInt32(textBox1.Text);
                    c.Nombre = textBox2.Text;
                    c.Id_Familia = Convert.ToInt32(familia);

                    if (NCategoriaDesecho.Agregar(c))
                    {
                        MessageBox.Show("Datos guardados correctamente", "Aviso");
                        limpiar();
                        id_categoria();
                        ListaCategorias(); ;
                        ListaFamilias();
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
                var c = new DCategoriaDesecho();
                c.Id_Categoria = Convert.ToInt32(textBox1.Text);
                c.Nombre = textBox2.Text;
                c.Id_Familia = Convert.ToInt32(familia);

                if (NCategoriaDesecho.Actualizar(c))
                {
                    MessageBox.Show("Datos guardados correctamente", "Aviso");
                    limpiar();
                    id_categoria();
                    ListaCategorias();
                    ListaFamilias();
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
                var c = new DCategoriaDesecho();
                c.Id_Categoria = Convert.ToInt32(textBox1.Text);

                if (NCategoriaDesecho.Eliminar(c))
                {
                    MessageBox.Show("Eliminado correctamente", "Aviso");
                    limpiar();
                    id_categoria();
                    ListaCategorias();
                    ListaFamilias();
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

        private void ListaFamilias()
        {
            Conexion con = new Conexion();
            string conexionbasededatos = con.Seconecto();
            string Consulta = "SELECT * FROM proatitlan.familia";
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

        private void ListaCategorias()
        {
            Conexion con = new Conexion();
            string conexionbasededatos = con.Seconecto();
            string Consulta = "SELECT categoria_desecho.Id_Categoria,categoria_desecho.Nombre,categoria_desecho.Id_Familia,familia.Nombre FROM proatitlan.categoria_desecho,proatitlan.familia where categoria_desecho.Id_Familia=familia.Id_Familia;";
            MySqlConnection cnn = new MySqlConnection(conexionbasededatos);
            MySqlDataAdapter mdatos = new MySqlDataAdapter(Consulta, cnn);
            DataTable dtDatos = new DataTable();
            mdatos.Fill(dtDatos);
            cnn.Open();
            dataGridView1.DataSource = dtDatos;
            dataGridView1.Refresh();
            dataGridView1.Columns["Id_Familia"].Visible = false;
        }

        private void id_categoria()
        {
            Conexion con = new Conexion();
            string conexionbasededatos = con.Seconecto();
            string Consulta = "select IFNULL (max(Id_Categoria),0) from categoria_desecho";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            textBox2.Text = dataGridView1[1, e.RowIndex].Value.ToString();
            comboBox1.SelectedValue = dataGridView1[2, e.RowIndex].Value;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            familia = comboBox1.SelectedValue.ToString();
        }

        private void Categoria_Load(object sender, EventArgs e)
        {
            limpiar();
            ListaCategorias();
            ListaFamilias();
            id_categoria();
        }
    }
}
