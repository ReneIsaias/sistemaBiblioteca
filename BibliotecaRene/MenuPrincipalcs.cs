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
    public partial class MenuPrincipalcs : Form
    {
        Biblioteca obj = new Biblioteca();
        public String usuario;
        public MenuPrincipalcs()
        {
            InitializeComponent();
        }

        private void MenuPrincipalcs_Load(object sender, EventArgs e)
        {
            obj.conectaRene();
            validarUsuario();
            labeles();
        }
        public void obtieneUsuario(string user)
        {
            label2.Text = user;
            usuario = user;
        }
        public void validarUsuario()
        {
            obj.ejecutaRene("EXEC validaUsuario '" + label2.Text + "'");
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
        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            label7.Visible = true;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            label7.Visible = false;
        }

        private void pictureBox8_MouseMove(object sender, MouseEventArgs e)
        {
            label8.Visible = true;
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            label8.Visible = false;
        }

        private void pictureBox9_MouseMove(object sender, MouseEventArgs e)
        {
            label9.Visible = true;
        }

        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            label9.Visible = false;
        }

        private void pictureBox12_MouseMove(object sender, MouseEventArgs e)
        {
            label4.Visible = true;
        }

        private void pictureBox12_MouseLeave(object sender, EventArgs e)
        {
            label4.Visible = false;
        }

        private void pictureBox10_MouseMove(object sender, MouseEventArgs e)
        {
            label5.Visible = true;
        }

        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
            label5.Visible = false;
        }

        private void pictureBox11_MouseMove(object sender, MouseEventArgs e)
        {
            label6.Visible = true;
        }

        private void pictureBox11_MouseLeave(object sender, EventArgs e)
        {
            label6.Visible = false;
        }

        private void pictureBox13_MouseMove(object sender, MouseEventArgs e)
        {
            label10.Visible = true;
        }

        private void pictureBox13_MouseLeave(object sender, EventArgs e)
        {
            label10.Visible = false;
        }

        private void pictureBox14_MouseMove(object sender, MouseEventArgs e)
        {
            label11.Visible = true;
        }

        private void pictureBox14_MouseLeave(object sender, EventArgs e)
        {
            label11.Visible = false;
        }

        private void pictureBox15_MouseMove(object sender, MouseEventArgs e)
        {
            label12.Visible = true;
        }

        private void pictureBox15_MouseLeave(object sender, EventArgs e)
        {
            label12.Visible = false;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Visible = true;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            label1.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Usuarios user = new Usuarios();
            user.ShowDialog();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            UsuariosInserta adduser = new UsuariosInserta();
            adduser.obtieneUsuario(usuario);
            adduser.ShowDialog();
            MenuPrincipalcs_Load(sender, e);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Aservo aservo = new Aservo();
            aservo.obtieneUsuario(usuario);
            aservo.ShowDialog();
            MenuPrincipalcs_Load(sender, e);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Ejemplar ejemplar = new Ejemplar();
            ejemplar.ShowDialog();
            MenuPrincipalcs_Load(sender, e);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Lectores lector = new Lectores();
            lector.obtieneUsuario(usuario);
            lector.ShowDialog();
            MenuPrincipalcs_Load(sender, e);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Prestamo presta = new Prestamo();
            presta.obtieneUsuario(usuario); 
            presta.ShowDialog();
            MenuPrincipalcs_Load(sender, e);
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            Permisos permi = new Permisos();
            permi.obtieneUsuario(usuario);
            permi.ShowDialog();
            MenuPrincipalcs_Load(sender, e);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Configurar conf = new Configurar();
            conf.obtieneUsuario(usuario);
            conf.ShowDialog();
            MenuPrincipalcs_Load(sender, e);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Sancioncs sancio = new Sancioncs();
            sancio.obtieneUsuario(usuario);
            sancio.ShowDialog();
            MenuPrincipalcs_Load(sender, e);
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Informacion info = new Informacion();
            info.obtieneUsuario(usuario);
            info.ShowDialog();
            MenuPrincipalcs_Load(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((textBox2.Text != "") && (textBox3.Text != "") && (textBox5.Text != "") &&(textBox6.Text != "") && (comboBox1.Text != ""))
                {
                    MessageBox.Show("El prestamos se hizo correctamente");
                    labeles();
                }
                else
                {
                    label19.Text = "Ingrese los campos requeridos";
                    MessageBox.Show("Ingrese los campos requeridos");
                    labelesTrue();
                    
                }
            }
            catch
            {
                MessageBox.Show("Ocurrio un error con el servidor");
            }
        }
        public void labeles()
        {
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            label24.Visible = false;
        }
        public void labelesTrue()
        {
            label19.Visible = true;
            label20.Visible = true;
            label21.Visible = true;
            label22.Visible = true;
            label23.Visible = true;
            label24.Visible = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if ((textBox2.Text != "") && (textBox3.Text != "") && (textBox5.Text != "") && (textBox6.Text != "") && (comboBox1.Text != ""))
                {
                    MessageBox.Show("El regreso  del prestamos se hizo correctamente");
                    labeles();
                }
                else
                {
                    label19.Text = "Ingrese los campos requeridos";
                    MessageBox.Show("Ingrese los campos requeridos");
                    labelesTrue();
                }
            }
            catch
            {
                MessageBox.Show("Ocurrio un error con el servidor");
            }
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            obj.limpiarRene(this);
            MenuPrincipalcs_Load(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            obj.limpiarRene(this);
            MenuPrincipalcs_Load(sender, e);
        }
    }
}