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
    public partial class Configurar : Form
    {
        Biblioteca obj = new Biblioteca();
        public String user;
        public String idUsuario;
        public Configurar()
        {
            InitializeComponent();
        }
        public void obtieneUsuario(String usuario)
        {
            label5.Text = usuario;
            user = usuario;
            label1.Text = usuario;
        }
        private void Configurar_Load(object sender, EventArgs e)
        {
            obj.conectaRene();
            obj.llenaListBox(listBox1, "EXEC llenaDataPermisos '" + user+"'");
            obj.ejecutaRene("SELECT * FROM USUARIO WHERE nombrePerfil = '" + user+"'");
            obj.leerRene.Read();
            //label6.Text = obj.leerRene[5].ToString();
            label5.Text = user;
            if (obj.leerRene[6].ToString() == "True")
            {
                label3.Text = "Activo";
            }
            else
            {
                label3.Text = "Inactivo";
            }
            obj.leerRene.Close(); 
            obj.ejecutaRene("SELECT CONCAT(nombreUsuario,' ',apeUnoUsuario,' ',apeDosUsuario) FROM USUARIO WHERE nombrePerfil = '"+user+"'");
            obj.leerRene.Read();
            label2.Text = obj.leerRene[0].ToString();
            obj.leerRene.Close();
            this.Height = 395;
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            label18.Visible = false;
            obj.ejecutaRene("SELECT * FROM USUARIO WHERE nombrePerfil = '"+user+"'");
            obj.leerRene.Read();
            idUsuario = obj.leerRene[0].ToString();
            textBox1.Text = obj.leerRene[1].ToString();
            textBox2.Text = obj.leerRene[2].ToString();
            textBox3.Text = obj.leerRene[3].ToString();
            textBox6.Text = obj.leerRene[4].ToString();
            textBox4.Text = obj.leerRene[5].ToString();
            textBox5.Text = obj.leerRene[5].ToString();
            obj.leerRene.Close();
            this.Height = 590;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox6.Text != "")&&(textBox4.Text!="")&&(textBox5.Text!=""))
                {
                    if((textBox4.Text == textBox5.Text))
                    {
                        obj.ejecutaRene("EXEC usuarioUp '"+idUsuario+"','"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox6.Text+"','"+textBox4.Text+"','"+label1.Text+"'");
                        obj.leerRene.Read();
                        label18.Visible = true;
                        label18.Text = obj.leerRene[0].ToString();
                        obj.leerRene.Close();
                        MessageBox.Show("Datos Guardados");
                        Configurar_Load(sender, e);
                        panel1.Visible = false;
                        obj.limpiarReneFull(panel1);
                        
                    }
                    else
                    {                        
                        MessageBox.Show("Las contraseñas deben ser iguales");
                    }
                }
                else
                {
                    MessageBox.Show("Llene todos los campos");
                }
            }
            catch
            {
                MessageBox.Show("Error al ejecutar la consulta");
                MessageBox.Show("Debera de volver a iniciar sesion");
                this.Hide();
                Close();
                Usuarios user = new Usuarios();
                user.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            obj.limpiarReneFull(panel1);
            panel1.Visible = false;
            this.Height = 395;
        }

        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox5.Text == textBox4.Text)
            {
                label18.Visible = false;
                label18.Text = "";
                button3.Enabled = true;
            }
            else
            {
                label18.Visible = true;
                label18.Text = "Las contraseñas no coinciden";
                button3.Enabled = false;
            }
        }
    }
}
