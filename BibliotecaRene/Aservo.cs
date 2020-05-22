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
    public partial class Aservo : Form
    {
        public int datos = 0;
        public int vaa = 0;
        Biblioteca obj = new Biblioteca();
        public String user;
        public Aservo()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != "") && (textBox5.Text != "") && (textBox6.Text != "") && (textBox7.Text != "") && (textBox8.Text != "") && (textBox9.Text != "")  && (textBox11.Text != "") &&  (comboBox3.Text != "") && (comboBox1.Text != "") && (comboBox2.Text != "") && (comboBox3.Text != "") && (comboBox4.Text != "") && (comboBox5.Text != ""))
                {
                    obj.ejecutaRene("EXEC libroInUp '"+ label16.Text +"','"+label20.Text +"','" + textBox2.Text + "','" + textBox1.Text + "','" + textBox11.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox4.Text + "','" + comboBox5.Text + "','" + comboBox2.Text + "','" + comboBox4.Text + "','" + comboBox1.Text + "','" + comboBox3.SelectedIndex + "','"+label15.Text+"'");
                    if (obj.leerRene.Read())
                    {
                        MessageBox.Show(obj.leerRene[0].ToString());
                    }
                    //MessageBox.Show("Aservo Guardado correctamente");
                    //obj.llenaCuadriculaRene(dataGridView2, "");
                    Aservo_Load(sender, e);
                    button3_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Llene todos los campos");
                }
            }
            catch
            {
                MessageBox.Show("Ocurrio un error en el servidor");
            }            
        }

        private void Aservo_Load(object sender, EventArgs e)
        {
            obj.conectaRene();
            obj.llenaCuadriculaRene(dataGridView1, "EXEC verLibros'"+ 1 +"'");
            button6_Click(sender,e);
            validarUsuario();
        }
        public void validarUsuario()
        {
            obj.ejecutaRene("EXEC validaUsuario '" + user + "'");
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
            label15.Text = usuario;
            user = usuario;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            obj.limpiarRene(this);
            label16.Text = "";
            label20.Text = "";
            Aservo_Load(sender, e);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Idiomacs idioma = new Idiomacs();
            idioma.obtieneUsuario(label15.Text);
            idioma.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Pais pais = new Pais();
            pais.obtieneUsuario(label15.Text);
            pais.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Editorial editorial = new Editorial();
            editorial.obtieneUsuario(label15.Text);
            editorial.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Categoria cate = new Categoria();
            cate.obtieneUsuario(label15.Text);
            cate.ShowDialog();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox5_MouseClick(object sender, MouseEventArgs e)
        {
            obj.llenaComboRene(comboBox5, "EXEC llenaComboIdioma '"+ 1 +"'");
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            obj.llenaComboRene(comboBox1, "EXEC llenaComboPais '" + 1 + "'");
        }

        private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        {
            obj.llenaComboRene(comboBox2, "EXEC llenaComboEditorial '" + 1 + "'");
        }


        private void comboBox4_MouseClick(object sender, MouseEventArgs e)
        {
            obj.llenaComboRene(comboBox4, "EXEC llenaComboCategoria '" + 1 + "'");
        }

        private void comboBox3_MouseClick_1(object sender, MouseEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label16.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            label20.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            comboBox5.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();            
            comboBox2.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            comboBox4.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();
        }

        private void textBox10_KeyUp(object sender, KeyEventArgs e)
        {
            obj.llenaCuadriculaRene(dataGridView1, "EXEC buscaLibro '" + textBox10.Text + "'");
            obj.leerRene.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Autor objAutor = new Autor();
            objAutor.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Ejemplar objEjem = new Ejemplar();
            objEjem.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e) //boton de condicion
        {
            //Con este lleno los dos combos de origen y estado de ejemplar
            //creamos un objeto del data grid para llenar una celda/
            DataGridViewComboBoxCell celda = new DataGridViewComboBoxCell();
            datos = dataGridView2.RowCount;            
            obj.ejecutaRene("EXEC llenaComboCondicion '" + 1 + "'");
            while (obj.leerRene.Read())
            {
                celda.Items.Add(obj.leerRene[0].ToString());
            }
            //MessageBox.Show("Este es condicion en vaa : "+vaa);
            dataGridView2[2, (datos-1)] = celda;
            obj.leerRene.Close();

            //este es el de origen
            DataGridViewComboBoxCell objeto = new DataGridViewComboBoxCell();
            obj.ejecutaRene("EXEC llenaComboOrigen '" + 1 + "'");
            while (obj.leerRene.Read())
            {
                objeto.Items.Add(obj.leerRene[0].ToString());
            }
            //MessageBox.Show("Este es origen en vaa = " + vaa);
            dataGridView2[3, (datos-1)] = objeto;
            obj.leerRene.Close();
        }

        private void button7_Click(object sender, EventArgs e) //boton de origen
        {
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AutoresAservocs objauAs = new AutoresAservocs();
            objauAs.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
        }

        private void button10_Click(object sender, EventArgs e)
        {
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                if ((textBox3.Text != ""))
                {
                    int x;
                    vaa = dataGridView2.RowCount - 1;                    
                    for(x = 0; x < dataGridView2.RowCount - 1; x++)
                    {
                        MessageBox.Show("este es el vaa . " + vaa);
                        //obj.ejecutaRene("EXEC InUpEjemplar '" + dataGridView2.CurrentRow.Cells[0].Value.ToString() + "', '" + dataGridView2.CurrentRow.Cells[1].Value.ToString() + "','" + textBox3.Text + "','" + dataGridView2.CurrentRow.Cells[2].Value.ToString() + "','" + dataGridView2.CurrentRow.Cells[3].Value.ToString() + "'");
                        //obj.ejecutaRene("EXEC InUpEjemplar '" + dataGridView2[0, x].Value+ "','" + dataGridView2[1, x].Value + "','" + textBox3.Text + "','" + dataGridView2[2, x].Value+ "','" + dataGridView2[3, x].Value + "'");
                        MessageBox.Show("Va :" + x);
                        obj.leerRene.Close();
                    }                                        
                        MessageBox.Show("Ejemplares Guardados Correctamente");
                }
                else
                {
                     MessageBox.Show("Error datos no validos vacios");
                }
            }
            catch
            {
                MessageBox.Show("Error datos no validos");
            }                
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            button6_Click(sender, e);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            obj.llenaCuadriculaRene(dataGridView1, "EXEC verLibrosDetalle '" + 1 + "'");
        }
    }
}