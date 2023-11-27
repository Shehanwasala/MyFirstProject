using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagementSystem2
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void newMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Member1 M1 = new Member1();
            M1.ShowDialog();
        }

        private void searchMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

        }

        private void newStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewStaff ns = new NewStaff();
            ns.ShowDialog();
        }

        private void searchMemberToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SearchMember sm = new SearchMember();
            sm.ShowDialog();
        }

        private void equiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Equipment eq = new Equipment();
            eq.ShowDialog();
                
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will close your application.confirm?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Welcome Back","Welcome",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}
