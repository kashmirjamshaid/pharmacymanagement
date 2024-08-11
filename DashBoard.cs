using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Pharmacy_mangment_24
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Medicine obj1 = new Medicine();
            this.Hide();
            obj1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employee obj1 = new Employee();
            this.Hide();
            obj1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Company obj1 = new Company();
            this.Hide();
            obj1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Billing obj1 = new Billing();
            this.Hide();
            obj1.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
