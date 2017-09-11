using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Calendar;

namespace WindowsFormsApplication1
{
    public partial class AdminWindow : Form
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void AdminWindow_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 48; i++) {
                TextBox text = new TextBox();
                text.ReadOnly = true;
                text.MaximumSize = new Size(200, 300);
                text.Size = new Size(200, 300);
                text.Text = i.ToString();
                flowLayoutPanel1.Controls.Add(text);
            }
            currentDateLabel.Text = DateTime.Today.ToShortDateString();
        }

        private void addEventButton_Click(object sender, EventArgs e)
        {
            //open 'add event dialog'
            RegisterEventWindow registerPopup = new RegisterEventWindow(monthCalendar1.SelectionStart);
            registerPopup.ShowDialog();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            currentDateLabel.Text = e.Start.ToShortDateString();
        }
    }
}
