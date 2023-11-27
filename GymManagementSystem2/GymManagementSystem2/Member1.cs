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
    public partial class Member1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\WW\OneDrive\Desktop\vishual studio projects\GymManagementSystem2\GymManagementSystem2\Database10.mdf;Integrated Security=True");
        SqlCommand com;
        SqlDataReader dr;



        public Member1()
        {
            InitializeComponent();
        }

        private void comboBoxMembership_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Enter id", "Empty field Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtFirstName.Text == "")
            {
                MessageBox.Show("Enter First Name", "Empty field Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtLastName.Text == "")
            {
                MessageBox.Show("Enter Last Name", "Empty field Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            else if (cbGymTime.Text == "")
            {
                MessageBox.Show("Enter the GymTime", "Empty field Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtAddress.Text == "")
            {
                MessageBox.Show("Enter the Address", "Empty field Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cbMembership.Text == "")
            {
                MessageBox.Show("Enter the Membership", "Empty field Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                
                con.Open();
                String query = "insert into People values('" + txtId.Text + "','" + txtFirstName.Text + "','" + txtLastName.Text + "','" + txtGender.Text + "','" + dtDOB.Text + "','" + txtMobile.Text + "','" + dtJoinDate.Text + "','" + cbGymTime.Text + "','" + txtAddress.Text + "','" + cbMembership.Text + "')";
                com = new SqlCommand(query, con);
                com.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Saved", "Success Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtId.Clear();
                txtFirstName.Clear();
                txtLastName.Clear();
                txtGender.Clear();
                txtMobile.Clear();
                cbGymTime.ResetText();
                txtAddress.Clear();
                cbMembership.ResetText();

                con.Close();

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Enter id to Delete", "Empty field Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
               DialogResult result = MessageBox.Show("Are You Sure to Delete"+txtId.Text,"Delete Alert",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
               if (result == DialogResult.Yes)
               {                                       
                       
                       txtId.Clear();
                       txtFirstName.Clear();
                       txtLastName.Clear();
                       txtGender.Clear();
                       txtMobile.Clear();
                       cbGymTime.ResetText();
                       txtAddress.Clear();
                       cbMembership.ResetText();

                       con.Close();
               }
               
              
            }


            
         

        }
        private void Member1_Load(object sender, EventArgs e)

        {
            btnUpdate.Enabled = false;
           

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
            string sql = "Select *From People where Id = '" + txtId.Text + "'";
            com = new SqlCommand(sql, con);
            dr = com.ExecuteReader();
            

            if (dr.Read())
            {
                txtId.Text = dr["Id"].ToString();
                txtFirstName.Text = dr["FirstName"].ToString();
                txtLastName.Text = dr["LastName"].ToString();
                txtGender.Text = dr["Gender"].ToString();
                dtDOB.Text = dr["DOB"].ToString();
                txtMobile.Text = dr["Mobile"].ToString();
                dtJoinDate.Text = dr["JoinDate"].ToString();
                cbGymTime.Text = dr["JoinDate"].ToString();
                txtAddress.Text = dr["Address"].ToString();
                cbMembership.Text = dr["Membership"].ToString();

                con.Close();
            }
            else
            {
                MessageBox.Show("No Record Found", "No Record Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);

                {
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
            else if (txtFirstName.Text == "")
            {
                MessageBox.Show("Enter First Name", "Empty field Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtLastName.Text == "")
            {
                MessageBox.Show("Enter Last Name", "Empty field Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            else if (cbGymTime.Text == "")
            {
                MessageBox.Show("Enter the GymTime", "Empty field Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtAddress.Text == "")
            {
                MessageBox.Show("Enter the Address", "Empty field Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cbMembership.Text == "")
            {
                MessageBox.Show("Enter the Membership", "Empty field Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    con.Open();
                    string sql = "UPDATE People SET FirstName= '" + txtFirstName.Text + "',LastName='" + txtLastName.Text + "',Gender='" + txtGender.Text + "',Dob='" + dtDOB.Text + "',Mobile='" + txtMobile.Text + "',JoinDate='" + dtJoinDate.Text + "',GymTime='" + cbGymTime.Text + "',Address='" + txtAddress.Text + "',Membership='" + cbMembership.Text + "'WHERE Id = '" + txtId.Text + "'";
                    com = new SqlCommand(sql, con);
                    com.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Data Updated", "Success Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtId.Clear();
                    txtFirstName.Clear();
                    txtLastName.Clear();
                    txtGender.Clear();
                    txtMobile.Clear();
                    cbGymTime.ResetText();
                    txtAddress.Clear();
                    cbMembership.ResetText();

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
                finally
                {
                    con.Close();
                }
                      
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtGender.Clear();
            txtMobile.Clear();
            cbGymTime.ResetText();
            txtAddress.Clear();
            cbMembership.ResetText();
        }
            
                  

        }
    
}

