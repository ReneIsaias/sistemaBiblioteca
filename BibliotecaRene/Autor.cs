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
    public partial class Autor : Form
    {
        Biblioteca obj = new Biblioteca();
        public Autor()
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
            Autor_Load(sender, e);
        }

        private void Autor_Load(object sender, EventArgs e)
        {
            obj.conectaRene();
           // obj.llenaCuadriculaRene(dataGridView1, "SELECT nombreAutor AS NOMBRE, apellidoUnoAutor AS PATERNO, apellidoDosAutor AS PATERNO, nombreCortoAutor AS NOMBRE_CORTO FROM Autor");
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            try
            {
                if ((textBox1.Text != "") && (textBox3.Text != "") && (textBox2.Text != "") && (textBox4.Text != ""))
                {
                   // obj.ejecutaRene("EXEC InOuAutor '" + textBox1.Text + "', '" + textBox2.Text + "','" + textBox3.Text+ "','"+textBox4.Text+"','"+textBox6.Text+"'");
                    MessageBox.Show("Autor Guardado Correctamente");
                    Autor_Load(sender, e);
                    button3_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Llene los campos");
                }
            }
            catch
            {
                MessageBox.Show("Consulta ejecuta con Horrores XP");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }
    }
}   
