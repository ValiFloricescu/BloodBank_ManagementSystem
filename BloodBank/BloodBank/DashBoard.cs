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
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
            GetData();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\annam\Documents\BloodBankDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void GetData()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from DonorTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DonorLbl.Text = dt.Rows[0][0].ToString();
            SqlDataAdapter sda1 = new SqlDataAdapter("select count(*) from TransferTbl", Con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            TransferLbl.Text = dt1.Rows[0][0].ToString();
            SqlDataAdapter sda2 = new SqlDataAdapter("select count(*) from EmployeeTbl", Con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            UsersLbl.Text = dt2.Rows[0][0].ToString();
            SqlDataAdapter sda3 = new SqlDataAdapter("select Sum(BStock) from BloodTbl", Con);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            int BStock = Convert.ToInt32(dt3.Rows[0][0].ToString());
            TotalLbl.Text = "" + BStock;
            //O+ Code
            SqlDataAdapter sda4 = new SqlDataAdapter("select BStock from BloodTbl where BGroup='"+"O+"+"'", Con);
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);
            OPlusNum.Text = dt4.Rows[0][0].ToString();
            double OplusPercentage = (Convert.ToDouble(dt4.Rows[0][0].ToString())/BStock) * 100;
            OPlusProgress.Value = Convert.ToInt32(OplusPercentage);
            //MessageBox.Show("" + OplusPercentage);

            //AB+
            SqlDataAdapter sda5 = new SqlDataAdapter("select BStock from BloodTbl where BGroup='"+"AB+"+"'", Con);
            DataTable dt5 = new DataTable();
            sda5.Fill(dt5);
            ABPlusNum.Text = dt5.Rows[0][0].ToString();
            double ABplusPercentage = (Convert.ToDouble(dt5.Rows[0][0].ToString()) / BStock) * 100;
            ABplusProgress.Value = Convert.ToInt32(ABplusPercentage);

            //O-
            SqlDataAdapter sda6 = new SqlDataAdapter("select BStock from BloodTbl where BGroup='"+"O-"+"'", Con);
            DataTable dt6 = new DataTable();
            sda6.Fill(dt6);
            OMinusNum.Text = dt6.Rows[0][0].ToString();
            double OminusPercentage = (Convert.ToDouble(dt6.Rows[0][0].ToString()) / BStock) * 100;
            OminusProgress.Value = Convert.ToInt32(OminusPercentage);


            //AB-
            SqlDataAdapter sda7 = new SqlDataAdapter("select BStock from BloodTbl where BGroup='"+"AB-"+"'", Con);
            DataTable dt7 = new DataTable();
            sda7.Fill(dt7);
            ABMinusNum.Text = dt7.Rows[0][0].ToString();
            double ABminusPercentage = (Convert.ToDouble(dt7.Rows[0][0].ToString()) / BStock) * 100;
            ABminusProgress.Value = Convert.ToInt32(ABminusPercentage);
            Con.Close();
        }
        private void DashBoard_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor donor = new Donor();
            donor.Show();
            this.Hide();
        }

        private void TransferLbl_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login Log = new Login();
            Log.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
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
    }
}
