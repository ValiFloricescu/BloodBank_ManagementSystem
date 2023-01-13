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

namespace BBMS
{
    public partial class PatientsList : Form
    {
        public PatientsList()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Cosmin\Documents\BloodBankDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void populate()
        {
            Con.Open();
            string Query = "select * from PatientTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            PatientsDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void Reset()
        {
            PNameTb.Text = "";
            PAgeTb.Text = "";
            PPhoneTb.Text = "";
            PGenderCb.SelectedIndex = -1;
            PBGroupCb.SelectedIndex = -1;
            PAddressTb.Text = "";
            key = 0;
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if ((PNameTb.Text == "" || PPhoneTb.Text == "" || PAgeTb.Text == "" || PGenderCb.SelectedIndex == -1 || PBGroupCb.SelectedIndex == -1))
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    string query = "update PatientTbl set PName = '" + PNameTb.Text + "', PAge= '" + PAgeTb.Text + "',PPhone =  '" + PPhoneTb.Text + "',PGender= '" + PGenderCb.SelectedItem.ToString() + "',PBGroup= '" + PBGroupCb.SelectedItem.ToString() + "',PAddress= '" +  PAddressTb.Text + "' where PNum = "+ key+";";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Successfully Updated");
                    Con.Close();
                    Reset();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        int key = 0;

        private void PatientsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PNameTb.Text = PatientsDGV.SelectedRows[0].Cells[1].Value.ToString();
            PAgeTb.Text = PatientsDGV.SelectedRows[0].Cells[2].Value.ToString();
            PPhoneTb.Text = PatientsDGV.SelectedRows[0].Cells[3].Value.ToString();
            PGenderCb.SelectedItem = PatientsDGV.SelectedRows[0].Cells[4].Value.ToString();
            PBGroupCb.SelectedItem = PatientsDGV.SelectedRows[0].Cells[6].Value.ToString();
            PAddressTb.Text = PatientsDGV.SelectedRows[0].Cells[5].Value.ToString();
            if(PNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(PatientsDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if(key == 0)
            {
                MessageBox.Show("Select the patient to delete");
            }
            else 
            {
                try
                {
                    string query = "Delete from PatientTbl where PNum="+key+";";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Successfully Deleted");
                    Con.Close();
                    Reset();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void PatientsList_Load(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Patient p = new Patient();
            p.Show();
            this.Hide();
        }
    }
}
