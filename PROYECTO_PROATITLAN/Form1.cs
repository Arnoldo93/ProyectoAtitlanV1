using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYECTO_PROATITLAN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Form Empleado,Tipoempleado,centro,municipio,tipocentro,zona,familia,categoria,subcategoria,medida,desechos;

        private void usuario()
        {
            log l = new log();
            toolStripStatusLabel1.Text = Program.usuario;
        }
        
        private void buttonItem19_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(centro))
            {
                centro = new Centro();
                centro.MdiParent = this;
                centro.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                centro.Focus();
            }
        }

        private void buttonItem18_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(tipocentro))
            {
                tipocentro = new Tipo_Centro();
                tipocentro.MdiParent = this;
                tipocentro.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tipocentro.Focus();
            }
        }

        private void buttonItem21_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(categoria))
            {
                categoria = new Categoria();
                categoria.MdiParent = this;
                categoria.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                categoria.Focus();
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            usuario();
        }

        private void buttonItem24_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(desechos))
            {
                desechos = new Desechos();
                desechos.MdiParent = this;
                desechos.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                desechos.Focus();
            }
        }

        private void buttonItem23_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(medida))
            {
                medida = new Medida();
                medida.MdiParent = this;
                medida.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                medida.Focus();
            }
        }

        private void buttonItem22_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(subcategoria))
            {
                subcategoria = new SubCategoria_Desechos();
                subcategoria.MdiParent = this;
                subcategoria.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                subcategoria.Focus();
            }
        }

        private void ribbonBar8_ItemClick(object sender, EventArgs e)
        {
            
        }

        private void buttonItem20_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(familia))
            {
                familia = new Familia();
                familia.MdiParent = this;
                familia.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                familia.Focus();
            }
        }

        public void buttonItem17_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(municipio))
            {
                municipio = new Municipio();
                municipio.MdiParent = this;
                municipio.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                municipio.Focus();
            }
        }

        private void buttonItem16_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(zona))
            {
                zona = new ZonaDeGestion();
                zona.MdiParent = this;
                zona.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                zona.Focus();
            }
        }

        private void buttonItem15_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(Empleado))
            {
                Empleado = new Empleado();
                Empleado.MdiParent = this;
                Empleado.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Empleado.Focus();
            }
        }

        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonItem14_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(Tipoempleado))
            {
                Tipoempleado = new Puesto();
                Tipoempleado.MdiParent = this;
                Tipoempleado.Show();
            }
            else
            {
                MessageBox.Show("Actualmente tiene el Formulario activa.", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Tipoempleado.Focus();
            }
        }
    }
}
