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
            DateTime currentTime = DateTime.Today;
  
            for (int i = 0; i < 48; i++) {
                TextBox text = new TextBox();
                Label timeLabel = new Label();
                timeLabel.Anchor = (AnchorStyles.Right);
                timeLabel.Text = "              " + currentTime.ToShortTimeString();
                text.ReadOnly = true;
                text.Multiline = true;
                text.MaximumSize = new Size(200, 300);
                text.Size = new Size(300, 50);
                flowLayoutPanel1.Controls.Add(timeLabel);
                flowLayoutPanel1.Controls.Add(text);
                currentTime = currentTime.AddMinutes(30);
            }
        }

        private void addEventButton_Click(object sender, EventArgs e)
        {
            //open 'add event dialog'
            RegisterEventWindow registerPopup = new RegisterEventWindow();
            registerPopup.ShowDialog();
        }

        private void calendar1_ItemCreating(object sender, CalendarItemCancelEventArgs e)
        {
            //when the user clicks on the calendar, cancel the calendar library's default event creation
            //instead, open our own add event dialog so we can create non-contiguous events
            e.Cancel = true;
            Console.Out.WriteLine("creating");
        }

        private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count % 4 == 0)
                flowLayoutPanel1.SetFlowBreak(e.Control as Control, true);

        }
    }
}
