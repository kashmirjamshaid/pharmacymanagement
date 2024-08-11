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
    public partial class Billing : Form
    {
        public Billing()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=KASHMIR\\MSSQLSERVER01;Initial Catalog=FPKJ;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this Billing_Tab", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO [Billing_Tab](MedName,UnitPrice,TotalPrice,Quantity)VALUES(@MedName,@UnitPrice,@TotalPrice,@Quantity)", con);


                    cmd.Parameters.AddWithValue("@MedName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@MedID", int.Parse(textBox1.Text));



                    cmd.Parameters.AddWithValue("@UnitPrice", int.Parse(textBox3.Text));

                    cmd.Parameters.AddWithValue("@Quantity", int.Parse(textBox5.Text));
                    cmd.Parameters.AddWithValue("@TotalPrice", int.Parse(textBox4.Text));


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
            cmd = new SqlCommand("SELECT * FROM [Billing_Tab]", con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                dataGridView.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadStudent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<int> totalPriceList = new List<int>(); // List to store TotalPrice values
            int totalPriceSum = 0; // Variable to store the sum of TotalPrice

            cmd = new SqlCommand("SELECT TotalPrice FROM [Billing_Tab]", con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int totalPrice = Convert.ToInt32(dr["TotalPrice"]); // Read TotalPrice from database
                totalPriceList.Add(totalPrice); // Add TotalPrice to the list
            }
            dr.Close();
            con.Close();

            // Calculate the sum of TotalPrice values
            foreach (int price in totalPriceList)
            {
                totalPriceSum += price;
            }

            // Display the total sum in a message box
            MessageBox.Show("Total Price: " + totalPriceSum);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            DashBoard Obj = new DashBoard();
            Obj.Show();
            this.Hide();
        }

        private void Billing_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
    
   
    

