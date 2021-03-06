﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BibliotecaRene
{
    class Biblioteca
    {
        //Datos que necesitamos para la conexion
        public String strConectionRene = "Data Source=DESKTOP-OSHPITS;Initial Catalog='tesjiBiblioteca';Integrated Security=True";
        //Guardar datos que tenemos en nuestras consultas
        //public SqlCommand DataSet;
        DataSet ds;
        //Van los comandos que sean SQL (consultas)(insert,updates,deletes,procedures)
        public SqlCommand consultaRene;
        //vamos a tener acceso a la matriz(fila,columna) de una tabla(resultados)
        public SqlDataReader leerRene;
        //Conectar nuestras variables anteriores a la conexion con la BD
        public SqlConnection conexionRene;
        DataSet cuadriculaRene = new DataSet();

        public void conectaRene()
        {
            SqlConnection conexion = new SqlConnection(strConectionRene);
            conexion.Open();
           // System.Windows.Forms.MessageBox.Show("Conexion establecida");
            //Console.WriteLine("Conexion establecida correctamente");
            consultaRene = new SqlCommand();
            consultaRene.Connection=conexion;
        }
        //Metodo para ejecutar, recibiendo parametros de la BD
        //Todo SQL que entre en nuestro sistema va tener que pasar por aqui
        public void ejecutaRene(String SqlReneEjecuta)
        {
            //Saber que tipo de consulta vamos a hacer
            consultaRene.CommandType = CommandType.Text;
            //Asignar a la consulta el sql que recivimos de parametro(sqlRene)
            consultaRene.CommandText = SqlReneEjecuta;
            //Guardamos la consulta en la variable leerRene
            leerRene = consultaRene.ExecuteReader();             
        }
        //metodo que llena culauqier tipo de combo en el formulario
        //el primer parametro es el comb que vamos allenar y el segundo es con que los vamos a llenar
        public void llenaComboRene(ComboBox comboRene, String sqlRenellena)
        {            
            //Ejecutamos nuestra consulta
            ejecutaRene(sqlRenellena);
            //limpiamos el combo que tiene daos para insertar datos nuevos
            comboRene.Items.Clear();
            //While -> Cuando no sabemos las interaciones que se va a hacer
            //For -> sabemos cuantas interaciones vamos a hacer
            //
            while (leerRene.Read())
            {
                //Va a leer desde la posicion primera de la consulta
                comboRene.Items.Add(leerRene[0]);
            }
            //Cerramos la consulta
            leerRene.Close();
        }

        //Este metodo es para llenar las cuadriculas, es decir que vamos a mostrar datos sobre unas tablas basicamente
        public void llenaCuadriculaRene(DataGridView tablaRene, String sqlReneTabla)
        {            
            //Ejecutamos nuestra consulta
            ejecutaRene(sqlReneTabla);
            //Cerramos la consulta
            leerRene.Close();
            //lo vlovemos a crear para que cada que se utilize se limpie y solo muestre los datos que se realizan durante la consulta
            DataSet cuadriculaRene = new DataSet();
            //Creamos la misma variable declarada al inicio para que la limpie la tabla
            SqlDataAdapter  datador = new SqlDataAdapter(consultaRene);
            //El de datos es un alias o nombre
            datador.Fill(cuadriculaRene,"DATOS");
            //Es para mostrar los datos en la cuadricula que tengamos en el formulario las 2 lienas siguientes      
            tablaRene.DataSource = cuadriculaRene;
            tablaRene.DataMember = "DATOS";
        }
        public void limpiarRene(Form formularioRene)
        {    
            foreach (Control objeto in formularioRene.Controls)
            {
                if ((objeto is TextBox) || (objeto is ComboBox)){
                    objeto.Text = "";
                }
            }
        }
        public void limpiarReneFull(Panel formularioRene)
        {
            //Recorremos los objetos en el formularios
            foreach (Control objeto in formularioRene.Controls)
            {
                //validamos si es el objeto de tipo textBox o comboBox
                if ((objeto is TextBox) || (objeto is ComboBox))
                {
                    //Limipamos o regresamos a la pocision 0 o inicial de cada objeto
                    objeto.Text = "";
                }
            }
        }
        public void llenaListBox(ListBox listaRene,String sqlReneList)
        {
            //Ejecutamos nuestra consulta
            ejecutaRene(sqlReneList);
            //limpiamos el combo que tiene daos para insertar datos nuevos
            listaRene.Items.Clear();
            //While -> Cuando no sabemos las interaciones que se va a hacer
            //For -> sabemos cuantas interaciones vamos a hacer
            //
            while (leerRene.Read())
            {
                //Va a leer desde la posicion primera de la consulta
                listaRene.Items.Add(leerRene[0]);
            }
            //Cerramos la consulta
            leerRene.Close();
        }
        public void llenaCheckList(CheckedListBox checkRene, String sqlReneCheck)
        {
            //Ejecutamos nuestra consulta
            ejecutaRene(sqlReneCheck);
            //limpiamos el combo que tiene daos para insertar datos nuevos
            checkRene.Items.Clear();
            //While -> Cuando no sabemos las interaciones que se va a hacer
            //For -> sabemos cuantas interaciones vamos a hacer
            //
            while (leerRene.Read())
            {
                //Va a leer desde la posicion primera de la consulta
                checkRene.Items.Add(leerRene[0]);
            }
            //Cerramos la consulta
            leerRene.Close();
        }
    }
}
