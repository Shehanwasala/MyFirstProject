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
    public partial class Equipment : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\WW\OneDrive\Desktop\vishual studio projects\GymManagementSystem2\GymManagementSystem2\Database10.mdf;Integrated Security=True");
        SqlCommand com = new SqlCommand();
        public Equipment()
        {
            InitializeComponent();
        }

        private void Equipment_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtEquipmentName.Text == "")
            {
                MessageBox.Show("Enter Equipment Name", "Empty field Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
            else if (txtMuscles.Text == "")
            {
                MessageBox.Show("Enter the Muscles Used", "Empty field Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (dtDeliveryDate.Text == "")
            {
                MessageBox.Show("Enter the Delivery Date", "Empty field Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtCost.Text == "")
            {
                MessageBox.Show("Enter the Cost", "Empty field Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                con.Open();
                String query = "insert into Equipment values('" + txtEquipmentName.Text + "','" + txtDescription.Text + "','" + txtMuscles.Text + "','" + dtDeliveryDate.Text + "','" + txtCost.Text + "')";
                com = new SqlCommand(query, con);
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Saved", "Success Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtEquipmentName.Clear();
                txtDescription.Clear();
                txtMuscles.Clear();               
                txtCost.Clear();

                con.Close();
            }
          
           
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtEquipmentName.Clear();
            txtDescription.Clear();
            txtMuscles.Clear();
            txtCost.Clear();
        }

        private void btnViewEquipment_Click(object sender, EventArgs e)
        {
            ViewEquipment ve = new ViewEquipment();
            ve.ShowDialog();
        }
    }
}
