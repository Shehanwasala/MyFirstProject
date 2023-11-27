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

namespace GymManagementSystem2
{
    public partial class ViewEquipment : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\WW\OneDrive\Desktop\vishual studio projects\GymManagementSystem2\GymManagementSystem2\Database10.mdf;Integrated Security=True");
        SqlCommand com;
        SqlDataReader dr;
        public ViewEquipment()
        {
            InitializeComponent();
        }

        private void ViewEquipment_Load(object sender, EventArgs e)
        {
            con.Open();
            string sql = "Select *From Equipment";
            com = new SqlCommand(sql, con);
            dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView2.DataSource = dt;

            con.Close();
        }
    }
}
