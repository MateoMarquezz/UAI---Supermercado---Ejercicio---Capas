using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Dal
{
    public  class Acceso
    {
        SqlConnection conexion = new SqlConnection();
        void Abrir()
        {
            conexion.ConnectionString = @"Data Source=ACCENTU-AFOGH2R;Initial Catalog=Universidad_FES;Integrated Security=SSPI";
            //conexion.ConnectionString = @"Data Source=.\SQL_UAI; Initial Catalog=Universidad_FES; Integrated Security=SSPI";
            conexion.Open();
        }

        void Cerrar()
        {
            conexion.Close();
        }

        public DataTable Leer(string st, SqlParameter[] parametros)
        {
            Abrir();
            DataTable tabla = new DataTable();
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = new SqlCommand();
            adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
            adaptador.SelectCommand.CommandText = st;
            if (parametros != null)
            {
                adaptador.SelectCommand.Parameters.AddRange(parametros);
            }
            adaptador.SelectCommand.Connection = conexion;
            adaptador.Fill(tabla);
            Cerrar();
            return tabla;
        }

        public int Escribir(string st, SqlParameter[] parametros)
        {
            int fa = 0;
            Abrir();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = st;
            cmd.Connection = conexion;

            cmd.Parameters.AddRange(parametros);

            try
            {
                fa = cmd.ExecuteNonQuery();
            }
            catch
            {
                fa = -1;
            }

            Cerrar();



            return fa;
        }
    }

}