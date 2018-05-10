using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Pro_AYD2_1
{
    public class DBComun
    {

        public SqlConnection conexion;

        public DBComun()
        {

            conexion = new SqlConnection("Data Source=SKULLPCR;Initial Catalog=AYD_P;Integrated Security=True");

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
    }
}