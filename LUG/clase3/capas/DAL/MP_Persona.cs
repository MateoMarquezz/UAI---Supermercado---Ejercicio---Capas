using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MP_Persona
    {
        Acceso acc=new Acceso();

        public int AgregarPersona(BE.Persona per) 
        {
            int fa = 0;
            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter("@legajo",per.Legajo);
            parametros[1] = new SqlParameter("@nombre", per.Nombre);
            parametros[2] = new SqlParameter("@apellido", per.Apellido);
            parametros[3] = new SqlParameter("@edad",per.Edad);
            parametros[4] = new SqlParameter("@genero",per.Genero);
            fa = acc.Escribir("AgregarPersona", parametros);

            return fa;
        }   



    }
}
