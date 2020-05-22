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
    public partial class Categoria : Form
    {
        Biblioteca obj = new Biblioteca();
        public String user;
        public Categoria()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label6.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            obj.limpiarRene(this);
            Categoria_Load(sender, e);
            label6.Text = "";
        }

        private void Categoria_Load(object sender, EventArgs e)
        {
            obj.conectaRene();
            obj.llenaCuadriculaRene(dataGridView1, "EXEC llenaCategorias '" + 1 + "'");
            validarUsuario();
        }
        public void obtieneUsuario(String usuario)
        {
            user = usuario;
            label7.Text = usuario;
        }
        public void validarUsuario()
        {
            obj.ejecutaRene("EXEC validaUsuario '" + user + "'");
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
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if ((textBox1.Text != "") && (comboBox1.Text != ""))
                {
                   obj.ejecutaRene("EXEC categoriaInUp '" + label6.Text + "','" + textBox1.Text + "','" + comboBox1.SelectedIndex + "','"+label7.Text+"'");
                    if (obj.leerRene.Read())
                    {
                        MessageBox.Show(obj.leerRene[0].ToString());
                    }
                    //MessageBox.Show("Categoria Guardada Correctamente");
                    Categoria_Load(sender, e);
                    button3_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Llene todos los campos");
                }
            }
            catch
            {
                MessageBox.Show("Ocurrio un error en el servidor");
            }           
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            obj.llenaCuadriculaRene(dataGridView1, "EXEC buscaCategoria '" + textBox2.Text + "'");
            obj.leerRene.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            obj.llenaCuadriculaRene(dataGridView1, "EXEC llenaCategoriasDetalle '" + 1 + "'");
        }
    }
}
