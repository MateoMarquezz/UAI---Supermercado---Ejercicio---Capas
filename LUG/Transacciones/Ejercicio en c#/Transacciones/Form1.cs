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

namespace Transacciones
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            SqlConnection Cn = new SqlConnection(@"Data Source=.;Initial Catalog=Empleados;Integrated Security=True");
            Cn.Open();

            SqlTransaction TR;

            SqlCommand CM;

            TR = Cn.BeginTransaction();

            try
            {
            CM = new  SqlCommand("INSERT INTO EMPLEADO (IdEmpleado, Nombre, Sueldo) Values(1,'JOSE',2000)", Cn);

            CM.Transaction = TR;

            CM.ExecuteNonQuery();

            CM = new SqlCommand("INSERT INTO EMPLEADO (IdEmpleado, Nombre, Sueldo) Values(2,'LUIS',1800)", Cn);

            CM.Transaction = TR;

            CM.ExecuteNonQuery();

            CM = new SqlCommand("INSERT INTO EMPLEADO (IdEmpleado, Nombre, Sueldo) Values(3,'PEDRO',4000)", Cn);

            CM.Transaction = TR;

            CM.ExecuteNonQuery();

            TR.Commit();
                
            MessageBox.Show("Datos Ingresados");
            }

            catch (Exception Ex){
                TR.Rollback ();
                 MessageBox.Show(Ex.Message );
            }



            Cn.Close();

        }

     

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
