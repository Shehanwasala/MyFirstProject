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
    public partial class NewStaff : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\WW\OneDrive\Desktop\vishual studio projects\GymManagementSystem2\GymManagementSystem2\Database10.mdf;Integrated Security=True");
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        public NewStaff()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string Id = txtId.Text;
            string Name = txtName.Text;
            string Gender = txtGender.Text;
            string DOB = dtDOB.Text;
            string Mobile = txtMobile.Text;
            string JoinDate = dtJoinDate.Text;
            string Address = txtAddress.Text;

            if (txtId.Text == "")
            {
                MessageBox.Show("Enter id", "Empty field Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtName.Text == "")
            {
                MessageBox.Show("Enter Name", "Empty field Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtGender.Text == "")
            {
                MessageBox.Show("Enter the Gender", "Empty field Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (dtDOB.Text == "")
            {
                MessageBox.Show("Enter the DOB", "Empty field Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtMobile.Text == "")
            {
                MessageBox.Show("Enter the Mobile", "Empty field Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (dtJoinDate.Text == "")
            {
                MessageBox.Show("Enter the JoinDate", "Empty field Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtAddress.Text == "")
            {
                MessageBox.Show("Enter the Address", "Empty field Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                con.Open();
                String query = "insert into NewStaff values('" + txtId.Text + "','" + txtName.Text + "','" + txtGender.Text + "','" + dtDOB.Text + "','" + txtMobile.Text + "','" + dtJoinDate.Text + "','" + txtAddress.Text + "')";
                com = new SqlCommand(query, con);
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Saved", "Success Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtId.Clear();
                txtName.Clear();
                txtGender.Clear();
                txtMobile.Clear();
                dtJoinDate.ResetText();
                txtAddress.Clear();


                con.Close();


            }



        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtName.Clear();
            txtGender.Clear();
            txtMobile.Clear();
            dtJoinDate.ResetText();
            txtAddress.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Enter id to Delete", "Empty field Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult result = MessageBox.Show("Are You Sure to Delete" + txtId.Text, "Delete Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {

                    con.Open();
                    string sql = " DELETE from NewStaff WHERE Id ='" + txtId.Text + "'";
                    com = new SqlCommand(sql, con);
                    com.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data Deleted Succesfully", "Success Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtId.Clear();
                    txtName.Clear();
                    txtGender.Clear();
                    txtMobile.Clear();
                    dtJoinDate.ResetText();
                    txtAddress.Clear();



                    con.Close();
                }

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Enter id", "Empty field Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtName.Text == "")
            {
                MessageBox.Show("Enter Name", "Empty field Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtGender.Text == "")
            {
                MessageBox.Show("Enter the Gender", "Empty field Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (dtDOB.Text == "")
            {
                MessageBox.Show("Enter the DOB", "Empty field Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtMobile.Text == "")
            {
                MessageBox.Show("Enter the Mobile", "Empty field Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (dtJoinDate.Text == "")
            {
                MessageBox.Show("Enter the JoinDate", "Empty field Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtAddress.Text == "")
            {
                MessageBox.Show("Enter the Address", "Empty field Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                con.Open();
                String query = "UPDATE NewStaff SET Name = '" + txtName.Text + "',Gender='" + txtGender.Text + "',Dob='" + dtDOB.Text + "',Mobile='" + txtMobile.Text + "',JoinDate='" + dtJoinDate.Text + "',Address='" + txtAddress.Text + "'";
                com = new SqlCommand(query, con);
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Updated", "Success Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtId.Clear();
                txtName.Clear();
                txtGender.Clear();
                txtMobile.Clear();
                dtJoinDate.ResetText();
                txtAddress.Clear();

                con.Close();
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Enter id Number to Search", "Empty field Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            btnUpdate.Enabled = true;
            btnReset.Enabled = true;
            btnSave.Enabled = true;

            con.Open();
            string sql = "Select *From NewStaff where Id = '" + txtId.Text + "'";
            com = new SqlCommand(sql, con);
            dr = com.ExecuteReader();

            if (dr.Read())
            {
                txtId.Text = dr["Id"].ToString();
                txtName.Text = dr["Name"].ToString();
                txtGender.Text = dr["Gender"].ToString();
                dtDOB.Text = dr["DOB"].ToString();
                txtMobile.Text = dr["Mobile"].ToString();
                dtJoinDate.Text = dr["JoinDate"].ToString();
                txtAddress.Text = dr["Address"].ToString();


                con.Close();

            }
            else
            {
                MessageBox.Show("No Record Found", "No Record Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            {
                con.Close();
            }
        }
    }
}
    

        
        





