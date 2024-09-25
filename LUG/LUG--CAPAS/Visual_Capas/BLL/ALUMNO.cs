using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class ALUMNO
    {
        private void CalcularEdad(BE.ALUMNO a)
        {
            if (a.Fecha_Nacimiento.Month>DateTime.Now.Month || (a.Fecha_Nacimiento.Month == DateTime.Now.Month && a.Fecha_Nacimiento.Day > DateTime.Now.Day))
            {
                a._Edad--;
            }
        }

        Dal.ALUMNO mapper = new Dal.ALUMNO();

        public List<BE.ALUMNO> Listar()
        {
            List<BE.ALUMNO> Alumnos = mapper.Listar();

            foreach (BE.ALUMNO p in Alumnos)
            {
                CalcularEdad(p);
            }
            return Alumnos;
        }

        public int Eliminar(BE.ALUMNO Alum)
        {
            return mapper.Eliminar(Alum);

        }

        public int Actualizar(BE.ALUMNO Alum)
        {
            int res;
            


                if (Alum._ID == 0)
                {
                   
                   res = mapper.Agregar(Alum);
                    
                    
                }
                else
                {
                    res = mapper.Editar(Alum);
                }
                return res;
           
            
        }



    }
}
