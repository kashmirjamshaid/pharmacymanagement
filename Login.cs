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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            MyClassDB obj = new MyClassDB();

            obj.dbCon();


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = MyClassDB.con;
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "Select * from LoginEB where UserNane='" + textBox1.Text + "' and UserPassword='" + textBox2.Text + "' Collate SQL_Latin1_General_CP1_CS_AS ";

            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            dr.Read();
            if (dr.HasRows)
            {

                DashBoard obj1 = new DashBoard();
                this.Hide();
                obj1.Show();
            }
            else
            {
                MessageBox.Show("Invalid username  or password");
            }
            //connection.con.Close();
        }


        //string username = "Kashmir";
        //string userpassword = "1234";





        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.PasswordChar = (char)0;

            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
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
    }
}

