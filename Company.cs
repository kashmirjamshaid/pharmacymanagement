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
    public partial class Company : Form
    {
        SqlConnection con = new SqlConnection("Data Source=KASHMIR\\MSSQLSERVER01;Initial Catalog=FPKJ;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public Company()
        {
            InitializeComponent();
        }
        public void LoadStudent()
        {

            dataGridView.Rows.Clear();
            cmd = new SqlCommand("SELECT * FROM [Table]", con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                dataGridView.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
            }
            dr.Close();
            con.Close();
        }
      
        private void MedicineGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView.Rows.Clear();
            cmd = new SqlCommand("SELECT * FROM [Table]", con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                dataGridView.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void Company_Load(object sender, EventArgs e)
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
                if (MessageBox.Show("Are you sure you want to save this Table", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();

                    cmd = new SqlCommand("INSERT INTO [TabLe](CompName,CompAddress,PhoneNumber)VALUES(@CompName,@CompAddress,@PhoneNumber)", con);


                    cmd.Parameters.AddWithValue("@CompID", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@CompName",textBox3.Text);



                    cmd.Parameters.AddWithValue("@CompAddress", textBox4.Text);

                    cmd.Parameters.AddWithValue("@PhoneNumber", int.Parse(textBox5.Text));

                   
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

        private void button5_Click(object sender, EventArgs e)
        {
            LoadStudent();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("Update [Table] set CompName=@CompName,CompAddress=@CompAddress,PhoneNumber=@PhoneNumber where CompID=@CompID", con);

            cmd.Parameters.AddWithValue("@CompID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("CompName", textBox3.Text);
         



            cmd.Parameters.AddWithValue("@PhoneNumber", int.Parse(textBox5.Text));

            cmd.Parameters.AddWithValue("@CompAddress", (textBox4.Text));
            

            cmd.ExecuteNonQuery();
            

            MessageBox.Show("Data Updated");
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("Delete [Table] where CompID=@CompID", con);

            cmd.Parameters.AddWithValue("CompID", int.Parse(textBox1.Text));

            cmd.ExecuteNonQuery();
           

            MessageBox.Show("Data Deleted");
            con.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
    }
