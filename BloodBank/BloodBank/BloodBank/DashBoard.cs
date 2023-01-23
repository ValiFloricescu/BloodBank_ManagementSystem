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
            SqlDataAdapter sda2 = new SqlDataAdapter("select count(*) from PatientTbl", Con);
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
            double stock7 = Convert.ToDouble(dt4.Rows[0][0].ToString());
            if (stock7 >= 5)
            {
                OPlusProgress.ProgressColor = Color.Green;
                OPlusProgress.ProgressColor2 = Color.Green;
            }
            else
                    if (stock7 > 0)
            {
                OPlusProgress.ProgressColor = Color.Yellow;
                OPlusProgress.ProgressColor2 = Color.Yellow;
            }
            else
            {
                OPlusProgress.ProgressColor = Color.Red;
                OPlusProgress.ProgressColor2 = Color.Red;
            }

            OPlusProgress.Value = 100;

            //AB+
            SqlDataAdapter sda5 = new SqlDataAdapter("select BStock from BloodTbl where BGroup='"+"AB+"+"'", Con);
            DataTable dt5 = new DataTable();
            sda5.Fill(dt5);
            ABPlusNum.Text = dt5.Rows[0][0].ToString();
            double stock6 = Convert.ToDouble(dt5.Rows[0][0].ToString());
            if (stock6 >= 5)
            {
                ABplusProgress.ProgressColor = Color.Green;
                ABplusProgress.ProgressColor2 = Color.Green;
            }
            else
                    if (stock6 > 0)
            {
                ABplusProgress.ProgressColor = Color.Yellow;
                ABplusProgress.ProgressColor2 = Color.Yellow;
            }
            else
            {
                ABplusProgress.ProgressColor = Color.Red;
                ABplusProgress.ProgressColor2 = Color.Red;
            }

            ABplusProgress.Value = 100;

            //O-
            SqlDataAdapter sda6 = new SqlDataAdapter("select BStock from BloodTbl where BGroup='"+"O-"+"'", Con);
            DataTable dt6 = new DataTable();
            sda6.Fill(dt6);
            OMinusNum.Text = dt6.Rows[0][0].ToString();
            double stock4 = Convert.ToDouble(dt6.Rows[0][0].ToString());
            if (stock4 >= 5)
            {
                OminusProgress.ProgressColor = Color.Green;
                OminusProgress.ProgressColor2 = Color.Green;
            }
            else
                    if (stock4 > 0)
            {
                OminusProgress.ProgressColor = Color.Yellow;
                OminusProgress.ProgressColor2 = Color.Yellow;
            }
            else
            {
                OminusProgress.ProgressColor = Color.Red;
                OminusProgress.ProgressColor2 = Color.Red;
            }

            OminusProgress.Value = 100;


            //AB-
            SqlDataAdapter sda7 = new SqlDataAdapter("select BStock from BloodTbl where BGroup='"+"AB-"+"'", Con);
            DataTable dt7 = new DataTable();
            sda7.Fill(dt7);
            ABMinusNum.Text = dt7.Rows[0][0].ToString();
            double stock2 = Convert.ToDouble(dt7.Rows[0][0].ToString());
            if (stock2 >= 5)
            {
                ABMinusProgress.ProgressColor = Color.Green;
                ABMinusProgress.ProgressColor2 = Color.Green;
            }
            else
                    if (stock2 > 0)
            {
                ABMinusProgress.ProgressColor = Color.Yellow;
                ABMinusProgress.ProgressColor2 = Color.Yellow;
            }
            else
            {
                ABMinusProgress.ProgressColor = Color.Red;
                ABMinusProgress.ProgressColor2 = Color.Red;
            }

            ABMinusProgress.Value = 100;
            Con.Close();

            //A+
            SqlDataAdapter sda8 = new SqlDataAdapter("select BStock from BloodTbl where BGroup='" + "A+" + "'", Con);
            DataTable dt8 = new DataTable();
            sda8.Fill(dt8);
            APlusNum.Text = dt8.Rows[0][0].ToString();
            double stock3 = Convert.ToDouble(dt8.Rows[0][0].ToString());
            if (stock3 >= 5)
            {
                APlusProgress.ProgressColor = Color.Green;
                APlusProgress.ProgressColor2 = Color.Green;
            }
            else
                    if (stock3 > 0)
            {
                APlusProgress.ProgressColor = Color.Yellow;
                APlusProgress.ProgressColor2 = Color.Yellow;
            }
            else
            {
                APlusProgress.ProgressColor = Color.Red;
                APlusProgress.ProgressColor2 = Color.Red;
            }

            APlusProgress.Value = 100;
            Con.Close();



            //A-
            SqlDataAdapter sda9 = new SqlDataAdapter("select BStock from BloodTbl where BGroup='" + "A-" + "'", Con);
            DataTable dt9 = new DataTable();
            sda9.Fill(dt9);
            AMinusNum.Text = dt9.Rows[0][0].ToString();
            double stock5 = Convert.ToDouble(dt9.Rows[0][0].ToString());
            if (stock5 >= 5)
            {
                AMinusProgress.ProgressColor = Color.Green;
                AMinusProgress.ProgressColor2 = Color.Green;
            }
            else
                    if (stock5 > 0)
            {
                AMinusProgress.ProgressColor = Color.Yellow;
                AMinusProgress.ProgressColor2 = Color.Yellow;
            }
            else
            {
                AMinusProgress.ProgressColor = Color.Red;
                AMinusProgress.ProgressColor2 = Color.Red;
            }

            AMinusProgress.Value = 100;
            Con.Close();



            //B+
            SqlDataAdapter sda10 = new SqlDataAdapter("select BStock from BloodTbl where BGroup='" + "B+" + "'", Con);
            DataTable dt10 = new DataTable();
            sda10.Fill(dt10);
            BPlusNum.Text = dt10.Rows[0][0].ToString();
            double stock1 = Convert.ToDouble(dt10.Rows[0][0].ToString());
            if (stock1 >= 5)
            {
                BPlusProgress.ProgressColor = Color.Green;
                BPlusProgress.ProgressColor2 = Color.Green;
            }
            else
                    if (stock1 > 0)
            {
                BPlusProgress.ProgressColor = Color.Yellow;
                BPlusProgress.ProgressColor2 = Color.Yellow;
            }
            else
            {
                BPlusProgress.ProgressColor = Color.Red;
                BPlusProgress.ProgressColor2 = Color.Red;
            }

            BPlusProgress.Value = 100;
            Con.Close();




            //B-
            SqlDataAdapter sda11 = new SqlDataAdapter("select BStock from BloodTbl where BGroup='" + "B-" + "'", Con);
            DataTable dt11 = new DataTable();
            sda11.Fill(dt11);
            BMinusNum.Text = dt11.Rows[0][0].ToString();
            double stock0 = Convert.ToDouble(dt11.Rows[0][0].ToString());
            if (stock0 >= 5)
            {
                BMinusProgress.ProgressColor = Color.Green;
                BMinusProgress.ProgressColor2 = Color.Green;
            }
            else
                    if (stock0 > 0)
                    {
                        BMinusProgress.ProgressColor = Color.Yellow;
                        BMinusProgress.ProgressColor2 = Color.Yellow;
                    }
                    else
                    {
                        BMinusProgress.ProgressColor = Color.Red;
                        BMinusProgress.ProgressColor2 = Color.Red;
                    }
                
            BMinusProgress.Value = 100;
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

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OPlusProgress_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
