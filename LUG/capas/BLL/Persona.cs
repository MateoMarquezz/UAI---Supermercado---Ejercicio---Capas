using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Persona
    {
        MP_Persona mapper=new MP_Persona();

        public int AgregarPersona(BE.Persona per)
        {
            return mapper.AgregarPersona(per);

        }

    }
}
