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
    /// May add a password feature if time permits.
    /// Global Variables: None
    /// Window: A Log In Text Box and a "Begin" button
    /// </summary>
    /// 


    public partial class LoginPopup : Form
    {
        /// <summary>
        /// Constructor for the login popup form.
        /// Methods: loginButton_Click
        /// ** Pre: None
        /// ** Post: None
        /// </summary>
        public LoginPopup()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Click behavior for the login button
        /// Opens the main window and passes the user's chosen name.
        /// ** Pre: Dialog Box for Log In exists.
        /// ** Post: A valid username is accepted and passed to an instance of User to save the user related data, and then to Main Window for other options 
        /// </summary>
        /// <param name="sender">The sending winforms object.</param>
        /// <param name="e">Winforms event arguments.</param>
        private void loginButton_Click(object sender, EventArgs e)
        {
            //block the user from progressing from the login popup if they haven't entered a name
            if (usernameBox.TextLength != 0)
            {
                String userName = usernameBox.Text;
                this.Hide();

                //Call to User to save user related data
                User login = new User(userName, 0);

                //Call to Main Window which gives the option to create event, check availability, and attend event
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
