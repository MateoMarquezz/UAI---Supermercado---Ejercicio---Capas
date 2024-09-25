using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GUI
{
    public partial class Formulario : Form
    {
        public Formulario()
        {
            InitializeComponent();
            timer1.Start();
        }

        BLL.ALUMNO gestor = new BLL.ALUMNO();
        BE.ALUMNO tmp;

        private void timer1_Tick(object sender, EventArgs e)
        {
            spFecha.Text = DateTime.Now.ToLongDateString();
            spHora.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //SqlConnection CN = new SqlConnection();
        //void Conectar()
        //{
        //    CN.ConnectionString = @"Data Source=ACCENTU-AFOGH2R;Initial Catalog=Universidad_FES;Integrated Security=True";
        //    //CN.ConnectionString = @"Data Source=.\SQL_UAI;Initial Catalog=Facultad;Integrated Security=True";
        //    CN.Open();
        //}

        //void Desconectar()
        //{
        //    CN.Close();
        //    CN.Dispose();
        //}

        //private void btnConectar_Click(object sender, EventArgs e)
        //{
        //    Conectar();
        //    textBox1.BackColor = Color.Green;
        //}

        //private void btnDesconectar_Click(object sender, EventArgs e)
        //{
        //    Desconectar();
        //    textBox1.BackColor = Color.Red;
        //}


        //SqlCommand CM = new SqlCommand();

        //void Leer()
        //{
        //    List<clsLista> lista = new List<clsLista>();
        //    Conectar();
        //    CM.Connection = CN;
        //    CM.CommandType = CommandType.Text;
        //    CM.CommandText = "Select * from Alumnos";
        //    SqlDataReader lector = CM.ExecuteReader();
        //    while (lector.Read())
        //    {
        //        clsLista Al = new clsLista();
        //        Al._ID = int.Parse(lector["Id"].ToString());
        //        Al._Nombre = lector["Nombre"].ToString();
        //        Al._Apellido = lector["Apellido"].ToString();
        //        Al._Edad = int.Parse(lector["Edad"].ToString());
        //        Al._Sexo = lector["Sexo"].ToString();

        //        lista.Add(Al);
        //        dataGridView1.DataSource = null;
        //        dataGridView1.DataSource = lista;
        //    }

        //    Desconectar();




        //}



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tmp = (BE.ALUMNO)dataGridView1.Rows[e.RowIndex].DataBoundItem;
            txtNombre.Text = tmp._Nombre;
            txtApellido.Text = tmp._Apellido;
            txtEdad.Text = tmp.Fecha_Nacimiento.ToShortDateString();
            cmbSexo.Text = tmp._Sexo;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            tmp = new BE.ALUMNO();
            tmp._ID = 0;
            tmp._Nombre = txtNombre.Text;
            tmp._Apellido = txtApellido.Text;
            tmp.Fecha_Nacimiento = DateTime.Parse(txtEdad.Text);
            tmp._Sexo = cmbSexo.Text;
            gestor.Actualizar(tmp);
            tmp = null;
            Enlazar();
        }



        void Enlazar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = gestor.Listar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            tmp._Nombre = txtNombre.Text;
            tmp._Apellido = txtApellido.Text;
            tmp.Fecha_Nacimiento = DateTime.Parse(txtEdad.Text);
            tmp._Sexo = cmbSexo.Text;
            gestor.Actualizar(tmp);
            tmp = null;
            Enlazar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            gestor.Eliminar(tmp);
            tmp = null;
            Enlazar();
        }
    }
}
