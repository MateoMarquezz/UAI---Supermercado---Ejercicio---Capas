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
using System.Data.Sql;
using System.Data;
using System.Data.Common;

namespace DataGridButtons
{
    public partial class Form1 : Form
    {
        private string CNString = "Data Source=.;Initial Catalog=Facultad;Integrated Security=True;Encrypt=False";


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            inicializarDataGrid();
        }


        private void dataGridViewEditar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (e.ColumnIndex == dataGridView1.Columns["Eliminar"].Index)
            {
                deleteDB((Persona)dataGridView1.Rows[e.RowIndex].DataBoundItem);
                inicializarDataGrid();
                MessageBox.Show("usuario Eliminado");
            }
            if (e.ColumnIndex == dataGridView1.Columns["Editar"].Index)
            {
                actualizarDB((Persona)dataGridView1.Rows[e.RowIndex].DataBoundItem);
                inicializarDataGrid();
                MessageBox.Show("usuario Actualizado");
            }
            
        }


        private void UpdateDatagridSource()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = leerDB();
        }

        private List<Persona> leerDB()
        {
            List<Persona> personaList = new List<Persona>();

            using (SqlConnection con = new SqlConnection(CNString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "select * from Persona";
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Persona persona = new Persona();
                    persona.Apellido = dr["apellido"].ToString();
                    persona.Nombre = dr["nombre"].ToString();
                    persona.Genero = dr["genero"].ToString();
                    persona.ID = (int)dr["id"];
                    persona.Edad = (int)dr["edad"];
                    personaList.Add(persona);
                }
                dr.Close();
                con.Close();
            }
            return personaList;
        }

        private void actualizarDB(Persona persona)
        {
            using (SqlConnection con = new SqlConnection(CNString)) {

                con.Open();
                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = $@"UPDATE [dbo].[Persona] SET [Nombre] = @nombre ,[Apellido] = @apellido ,[Edad] = @edad ,[Genero] = @genero  WHERE Id = @id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("id", SqlDbType.Int).Value = persona.ID;
                cmd.Parameters.Add("nombre", SqlDbType.VarChar).Value = persona.Nombre;
                cmd.Parameters.Add("apellido", SqlDbType.VarChar).Value = persona.Apellido;
                cmd.Parameters.Add("edad", SqlDbType.Int).Value = persona.Edad;
                cmd.Parameters.Add("genero", SqlDbType.VarChar).Value = persona.Genero;

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private void deleteDB(Persona persona)
        {
            using (SqlConnection con = new SqlConnection(CNString))
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $@"DELETE FROM [dbo].[Persona] WHERE Id = @id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("id", SqlDbType.Int).Value = persona.ID;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void inicializarDataGrid()
        {
            UpdateDatagridSource();
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            if (dataGridView1.DataSource != null)
            {
                DataGridViewButtonColumn BtnEliminarColumna = new DataGridViewButtonColumn();
                BtnEliminarColumna.HeaderText = "Eliminar";
                BtnEliminarColumna.Name = "Eliminar";
                BtnEliminarColumna.Text = "Eliminar";
                BtnEliminarColumna.UseColumnTextForButtonValue = true;

                if (dataGridView1.Columns["Eliminar"] == null)
                {
                    dataGridView1.Columns.Insert(0, BtnEliminarColumna);
                }


                DataGridViewButtonColumn BtnEditarColumna = new DataGridViewButtonColumn();
                BtnEditarColumna.Name = "Editar";
                BtnEditarColumna.HeaderText = "Editar";
                BtnEditarColumna.Text = "Editar";
                BtnEditarColumna.UseColumnTextForButtonValue = true;

                if (dataGridView1.Columns["Editar"] == null)
                {
                    dataGridView1.Columns.Insert(0, BtnEditarColumna);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateDatagridSource();
        }
    }
}
