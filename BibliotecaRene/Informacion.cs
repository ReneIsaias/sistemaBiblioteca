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
    public partial class Informacion : Form
    {
        Biblioteca obj = new Biblioteca();
        public String user;
        public Informacion()
        {
            InitializeComponent();
        }

        private void Informacion_Load(object sender, EventArgs e)
        {
            obj.conectaRene();
            validarUsuario();
        }
        public void obtieneUsuario(String usuario)
        {
            user = usuario;
            label8.Text = usuario;
        }
        public void validarUsuario()
        {
            obj.ejecutaRene("EXEC validaUsuario '" + label8.Text + "'");
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

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aqui accederas a los detalles de las tablas, los cambios pueden afectar al sistema");
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            OrigenEjemplar origen = new OrigenEjemplar();
            origen.obtieneUsuario(label8.Text);
            origen.ShowDialog();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            PerfilRene perfil = new PerfilRene();
            perfil.obtieneUsuario(label8.Text);
            perfil.ShowDialog();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            SituacionPersonaRene situacion = new SituacionPersonaRene();
            situacion.obtieneUsuario(label8.Text);
            situacion.ShowDialog();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            Condiciones condicion = new Condiciones();
            condicion.obtieneUsuario(label8.Text);
            condicion.ShowDialog();
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            Permisos permi = new Permisos();
            permi.ShowDialog();
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            SancionesAplicar sancion = new SancionesAplicar();
            sancion.obtieneUsuario(label8.Text);
            sancion.ShowDialog();
        }

        private void pictureBox9_Click_1(object sender, EventArgs e)
        {
            Carrera carrera = new Carrera();
            carrera.obtieneUsuario(label8.Text);
            carrera.ShowDialog();
        }

        private void pictureBox8_Click_1(object sender, EventArgs e)
        {
            Editorial editorial = new Editorial();
            editorial.obtieneUsuario(label8.Text);
            editorial.ShowDialog();
        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria();
            categoria.obtieneUsuario(label8.Text);
            categoria.ShowDialog();
        }
    }
}
