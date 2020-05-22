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

    public partial class Form1 : Form
    {
        //Objeto de la BD 
        Biblioteca obj = new Biblioteca();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            obj.conectaRene();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            obj.ejecutaRene(textBox1.Text);
            obj.leerRene.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            obj.llenaComboRene(comboBox1, "SELECT Categoria.descripcionCategoria FROM Categoria");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            obj.llenaCuadriculaRene(dataGridView1, textBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            obj.llenaCuadriculaRene(dataGridView2, textBox3.Text);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        {
            obj.llenaComboRene(comboBox2, "SELECT Pais.nombrePais FROM Pais");
        }
    }
}
