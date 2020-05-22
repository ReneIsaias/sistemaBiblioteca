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
    public partial class Permisos : Form
    {
        Biblioteca obj = new Biblioteca();

        public Permisos()
        {
            InitializeComponent();
        }
        public void llenaPermisosUsuario()
        {
            obj.ejecutaRene("EXEC dale");
            if (obj.leerRene.Read()) {

            }
           
        }
            
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if ((comboBox1.Text != ""))
                {
                    obj.ejecutaRene("EXEC eliminaPermisos '" + comboBox1.Text + "'");
                    obj.leerRene.Read();
                    MessageBox.Show(obj.leerRene[0].ToString());
                    obj.leerRene.Close();
                    for (int a = 0; a < checkedListBox1.CheckedItems.Count; a++)
                    {
                        string permiso = "";
                        permiso = checkedListBox1.CheckedItems[a].ToString();
                        MessageBox.Show(permiso);
                        obj.ejecutaRene("EXEC rolUsuarioIn '" + comboBox1.Text + "','" + permiso + "'");
                        obj.leerRene.Read();                        
                        obj.leerRene.Close();
                    }
                    MessageBox.Show("Permisos Asignados Correctamente");
                    obj.limpiarRene(this);
                    Permisos_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Seleccione a un usuario");
                }
            }
            catch
            {
                MessageBox.Show("Error al conectar con el servidor");
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Permisos_Load(object sender, EventArgs e)
        {
            obj.conectaRene();
            obj.llenaCuadriculaRene(dataGridView1, "EXEC llenaDataUsuario '" + 1 +"'");
            obj.llenaCuadriculaRene(dataGridView2, "EXEC llenaDataPermisos '" + comboBox1.Text+"'");
            obj.llenaCheckList(checkedListBox1, "EXEC llenaCheckListBox '" + 1 +"'");
            validarUsuario();
        }
        public void obtieneUsuario(String usuario)
        {
            label7.Text = usuario;
        }
        public void validarUsuario()
        {
            obj.ejecutaRene("EXEC validaUsuario '"+label7.Text+"'");
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
        private void button3_Click(object sender, EventArgs e)
        {
            obj.limpiarRene(this);
            Permisos_Load(sender, e);
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            obj.llenaComboRene(comboBox1, "EXEC llenaComboUsuarios '" + 1 + " '");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            obj.llenaCuadriculaRene(dataGridView2, "EXEC llenaDataPermisos '" + comboBox1.Text + "'");
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            obj.llenaCuadriculaRene(dataGridView1, "EXEC llenaDataUsuariosFull '" + 1 + "'");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            UsuariosInserta user = new UsuariosInserta();
            user.obtieneUsuario(label7.Text);
            user.ShowDialog();
        }
    }
}
