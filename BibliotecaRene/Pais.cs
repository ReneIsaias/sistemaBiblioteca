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
    
    public partial class Pais : Form
    {
        Biblioteca obj = new Biblioteca();
        public string user;
        public Pais()
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
            label6.Text = "";
            Pais_Load(sender, e);
        }

        private void Pais_Load(object sender, EventArgs e)
        {
            obj.conectaRene();
            obj.llenaCuadriculaRene(dataGridView1, "EXEC verPaises '" + 1 + "'");
            validarUsuario();
        }
        public void validarUsuario()
        {
            obj.ejecutaRene("EXEC validaUsuario '" + user + "'");
            while (obj.leerRene.Read())
            {
                foreach (Control objeto in this.Controls)
                {
                    if (objeto is PictureBox || objeto is Button)
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
        public void obtieneUsuario(String usuario)
        {
            label7.Text = usuario;
            user = usuario;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if ((textBox1.Text != "") && (comboBox1.Text != ""))
                {
                    obj.ejecutaRene("EXEC paisInUp '"+label6.Text+ "','" + textBox1.Text + "','" + comboBox1.SelectedIndex + "','" + label7.Text + "'");
                    if (obj.leerRene.Read())
                    {
                        MessageBox.Show(obj.leerRene[0].ToString());
                    }
                    obj.leerRene.Close();
                    //MessageBox.Show("Pais Guardado Correctamente");
                    Pais_Load(sender, e);
                    button3_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("LLene todos los campos");
                }
            }
            catch
            {
                MessageBox.Show("Ocurrio un error en el servidor");
            }                       
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label6.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            obj.llenaCuadriculaRene(dataGridView1, "EXEC buscaPais '" + textBox2.Text + "'");
            obj.leerRene.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            obj.llenaCuadriculaRene(dataGridView1, "EXEC verPaisesDetalle '" + 1 + "'");
        }
    }
}
