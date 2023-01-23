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
using System.Linq.Expressions;

namespace BloodBank
{
    public partial class Donor : Form
    {
        public Donor()
        {
            InitializeComponent();
        }

        private void Donor_Load(object sender, EventArgs e)
        {

        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\annam\Documents\BloodBankDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void Reset()
        {
            DNameTb.Text = "";
            DAgeTb.Text = "";
            DPhoneTb.Text = "";
            DGenCb.SelectedIndex = -1;
            DBGroupCb.SelectedIndex = -1;
            DAddressTb.Text = "";
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if(DNameTb.Text == "" || DPhoneTb.Text == "" || DAgeTb.Text == "" || DGenCb.SelectedIndex == -1 || DBGroupCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try {
                    string query = "insert into DonorTbl values('" + DNameTb.Text + "','" + DAgeTb.Text + "','" + DGenCb.SelectedItem.ToString() + "','" + DPhoneTb.Text + "','" + DAddressTb.Text + "','" + DBGroupCb.SelectedItem.ToString() + "')";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Donor Successfully Saved");
                    Con.Close();
                    Reset();
                    } catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {
            DonateBlood Ob = new DonateBlood();
            Ob.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ViewDonor ob = new ViewDonor();
            ob.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Patient ob = new Patient();
            ob.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ViewPatients ob = new ViewPatients();
            ob.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            BloodStock ob = new BloodStock();
            ob.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            BloodTransfer ob = new BloodTransfer();
            ob.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            DashBoard ob = new DashBoard();
            ob.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}