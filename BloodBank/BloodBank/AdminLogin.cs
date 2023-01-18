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

namespace BloodBank
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\annam\Documents\BloodBankDB.mdf;Integrated Security=True;Connect Timeout=30");


        private void label4_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if(AdminPassTb.Text == "")
            {
                MessageBox.Show("Enter the Admin Password");
            }else if(AdminPassTb.Text == "Password")
            {
                Employee Emp = new Employee();
                Emp.Show();
                this.Hide();
            }else
            {
                MessageBox.Show("WrongPassword. Contact The System Admin");
                AdminPassTb.Text = "";
            }
        }
    }
}
