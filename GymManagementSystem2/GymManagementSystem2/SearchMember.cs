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
    public partial class SearchMember : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\WW\OneDrive\Desktop\vishual studio projects\GymManagementSystem2\GymManagementSystem2\Database10.mdf;Integrated Security=True");
        SqlCommand com;
        SqlDataReader dr;

        public SearchMember()
        {
            InitializeComponent();
        }
        private void SearchMember_Load(object sender, EventArgs e)
        {
           
                con.Open();
                string sql = "Select *From People";
                com = new SqlCommand(sql, con);
                dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                con.Close();
           
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
                     

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Close();
                string sql = "Select *From People WHERE Id like '%" + txtSearch.Text + "%'";
                com = new SqlCommand(sql, con);
                con.Open();
                dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
           
           
        }

           
        private void btnDeleteMember_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                MessageBox.Show("Enter Id Number to Delete", "Empty field Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var result = MessageBox.Show("Are you sure to Delete"+txtSearch.Text,"Delete Alert",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
                
                
                if(result == DialogResult.Yes)               
                {
                    con.Open();
                    string sql = "DELETE From People WHERE Id= '" + txtSearch.Text + "'";
                    com = new SqlCommand(sql, con);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Data Deleted Succesfully", "Success Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSearch.Clear();
                    con.Close();
                }
                else
                {
                    con.Close();
                }


            }
        }


        }

      
    }



