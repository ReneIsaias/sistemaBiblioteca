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
    public partial class Usuarios : Form
    {
        Biblioteca obj = new Biblioteca();
        public Usuarios()
        {
            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            obj.conectaRene();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            obj.limpiarRene(this);
            label4.Visible = false;
            Usuarios_Load(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try { 
                if ((textBox1.Text != "")&&(textBox2.Text != ""))
                {
                    obj.ejecutaRene("EXEC validaLogin '"+textBox1.Text+"','"+textBox2.Text+"'");
                    if (obj.leerRene.Read())
                    {
                        string usuario;
                        string pasword;
                        usuario = obj.leerRene[0].ToString();
                        pasword = obj.leerRene[1].ToString();
                        if ((textBox1.Text == usuario) && (textBox2.Text == pasword))
                        {
                            label4.Visible = false;
                           // MessageBox.Show("Bienvenido " + usuario);
                            this.Hide();
                            MenuPrincipalcs objeto = new MenuPrincipalcs();
                            objeto.obtieneUsuario(usuario);
                            objeto.ShowDialog();
                            obj.leerRene.Close();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Usuario no identificado");
                            label4.Visible = true;
                            obj.leerRene.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario no identificado");
                        label4.Visible = true;
                        obj.leerRene.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Llene los campos requeridos");                    
                }
            }
            catch
            {
                MessageBox.Show("Error al ejecutar la consulta");                    
            }
        }
    }
}