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
    public partial class Condiciones : Form
    {
        Biblioteca obj = new Biblioteca();
        public string user;
        public Condiciones()
        {
            InitializeComponent();
        }

        private void Condiciones_Load(object sender, EventArgs e)
        {
            obj.conectaRene();
            obj.llenaCuadriculaRene(dataGridView1, "EXEC llenaCondiciones '"+ 1 + "'");
            validarUsuario();
        }
        public void obtieneUsuario(String usuario)
        {
            user = usuario;
            label8.Text = usuario;
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
                if ((textBox1.Text != "") && (textBox2.Text != "") && (comboBox2.Text != ""))
                {
                    obj.ejecutaRene("EXEC condicionesInUp '" + label7.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox2.SelectedIndex + "','" + label8.Text + "'");
                    if (obj.leerRene.Read())
                    {
                        MessageBox.Show(obj.leerRene[0].ToString());
                    }
                    //MessageBox.Show("Categoria Guardada Correctamente");
                    Condiciones_Load(sender, e);
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

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            obj.limpiarRene(this);
            Condiciones_Load(sender, e);
            label7.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            obj.llenaCuadriculaRene(dataGridView1, "EXEC llenaCondicionesDetalle '" + 1 +"'");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label7.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            obj.llenaCuadriculaRene(dataGridView1, "EXEC buscaCondiciones '" + textBox3.Text + "'");
            obj.leerRene.Close();
        }
    }
}
