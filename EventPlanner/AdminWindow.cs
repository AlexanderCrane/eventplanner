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
            TextBox[] TextBoxArray = new TextBox[48];
            
            for (int i = 0; i < 48; i++)
            { 
                TextBox text = new TextBox();
                Label timeLabel = new Label();
                timeLabel.Anchor = (AnchorStyles.Right);
                timeLabel.Text = "              " + currentTime.ToShortTimeString();
                text.ReadOnly = true;
                text.Multiline = true;

                //text.Name = "text" + i.ToString();
                TextBoxArray[i] = text;

                text.MaximumSize = new Size(200, 300);
                text.Size = new Size(300, 50);
                flowLayoutPanel1.Controls.Add(timeLabel);
                flowLayoutPanel1.Controls.Add(text);
                currentTime = currentTime.AddMinutes(30);
            }

            TextBoxArray[3].Text = "test";

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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count % 4 == 0)
                flowLayoutPanel1.SetFlowBreak(e.Control as Control, true);

        }
    }
}
