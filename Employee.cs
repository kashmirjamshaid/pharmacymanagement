using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Pharmacy_mangment_24
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=KASHMIR\\MSSQLSERVER01;Initial Catalog=FPKJ;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            DashBoard Obj = new DashBoard();
            Obj.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this Emp_Tab", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("INSERT INTO [Emp_Tab](Name,Salary,Age,PhoneNumber)VALUES(@Name,@Salary,@Age,@PhoneNumber)", con);
                   

                    cmd.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));

                    cmd.Parameters.AddWithValue("@Name", textBox3.Text);


                    cmd.Parameters.AddWithValue("@Salary", int.Parse(textBox2.Text));

                    cmd.Parameters.AddWithValue("@Age", int.Parse(textBox4.Text));

                    cmd.Parameters.AddWithValue("@PhoneNumber", int.Parse(textBox5.Text));

                    con.Open();

                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Data Saved");
                    

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadStudent()
        {

            dataGridView.Rows.Clear();
            cmd = new SqlCommand("SELECT * FROM [Emp_Tab]", con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                dataGridView.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadStudent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("Update [Emp_Tab] set Name=@Name,Salary=@Salary,Age=@Age,PhoneNumber=@PhoneNumber where Id=@Id", con);

            cmd.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));

            cmd.Parameters.AddWithValue("@Name", textBox3.Text);
            cmd.Parameters.AddWithValue("@Age", int.Parse(textBox4.Text));



            cmd.Parameters.AddWithValue("@Salary", int.Parse(textBox2.Text));

            cmd.Parameters.AddWithValue("@PhoneNumber", int.Parse(textBox5.Text));

            

            cmd.ExecuteNonQuery();
            

            MessageBox.Show("Data Updated");
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("Delete [Emp_Tab] where Id=@Id", con);

            cmd.Parameters.AddWithValue("Id", int.Parse(textBox1.Text));

            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Data Deleted");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
    }

