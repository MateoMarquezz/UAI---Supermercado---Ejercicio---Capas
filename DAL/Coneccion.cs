using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    internal class Coneccion
    {
        SqlConnection conexion = new SqlConnection();

        void Abrir()
        {
            conexion.ConnectionString = @"Data Source=MATEO\SQLEXPRESS;Initial Catalog=Supermercados;Integrated Security=True;Trust Server Certificate=True";
        
            conexion.Open();
        }

        void Cerrar()
        {
            conexion.Close();
        }


        public DataTable Leer(string st, SqlParameter[] parametros)
        {

        }




    }
}
