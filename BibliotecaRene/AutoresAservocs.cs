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
    public partial class AutoresAservocs : Form
    {
        Biblioteca obj = new Biblioteca();
        public AutoresAservocs()
        {
            InitializeComponent();
        }

        private void AutoresAservocs_Load(object sender, EventArgs e)
        {
            obj.conectaRene();
            obj.llenaCuadriculaRene(dataGridView1, "SELECT Aservo.tituloAservo AS ASERVO, Autor.nombreCortoAutor AS AUTOR FROM AutorAcervo INNER JOIN Aservo ON AutorAcervo.claveAservo = Aservo.claveAservo INNER JOIN Autor ON AutorAcervo.idAutor = Autor.idAutor");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
