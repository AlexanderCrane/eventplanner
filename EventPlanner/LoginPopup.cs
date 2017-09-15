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
    /// <summary>
    /// The first form displayed upon startup. Prompts the user for a name.
    /// </summary>
    public partial class LoginPopup : Form
    {
        /// <summary>
        /// Constructor for the login popup form.
        /// </summary>
        public LoginPopup()
        {
            InitializeComponent();
        }
        private void loginButton_Click(object sender, EventArgs e)
        {
            //block the user from progressing from the login popup if they haven't entered a name
            if (usernameBox.TextLength != 0 && usernameBox.Modified)
            {
                String userName = usernameBox.Text;
                this.Hide();
                MainWindow main = new MainWindow(usernameBox.Text);
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
