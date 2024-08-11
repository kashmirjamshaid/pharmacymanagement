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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Final_Pharmacy_mangment_24
{
    public partial class Medicine : Form
    {

        public Medicine()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=KASHMIR\\MSSQLSERVER01;Initial Catalog=FPKJ;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Medicine_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this Medicine_Tab", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO [Medicine_Tab](MedName,BPrice,SPrice,Quantity,Company,ExpDate)VALUES(@MedName,@BPrice,@SPrice,@Quantity,@Company,@ExpDate)", con);


                    cmd.Parameters.AddWithValue("@MedName", txt1.Text);
                    cmd.Parameters.AddWithValue("@BPrice", int.Parse(txt3.Text));



                    cmd.Parameters.AddWithValue("@SPrice", int.Parse(txt4.Text));

                    cmd.Parameters.AddWithValue("@Quantity", int.Parse(txt5.Text));

                    cmd.Parameters.AddWithValue("@ExpDate", DateTime.Parse(txt2.Text));
                    cmd.Parameters.AddWithValue("@Company", txt6.Text);

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

            dataGridView1.Rows.Clear();
            cmd = new SqlCommand("SELECT * FROM [Medicine_Tab]", con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
            }
            dr.Close();
            con.Close();
        }

    
                private void button4_Click(object sender, EventArgs e)
                {
                    DashBoard Obj = new DashBoard();
                    Obj.Show();
                    this.Hide();
                }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadStudent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("Update [Medicine_Tab] set MedName=@MedName,BPrice=@BPrice,SPrice=@SPrice,Quantity=@Quantity,ExpDate=@ExpDate,Company=@Company where BPrice=@BPrice", con);


            cmd.Parameters.AddWithValue("@MedName", txt1.Text);
            cmd.Parameters.AddWithValue("@BPrice", int.Parse(txt3.Text));



            cmd.Parameters.AddWithValue("@SPrice", int.Parse(txt4.Text));

            cmd.Parameters.AddWithValue("@Quantity", int.Parse(txt5.Text));

            cmd.Parameters.AddWithValue("@ExpDate", DateTime.Parse(txt2.Text));
            cmd.Parameters.AddWithValue("@Company", txt6.Text);

            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Data Updated");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("Delete [Medicine_Tab] where BPrice=@BPrice", con);

            cmd.Parameters.AddWithValue("@BPrice", int.Parse(txt3.Text));

            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Data Deleted");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            DashBoard Obj = new DashBoard();
            Obj.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txt1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }

        }
    }

} 