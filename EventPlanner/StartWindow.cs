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
    public partial class StartWindow : Form
    {
        public StartWindow()
        {
            InitializeComponent();
            //lock size
            this.MaximumSize = this.Size;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //todo - pop up error if no username entered
            if (!usernameBox.Modified)
            {
                MessageBox.Show("Enter a username!");
            }
            else
            {
                AdminWindow admin = new AdminWindow();
                admin.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!usernameBox.Modified)
            {
                MessageBox.Show("Enter a username!");
            }
            else
            {
                //todo - pop up error if no username entered
                UserWindow user = new UserWindow();
                user.ShowDialog();
            }
        }
    }
}
