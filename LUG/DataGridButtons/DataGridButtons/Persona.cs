using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridButtons
{
    public class Persona
    {
        public Persona() { }

        public Persona(int id, string nombre, string apellido, int edad, string genero)
        {
            _id = id;
            _nombre = nombre;
            _apellido = apellido;
            _edad = edad;
            _genero = genero;
        }

        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        private String _nombre;

        public String Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        private String _apellido;

        public String Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        private int _edad;

        public int Edad
        {
            get { return _edad; }
            set { _edad = value; }
        }

        private String _genero;

        public String Genero
        {
            get { return _genero; }
            set { _genero = value; }
        }


    }
}
