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
    public partial class Editorial : Form
    {
        Biblioteca obj = new Biblioteca();
        public String usuario;
        public Editorial()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            obj.limpiarRene(this);
            Editorial_Load(sender, e);
            label7.Text = "";
        }

        private void Editorial_Load(object sender, EventArgs e)
        {
            obj.conectaRene();
            obj.llenaCuadriculaRene(dataGridView1, "EXEC llenaEditorial '"+ 1 +"'");
            validarUsuario();
        }
        public void obtieneUsuario(String user)
        {
            usuario = user;
            label8.Text = usuario;
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
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if ((textBox1.Text != "") && (textBox2.Text != "") && (comboBox2.Text != ""))
                {
                    obj.ejecutaRene("EXEC editorialInUp '" + label7.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','"+comboBox2.SelectedIndex+"','"+label8.Text+"'");
                    if (obj.leerRene.Read())
                    {
                        MessageBox.Show(obj.leerRene[0].ToString());
                    }
                    //MessageBox.Show("Editorial Guardada Correctamente");
                    Editorial_Load(sender, e);
                    button3_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Llene los campos");
                }
            }
            catch
            {
                MessageBox.Show("Ocurrio un error inesperado XP");
            }            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                label7.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                comboBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();                
            }
            catch
            {
                MessageBox.Show("Ocurrio en error en la carga de datos");
            }
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            obj.llenaCuadriculaRene(dataGridView1, "EXEC buscaEditorial '" + textBox3.Text + "'");
            obj.leerRene.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            obj.llenaCuadriculaRene(dataGridView1, "EXEC llenaEditorialDetalle '" + 1 + "'");
        }
    }
}
