using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Dal
{
    public class ALUMNO
    {
        Acceso acceso = new Acceso();

        public List<BE.ALUMNO> Listar()
        {
            List<BE.ALUMNO> ls = new List<BE.ALUMNO>();

            DataTable tabla = acceso.Leer("ListarALUMNO", null);

            foreach(DataRow Registro in tabla.Rows)
            {
                BE.ALUMNO Alumno = new BE.ALUMNO();
                Alumno._ID = int.Parse(Registro["ID"].ToString());
                Alumno._Nombre = Registro["Nombre"].ToString();
                Alumno._Apellido = Registro["Apellido"].ToString();
                Alumno.Fecha_Nacimiento=new DateTime(long.Parse(Registro["FechaNacimiento"].ToString()));
                Alumno._Sexo = Registro["Sexo"].ToString();

                ls.Add(Alumno);
            }
            return ls;

            
        }

        public int Agregar(BE.ALUMNO Alum)
        {
            int fa = 0;
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("@Nombre", Alum._Nombre);
            parametros[1] = new SqlParameter("@Apellido", Alum._Apellido);
            parametros[2] = new SqlParameter("@Fecha_Nacimiento", Alum.Fecha_Nacimiento);
            parametros[3] = new SqlParameter("@Sexo", Alum._Sexo);
            fa = acceso.Escribir("InsertarALUMNOS", parametros);

            return fa;
        }

        public int Editar(BE.ALUMNO Alum)
        {
            int fa = 0;
            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter("@Nombre", Alum._Nombre);
            parametros[1] = new SqlParameter("@Apellido", Alum._Apellido);
            parametros[2] = new SqlParameter("@FechaNacimiento", Alum.Fecha_Nacimiento);
            parametros[3] = new SqlParameter("@Sexo", Alum._Sexo);
            parametros[4] = new SqlParameter("@ID", Alum._ID);
            fa = acceso.Escribir("EditarALUMNO", parametros);

            
            return fa;

        }

        public int Eliminar(BE.ALUMNO Alum)
        {
            int fa = 0;
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@ID", Alum._ID);
            fa = acceso.Escribir("EliminarALUMNO", parametros);

            return fa;
        }
    }
}
