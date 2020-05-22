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
    public partial class Sancioncs : Form
    {
        Biblioteca obj = new Biblioteca();
        public String user;
        public Sancioncs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if ((textBox1.Text != "") && (comboBox1.Text !=""))
                {
                    //obj.ejecutaRene("EXEC InSanciones '" + textBox1.Text+"','"+comboBox1.Text+"','"+textBox3.Text+"'");
                    MessageBox.Show("Sancion agregada correctamente");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    comboBox1.Text = "";
                    Sancioncs_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Llena todos los campos");
                }
            }
            catch
            {
                MessageBox.Show("Error en el servidor");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            obj.limpiarRene(this);
            Sancioncs_Load(sender, e);
        }

        private void Sancioncs_Load(object sender, EventArgs e)
        {
            obj.conectaRene();
           // obj.llenaCuadriculaRene(dataGridView1, "SELECT SancionPrestamo.duracionSancionPrestamo, Sancion.descripcionSancion, Prestamo.fechaPrestamo, Prestamo.claveEjemplar, Prestamo.clavePersona FROM SancionPrestamo INNER JOIN Prestamo ON SancionPrestamo.idPrestamo = Prestamo.idPrestamo INNER JOIN Sancion ON SancionPrestamo.idSancion = Sancion.idSancion");
        }
        public void obtieneUsuario(String usuario)
        {
            label7.Text = usuario;
            user = usuario;
        }
        public void validarUsuario()
        {
            obj.ejecutaRene("validaUsuario'" + user + "'");
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
        public void obtenerEjemplar(TextBox ejemplar, TextBox fechaPrestamo)
        {
            textBox3.Text = ejemplar.Text;
            textBox4.Text = fechaPrestamo.Text;
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
           // obj.llenaComboRene(comboBox1, "SELECT Sancion.descripcionSancion FROM Sancion WHERE statusSancion=1");
        }
    }
}
