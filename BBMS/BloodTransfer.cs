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
using System.Data.SqlClient;

namespace BBMS
{
    public partial class BloodTransfer : Form
    {
        public BloodTransfer()
        {
            InitializeComponent();
            fillPatientCb();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Cosmin\Documents\BloodBankDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void fillPatientCb()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select PNum from PatientTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("PNum", typeof(int));   
            dt.Load(rdr);
            PatientIDCb.ValueMember = "PNum";
            PatientIDCb.DataSource= dt;
            Con.Close();
        }

        private void GetData(string Bgroup)
        {
            //helps to get the blood group
            Con.Open();
            string query = "select * from PatientTbl where PNum ='" + PatientIDCb.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                PatNameTb.Text = dr["PName"].ToString();
                BloodGroup.Text = dr["PBGroup"].ToString();

            }
            Con.Close();
        }
        private void label13_Click(object sender, EventArgs e)
        {

        }

       
        private void BloodTransfer_Load(object sender, EventArgs e)
        {

        }

        private void PatientIDCb_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
