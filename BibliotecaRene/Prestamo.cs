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
    public partial class Prestamo : Form
    {   //Creamos un objeto de la clase Biblioteca el cual llamamos obj
        Biblioteca obj = new Biblioteca();
        public String user;
        public Prestamo()
        {
            InitializeComponent();
        }

        private void Prestamo_Load(object sender, EventArgs e)
        {   //Inicamos la conexion en el formulario
            obj.conectaRene();  //Establecemos la conexion
            obj.llenaCuadriculaRene(dataGridView1, "SELECT * FROM PRESTAMO");
            //Con el objeto de biblioteca utilizamos el metodo de llenar Cuadricula para llenar el datagridview 1 con los prestamos realizados
            validarUsuario();
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
        public void obtieneUsuario(String usuario)
        {
            label3.Text = usuario;
            user = usuario;
        }
        private void button1_Click(object sender, EventArgs e)
        {   //Boton regresar
            Close(); //Cerramos la vista en al que estamos trabajando actualmente
        }

        private void button3_Click(object sender, EventArgs e)
        {   //Boton Limpiar
            obj.limpiarRene(this);  //Mandamos llamar al objeto de la clase Biblioteca limpiar para limpiar nuestra vista
            Prestamo_Load(sender, e);//Actualizamos la Vista de Prestamo en caso de que haya algun cambio
        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {   //Con este metodo realizamos la vista la busqueda de los lectores y lo pasamos al datagrid de lectores
            //Con ayuda de un procedimiento pasamos las palabrs que escriba e el textbox
            obj.llenaCuadriculaRene(dataGridView2, "EXEC BuscaLectorPrestamos '" + textBox4.Text + "'");
            //Una vez terminada cerramos la conexion
            obj.leerRene.Close();
        }

        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {   //Con este metodo realizamos la vista la busqueda de los ejemplares y lo pasamos al datagrid de ejemplares
            //Con ayuda de un procedimiento pasamos las palabras que escriba e el textbox
            obj.llenaCuadriculaRene(dataGridView3, "EXEC BuscaEjemplarPrestamos '" + textBox5.Text + "'");
            //Una vez terminada cerramos la conexion
            obj.leerRene.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {   //Pasamos la clave de un lector al que el usuario seleccione en la busqueda de un lector
            textBox4.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {   //Pasamos la clave de ejmplar al que el usuario seleccione en la busqueda de un ejemplar
            textBox5.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
        }

        private void comboBox3_MouseClick(object sender, MouseEventArgs e)
        {   //LLenamos el combobox de las condiciones que puede tener un ejemplar
            obj.llenaComboRene(comboBox3, "EXEC llenaComboCondicion '"+ 1 +"'");
        }

        private void button2_Click(object sender, EventArgs e)
        {   //Boton Guardar
            //Con el objeto y el metod de ejecuta, pasamos los datos de que ingresa el usuario al momento de realizar un prestamos.
            //Los datos se los pasamos al precedimiento de InUpPrestamos que es el procedimiento creado anteriormente
            //obj.ejecutaRene("EXEC InUpPrestamos '"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+"','"+comboBox3.Text+"'");
            try
            {
                if ((textBox4.Text != "")&&(textBox5.Text != "") && (comboBox3.Text != ""))
                {
                    obj.ejecutaRene("EXEC SavePrestamo '" + textBox4.Text + "','" + textBox5.Text + "','" + comboBox3.Text + "'");
                    //Notificamos que se ejecuto correctamente
                    MessageBox.Show("Se debe de guardar un prestamo");
                    //Actualizamos el formulario para ver el nuevo regsitro
                    Prestamo_Load(sender, e);
                    button3_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Llene los campos primero");
                }
            }
            catch
            {
                MessageBox.Show("Ocurrio un error inseperado");
            }           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {   //Pasamos a los textbox los valores que el usuario seleccione en el datagridview
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {   //Aqui actualizamos la fecha real de prestamo de un prestamo que ya se ha realizado,
            //Ahora pasamos los mismos datos al procedimiento de actualizar prestamo en donde solo actulizamos
            try
            {
                if((textBox1.Text != "")&& (textBox2.Text !="")&&(textBox4.Text!="")&&(textBox5.Text != "") && (comboBox3.Text != ""))
                {                                        
                    obj.ejecutaRene("EXEC UpdatePrestamo '" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + comboBox3.Text + "'");
                    //Notificamos que se ha actualiado correctamente
                    MessageBox.Show("Se debe de actualizar un prestamo");
                    //Cargamos el formulario                                        
                    hacerSancion();
                    Prestamo_Load(sender, e);
                    button3_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("LLene los campos primero");
                }
            }
            catch
            {
                MessageBox.Show("Ocurrio un error inseperado");
            }            
        }

        private void button5_Click(object sender, EventArgs e)
        {           
            obj.llenaCuadriculaRene(dataGridView1, "SELECT Prestamo.fechaPrestamo AS PRESTAMO, Prestamo.fechaEntrega AS ENTREGA, Prestamo.fechaRealEntrega AS ENTREGADO, Prestamo.clavePersona AS PERSONA, Prestamo.claveEjemplar AS EJEMPLAR, Condicion.descripcionCondicion AS CONDICION FROM Prestamo,Condicion WHERE Prestamo.idCondicion = Condicion.idCondicion AND fechaRealEntrega IS NULL");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            obj.llenaCuadriculaRene(dataGridView1, "SELECT Prestamo.fechaPrestamo AS PRESTAMO, Prestamo.fechaEntrega AS ENTREGA, Prestamo.fechaRealEntrega AS ENTREGADO, Prestamo.clavePersona AS PERSONA, Prestamo.claveEjemplar AS EJEMPLAR, Condicion.descripcionCondicion AS CONDICION FROM Prestamo,Condicion WHERE Prestamo.idCondicion = Condicion.idCondicion AND fechaRealEntrega IS NOT NULL");
        }
        public void hacerSancion()
        {
            if ((comboBox3.Text == "PESIMA") || (comboBox3.Text == "ROTO") || (comboBox3.Text == "MALA"))
            {
                MessageBox.Show("Condicion mala");
                Sancioncs sancion = new Sancioncs();
                sancion.obtenerEjemplar(textBox5, textBox1);
                sancion.ShowDialog();
            }
            else
            {
                MessageBox.Show("Buen estado");
            }
        }

        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {
            obj.ejecutaRene("SELECT GETDATE()");
            string hoy = "";
            obj.leerRene.Read();
            hoy = obj.leerRene[0].ToString();
            textBox6.Text = hoy;
            obj.leerRene.Close();

            if (textBox6.Text == textBox2.Text)
            {

            }
        }
    }
}
    