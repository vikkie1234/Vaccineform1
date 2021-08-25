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

namespace VaccinationForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cs = "Data Source=LAPTOP-0705L4TV;Initial Catalog=Registerdb;Integrated Security=True";
            SqlConnection connection = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Vaccine1 values(@Firstname, @Surname, @Gender, @ID)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Firstname", textBox1.Text);
            cmd.Parameters.AddWithValue("@Surname", textBox2.Text);
            cmd.Parameters.AddWithValue("@ID", long.Parse(textBox3.Text));
            string gender;
            if (radioButton1.Checked) { gender = "Female"; }
            else { gender = "Male"; }
            cmd.Parameters.AddWithValue("@Gender", gender);
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Data Entered");
        }
    }
}
