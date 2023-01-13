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
    public partial class BloodStock : Form
    {
        public BloodStock()
        {
            InitializeComponent();
            bloodStock();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Cosmin\Documents\BloodBankDb.mdf;Integrated Security=True;Connect Timeout=30");
        

        private void bloodStock()
        {
            Con.Open();
            string Query = "select * from BloodTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BloodStockDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void BloodStock_Load(object sender, EventArgs e)
        {

        }
    }
}
