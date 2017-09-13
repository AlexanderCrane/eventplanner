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

            if (usernameBox.TextLength == 0)
            {
                MessageBox.Show("Enter a username!");
            }
            else
            {
                DateTime placeHolder = mainCalendar.SelectionStart;
                RegisterEventWindow registerPopup = new RegisterEventWindow(placeHolder);
                registerPopup.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (usernameBox.TextLength == 0)
            {
                MessageBox.Show("Enter a username!");
            }
            else
            {
                UserWindow user = new UserWindow();
                user.ShowDialog();
            }
        }

        private void mainCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            currentDateLabel.Text = e.Start.ToShortDateString();
        }

        private void StartWindow_Load(object sender, EventArgs e)
        {
            currentDateLabel.Text = DateTime.Today.ToShortDateString();
        }

        private void currentDateLabel_Click(object sender, EventArgs e)
        {
            
        }
    }
}
