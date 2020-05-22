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
    public partial class UsuariosInserta : Form
    {
        Biblioteca obj = new Biblioteca();
        public String user;
        public UsuariosInserta()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox4.Text != "") && (textBox5.Text != "") && (textBox6.Text != "") && (comboBox1.Text != ""))
                {
                    if (textBox6.Text == textBox5.Text)
                    {
                        obj.ejecutaRene("EXEC usuarioInUp '"+label13.Text +"','"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+"','"+comboBox1.SelectedIndex+"','"+user+"'");
                        if (obj.leerRene.Read())
                        {
                            MessageBox.Show(obj.leerRene[0].ToString());
                        }
                        obj.leerRene.Close();
                        button1_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Las contraseñas deben ser iguales");
                    }
                }
                else
                {
                    MessageBox.Show("Llene los campos requeridos");
                }
            }
            catch
            {
                MessageBox.Show("Error en el servidor");
                MessageBox.Show("Seleccione bien el Estado del Usuario");
            }
        }

        private void UsuariosInserta_Load(object sender, EventArgs e)
        {
            obj.conectaRene();
            obj.llenaCuadriculaRene(dataGridView1, "EXEC verUsuarioNor '"+1+"'");
            validarUsuario();
        }
        public void obtieneUsuario(String usuario)
        {
            label10.Text = usuario;
            user = usuario;
        }
        public void validarUsuario()
        {
            obj.ejecutaRene("EXEC validaUsuario '" + label10.Text + "'");
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
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            obj.limpiarRene(this);
            UsuariosInserta_Load(sender, e);
            label11.Text = "";
            label11.Visible = false;
            label13.Text = "";
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            obj.ejecutaRene("EXEC revisaUsuario '" + textBox4.Text+"'");
            obj.leerRene.Read();
            label11.Visible = true;
            label11.Text = obj.leerRene[0].ToString();
            if(obj.leerRene[0].ToString() == "El usuario ya existe!")
            {
                button3.Enabled = false;
            }
            else
            {
                button3.Enabled = true;
            }
            obj.leerRene.Close();            
        }

        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox5.Text == textBox6.Text)
            {
                label11.Visible = false;
                label11.Text = "";
                button3.Enabled = true;
            }
            else
            {
                label11.Visible = true;
                label11.Text = "Las contraseñas no coinciden";
                button3.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            obj.llenaCuadriculaRene(dataGridView1, "EXEC verUsuarioFull '"+1+"'");
        }

        private void textBox7_KeyUp(object sender, KeyEventArgs e)
        {
            obj.llenaCuadriculaRene(dataGridView1, "EXEC buscaUsuario '" + textBox7.Text + "'");
            obj.leerRene.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label13.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            obj.ejecutaRene("EXEC verUsuarioDetalle '" + label13.Text + "'");
            if (obj.leerRene.Read())
            {
                textBox1.Text = obj.leerRene[0].ToString();
                textBox2.Text = obj.leerRene[1].ToString();
                textBox3.Text = obj.leerRene[2].ToString();
                textBox5.Text = obj.leerRene[3].ToString();
                textBox6.Text = obj.leerRene[3].ToString();
                comboBox1.Text = obj.leerRene[4].ToString();
            }
            obj.leerRene.Close();
        }
    }
}
