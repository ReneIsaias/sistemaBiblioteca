using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliotecaRene
{
    public partial class PerfilRene : Form
    {
        Biblioteca obj = new Biblioteca();
        public String datoViejo = "";
        public String usuario = "";
        public PerfilRene()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((textBox1.Text != "") && (comboBox1.Text != ""))
                {
                    obj.ejecutaRene("EXEC TipoPersonaUpIn '" + label7.Text + "','" + textBox1.Text + "','" + comboBox1.SelectedIndex + "','" + label6.Text + "'");
                    if (obj.leerRene.Read())
                    {
                        MessageBox.Show(obj.leerRene[0].ToString());
                    }
                    //MessageBox.Show("Dato Guardado Correctamente");
                    PerfilRene_Load(sender, e);
                    button2_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Llene todos los campos");
                }
            }
            catch
            {
                MessageBox.Show("Ocurrio un error inesperado en el servidor");
            }           
        }

        private void PerfilRene_Load(object sender, EventArgs e)
        {
            obj.conectaRene();
            obj.llenaCuadriculaRene(dataGridView1, "EXEC llenaPerfil '" + 1 +"'");
            validarUsuario();
        }
        public void obtieneUsuario(string user)
        {
            label6.Text = user;
            usuario = user;
        }
        public void validarUsuario()
        {
            obj.ejecutaRene("EXEC validaUsuario '" + usuario + "'");
            while (obj.leerRene.Read())
            {
                foreach (Control objeto in this.Controls)
                {
                    if (objeto is Button || objeto is PictureBox)
                    {
                        if (objeto.Tag.Equals(obj.leerRene[0].ToString()))
                        {
                            objeto.Enabled = true;
                            objeto.Visible = true;
                        }
                    }
                }
            }
            obj.leerRene.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                label7.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                datoViejo = textBox1.Text;
            }
            catch
            {
                MessageBox.Show("Ocurrio en error XD");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            obj.limpiarRene(this);
            label7.Text = "";
            PerfilRene_Load(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            obj.llenaCuadriculaRene(dataGridView1, "EXEC buscaTipoPersona '" + textBox3.Text + "'");
            obj.leerRene.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            obj.llenaCuadriculaRene(dataGridView1,"EXEC llenaPerfilDetalle '"+1+"'");
        }
    }
}
