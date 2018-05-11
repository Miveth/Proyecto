﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Pro_AYD2_1
{
    public class DBComun
    {

        public SqlConnection conexion;
        public Boolean conexcion_establecida = false;

        public DBComun()
        {

            conexion = new SqlConnection("Data Source=SKULLPCR;Initial Catalog=AYD_P;Integrated Security=True");
            try
            {
                insertardatos("Select * from usuario;");
                conexcion_establecida = true;
            }
            catch (Exception e)
            {
                conexcion_establecida = false;

            }
        }

        public Boolean conexcion_bool()
        {


            return conexcion_establecida;
        }
        public SqlConnection getconexion
        {

            get
            {
                return conexion;
            }

        }
        public void insertardatos(String cadena)
        {


            SqlCommand comando = new SqlCommand(cadena, conexion);
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();

        }

        public int suma(int a, int b)
        {


            return a + b;
        }
    }
}