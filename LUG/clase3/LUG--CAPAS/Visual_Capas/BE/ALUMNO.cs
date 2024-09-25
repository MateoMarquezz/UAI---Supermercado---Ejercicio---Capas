using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ALUMNO
    {
        private int ID;

        public int _ID
        {
            get { return ID; }
            set { ID = value; }
        }
        private string Nombre;

        public string _Nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

        private string Apellido;

        public string _Apellido
        {
            get { return Apellido; }
            set { Apellido = value; }
        }

        private DateTime fn;

        public DateTime Fecha_Nacimiento
        {
            get { return fn; }
            set { fn = value; }
        }
        private int Edad;

        public int _Edad
        {
            get { return Edad; }
            set { Edad = value; }
        }

        private string Sexo;

        public string _Sexo
        {
            get { return Sexo; }
            set { Sexo = value; }
        }
    }
}
