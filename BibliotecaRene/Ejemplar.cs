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
    public partial class Ejemplar : Form
    {
        Biblioteca obj = new Biblioteca();
        public String usuario;
        public Ejemplar()
        {
            InitializeComponent();
        }

        private void Ejemplar_Load(object sender, EventArgs e)
        {
            obj.conectaRene();
            obj.llenaCuadriculaRene(dataGridView1, "EXEC verEjemplares'" + 1 + "'");
        }
        public void obtieneUsuario(string user)
        {
           label8.Text = user;
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
        private void button3_Click(object sender, EventArgs e)
        {
            obj.limpiarRene(this);
            Ejemplar_Load(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if ((textBox1.Text != "") && (textBox2.Text != "") && (comboBox3.Text != "") && (comboBox2.Text != "") && (comboBox1.Text != ""))
                {
                    obj.ejecutaRene("EXEC InUpEjemplar '" + textBox1.Text + "', '" + textBox2.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "'");
                    MessageBox.Show("Ejemplar Guardado Correctamente");
                    Ejemplar_Load(sender, e);
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

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            obj.llenaComboRene(comboBox1, "EXEC llenaComboLibro '"+ 1 +"'");
        }

        private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        {
            obj.llenaComboRene(comboBox2, "EXEC llenaComboCondicion'"+ 1 +"'");
        }

        private void comboBox3_MouseClick(object sender, MouseEventArgs e)
        {
            obj.llenaComboRene(comboBox3, "EXEC llenaComboOrigen'"+ 1 +"'");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }
    }
}
