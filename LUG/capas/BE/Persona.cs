using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Persona
    {
		private int legajo;

		public int Legajo
		{
			get { return legajo; }
			set { legajo = value; }
		}

		private string nombre;

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

		private string apellido;

		public string Apellido
		{
			get { return apellido; }
			set { apellido = value; }
		}

		private int edad;

		public int Edad
		{
			get { return edad; }
			set { edad = value; }
		}

		private string genero;

		public string Genero
		{
			get { return genero; }
			set { genero = value; }
		}



	}
}
