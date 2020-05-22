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
    public partial class Lectores : Form
    {
        Biblioteca obj = new Biblioteca();
        public String usuario;
        
        public Lectores()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
            obj.llenaComboRene(comboBox1, "EXEC llenaComboTipoPersona '"+1+"'");   
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {         
        }
        private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        {
            obj.llenaComboRene(comboBox2, "EXEC llenaComboEstadoPersona '"+1+"'");
        }

        private void Lectores_Load(object sender, EventArgs e)
        {
            obj.conectaRene();
            obj.llenaCuadriculaRene(dataGridView1, "EXEC llenaDataLectores '" + 1 +"'");
            validarUsuario();
            label10.Visible = false;
        }
        public void obtieneUsuario(string user)
        {
            Lector.Text = user;
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
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PerfilRene perfil = new PerfilRene();
            perfil.obtieneUsuario(usuario);
            perfil.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SituacionPersonaRene situacion = new SituacionPersonaRene();
            situacion.obtieneUsuario(usuario);
            situacion.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != "") && (textBox8.Text != "") && (textBox5.Text != "") && (textBox6.Text != "") && (comboBox1.Text != "") && (comboBox2.Text != "") && (comboBox3.Text != "") && (comboBox4.Text != ""))
                {
                    obj.ejecutaRene("EXEC lectoresInUp '" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" +textBox8.Text+ "','"+ comboBox3.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox4.SelectedIndex + "','"+usuario+"'");
                    if (obj.leerRene.Read())
                    {
                        MessageBox.Show(obj.leerRene[0].ToString());
                    }
                    obj.leerRene.Close();
                    //MessageBox.Show("Lector Insertado Correctamente");
                    Lectores_Load(sender, e);
                    button2_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Llena todos los campos");
                }
            }
            catch
            {
                MessageBox.Show("Ocurrio un error en el servidor");
            }                       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            obj.limpiarRene(this);
            Lectores_Load(sender, e);
            label10.Visible = false;
            textBox1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox7_KeyUp(object sender, KeyEventArgs e)
        {
            obj.llenaCuadriculaRene(dataGridView1, "EXEC buscaLectores '" + textBox7.Text + "'");
            obj.leerRene.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            obj.llenaCuadriculaRene(dataGridView1, "EXEC llenaDataLectoresFull '" + 1 + "'");
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            obj.ejecutaRene("EXEC validaLector '" + textBox1.Text + "'");
            obj.leerRene.Read();
            label10.Visible = true;
            label10.Text = obj.leerRene[0].ToString();
            if (obj.leerRene[0].ToString() == "El lector ya existe!")
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
            obj.leerRene.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Enabled = false;
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            obj.ejecutaRene("EXEC detalleLector '" + textBox1.Text + "'");
            if (obj.leerRene.Read())
            {
                textBox2.Text = obj.leerRene[0].ToString();
                textBox3.Text = obj.leerRene[1].ToString();
                textBox4.Text = obj.leerRene[2].ToString();
            }
            obj.leerRene.Close();
            textBox5.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            comboBox4.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        private void comboBox3_MouseClick(object sender, MouseEventArgs e)
        {
            obj.llenaComboRene(comboBox3, "EXEC llenaComboCarrera '"+ 1 + "'");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Carrera carrera = new Carrera();
            carrera.obtieneUsuario(usuario);
            carrera.ShowDialog();
        }
    }
}