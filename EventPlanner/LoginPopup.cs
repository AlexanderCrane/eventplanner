using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class LoginPopup : Form
    {

        public string userName;
        public LoginPopup()
        {
            InitializeComponent();
        }


        private void loginButton_Click(object sender, EventArgs e)
        {
            if (usernameBox.TextLength != 0 && usernameBox.Modified)
            {
                this.userName = usernameBox.Text;
                this.Hide();
                MainWindow main = new MainWindow(userName);
                main.Closed += (s, args) => this.Close();
                main.ShowDialog();
            }
            else
            {
                MessageBox.Show("Enter a name!");
            }
        }
    }
}
