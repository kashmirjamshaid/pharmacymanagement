using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Pharmacy_mangment_24
{
    internal class MyClassDB
    {
        public static SqlConnection con = null;
        public void dbCon()
        {
            try
            {
                con = new SqlConnection("Data Source=KASHMIR\\MSSQLSERVER01;Initial Catalog=FPKJ;Integrated Security=True;");
                con.Open();
                if (con.State == ConnectionState.Closed || con.State == ConnectionState.Broken)
                {
                    MessageBox.Show("Fail to open database");
                }
                //else
                //{
                //    MessageBox.Show("open database");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    }
