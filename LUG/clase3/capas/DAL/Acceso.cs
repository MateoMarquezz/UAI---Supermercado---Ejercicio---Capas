using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Acceso
    {
        SqlConnection cn = new SqlConnection();

        void Conectar()
        {
            cn.ConnectionString= @"Data Source=.;Initial Catalog=Facultad;Integrated Security=True";
            cn.Open();
        }
        
        void Desconectar()
        {
            cn.Close();
        }

        public int Escribir(string st, SqlParameter[] parametros)
        {
            SqlCommand cmd= new SqlCommand();
            int fa = 0;
            Conectar();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = st;
            cmd.Parameters.AddRange(parametros);

            try
            {
                fa=cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                fa = -1;
                
            }
            Desconectar();
            return fa;
        }

    }
}
