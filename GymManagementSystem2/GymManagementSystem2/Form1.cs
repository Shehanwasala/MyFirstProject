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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = "shehan";
            string password = "1234";

            if (username == txtUserName.Text && password == txtPassword.Text)
            {
                MainMenu MM = new MainMenu();
                this.Hide();
                MM.Show();

            }
            else
            {
                MessageBox.Show("Username or password wrong");
            }
        }
    }
}
