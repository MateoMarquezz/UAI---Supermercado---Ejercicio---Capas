using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace capas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        BE.Persona per;
        BLL.Persona gestorPer =new BLL.Persona();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {   
            per = new BE.Persona();
            per.Legajo=int.Parse(txtLegajo.Text);
            per.Nombre=txtNombre.Text;
            per.Apellido=txtApellido.Text;
            per.Edad=int.Parse(txtEdad.Text);
            per.Genero=txtGenero.Text;  

            gestorPer.AgregarPersona(per);
            


        }
    }
}
